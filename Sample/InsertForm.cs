﻿using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using TeetSurvey.Repository.Model;

namespace Sample
{
    public partial class InsertForm : Form
    {
        private int? _questionId { get; }
        private bool _isLoadingToUpdate = false;
        private List<InsertSurveyList> SurveyList { get; set; }
        private List<OptionControl> GetOptionControls() => new List<OptionControl>()
        {
            new OptionControl(){
                Id =(int)OptionControls.RadioButton,
                Text =nameof(OptionControls.RadioButton)},
            new OptionControl(){
                Id =(int)OptionControls.ComboBox,
                Text =nameof(OptionControls.ComboBox)},
            new OptionControl(){
                Id =(int)OptionControls.CheckedListBox,
                Text =nameof(OptionControls.CheckedListBox)}
        };

        public InsertForm(int? questionId)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            InitializeComponent();
            LoadCombos(-1);
            _questionId = questionId;
            if (questionId.HasValue)
            {
                LoadQuestionData();
                Text = "Soru Düzenle";
            }
            comboControl.DataSource = GetOptionControls();
            comboControl.DisplayMember = nameof(OptionControl.Text);
            comboControl.ValueMember = nameof(OptionControl.Id);

            SplashScreenManager.CloseForm(false);
        }

        private async void LoadQuestionData()
        {
            _isLoadingToUpdate = true;
            using (var m = new Model())
            {

                var quest = await m.Questions.Select(f =>
                new InsertQuest
                {
                    CategoryId = f.CategoryId,
                    Description = f.Description,
                    DependedQuestionId = f.DependedQuestionId,
                    DependedOptionIds = f.DependendOptions.Select(d => d.DependedOptionId).ToList(),
                    QuestionId = f.QuestionId,
                    ControlId = f.ControlId,
                    IsMultiple = f.IsMultipleOption,
                    Opts = f.Options.Select(o =>
                      new InsertOpt
                      {
                          OptId = o.OptionId,
                          QuestionId = o.QuestionId,
                          Text = o.Text,
                          Value = o.Value,
                          IsDefault = o.IsDefault

                      }).ToList()
                }).
                    FirstOrDefaultAsync(q => q.QuestionId == _questionId.Value);

                if (quest != null)
                {
                    CategoryCombo.SelectedValue = quest.CategoryId;
                    foreach (var option in quest.Opts)
                    {
                        var item = new ListViewItem(option.Text);
                        item.Tag = option.OptId;
                        item.SubItems.Add(option.Value?.ToString());
                        item.SubItems.Add(option.IsDefault.ToString());
                        OptionlistView.Items.Add(item);
                    }
                    txtDesc.Text = quest.Description;
                    chkMultiple.Checked = quest.IsMultiple;
                    comboControl.SelectedValue = quest.ControlId;
                    DependendQuestCombo.SelectedValue = quest.DependedQuestionId ?? -1;

                    if (quest.DependedQuestionId.HasValue)
                    {
                        RefreshDependedOption(
                          quest);
                    }

                    foreach (CheckedListBoxItem item in dependendOptions.Items)
                    {
                        if (quest.DependedOptionIds.Any(f => f.ToString() == item.Value.ToString()))
                        {
                            item.CheckState = CheckState.Checked;
                        }
                    }

                }

            }
            _isLoadingToUpdate = false;
        }

        private void LoadCombos(int selectedCatId)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

            using (var model = new Model())
            {
                SurveyList = model.
                    SurveyLists.Select(s => new InsertSurveyList
                    {
                        SurveylistId = s.Id,
                        SurveyName = s.SurveyName,
                        Cat =
                    s.Categories.
                    Select(f => new InsertCat
                    {
                        CatId = f.CategoryId,
                        Title = f.CategoryTitle,
                        Quests = f.Questions.Select(q =>
                          new InsertQuest
                          {
                              CategoryId = q.CategoryId,
                              Description = q.Description,
                              QuestionId = q.QuestionId,
                              Opts = q.
                              Options.
                              Select(o =>
                              new InsertOpt
                              {
                                  OptId = o.OptionId,
                                  QuestionId = o.QuestionId,
                                  Text = o.Text,
                                  Value = o.Value,
                                  IsDefault = o.IsDefault
                              }).ToList()
                          }).ToList()
                    }).ToList()

                    }).ToList();

                comboSurveyList.DisplayMember = nameof(InsertSurveyList.SurveyName);
                comboSurveyList.ValueMember = nameof(InsertSurveyList.SurveylistId);

                comboSurveyList.DataSource = SurveyList;

                if (selectedCatId > 0 && CategoryCombo.DataSource is List<InsertCat> lstCat && lstCat.Any(l => l.CatId == selectedCatId))
                {
                    CategoryCombo.SelectedValue = selectedCatId;
                }
                else if (CategoryCombo.Items.Count > 0)
                {
                    CategoryCombo.SelectedIndex = 0;
                }

            }
            SplashScreenManager.CloseForm(false);
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (comboSurveyList.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Lütfen survey seçiniz");
                return;
            }
            if (CategoryCombo.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Lütfen kategori seçiniz");
                return;
            }
            if (txtDesc.Text.Trim() == string.Empty)
            {

                MessageBox.Show("Lütfen Soru giriniz");
                return;
            }
            if (OptionlistView.Items.Count < 2)
            {

                MessageBox.Show("Lütfen en az 2 seçenek giriniz");
                return;
            }

            if (DependendQuestCombo.SelectedValue.ToString() != "-1" && dependendOptions.ItemCount < 2)
            {

                MessageBox.Show("Lütfen bağımlı sorunun en az bir bağımlı cevabını giriniz");
                return;
            }

            try
            {
                if (!_questionId.HasValue)//insert
                {
                    using (var model = new Model())
                    {
                        List<Option> opts = GetOptions();
                        var quest = new Question()
                        {
                            CategoryId = int.Parse(CategoryCombo.SelectedValue.ToString()),
                            Description = txtDesc.Text,
                            DependedQuestionId = int.Parse(DependendQuestCombo.SelectedValue.ToString()) > 0 ?
                            int.Parse(DependendQuestCombo.SelectedValue.ToString()) : (int?)null,
                            DependendOptions =
                            dependendOptions.CheckedItems.OfType<CheckedListBoxItem>().
                            Select(f => new DependendOption()
                            {
                                DependedOptionId = (int)f.Value
                            }).ToList(),
                            //DependedOptionId = dependendOptions.EditValue is Option o ? o.OptionId : (int?)null,
                            Options = opts,
                            ControlId = int.TryParse(comboControl.SelectedValue?.ToString(), out var cid) ? cid : 1,
                            IsMultipleOption = chkMultiple.Checked

                        };

                        model.Questions.Add(quest);
                        if (model.SaveChanges() > 0)
                        {
                            MessageBox.Show("Insert operation has been done succesfully.");
                            LoadCombos(int.TryParse(CategoryCombo.SelectedValue?.ToString(), out var cId) ? cId : -1);
                        }
                    }
                }
                else
                {
                    using (var model = new Model())
                    {
                        var question = model.Questions.
                            Include(f=>f.Options).
                            Include(f=>f.Category).
                            Include(f=>f.DependendOptions).
                            FirstOrDefault(f => f.QuestionId == _questionId.Value);

                        question.CategoryId = int.Parse(CategoryCombo.SelectedValue?.ToString());
                        question.Description = txtDesc.Text;
                        question.DependedQuestionId =
                            int.TryParse(DependendQuestCombo.SelectedValue?.ToString(), out var depId) && depId != -1
                            ? depId
                            : (int?)null;

                        question.IsMultipleOption = chkMultiple.Checked;
                        question.ControlId = int.TryParse(comboControl.SelectedValue?.ToString(), out var cid) ? cid : 1;
                        
                        question.DependendOptions = dependendOptions.CheckedItems.OfType<CheckedListBoxItem>().
                            Select(f => new DependendOption()
                            {
                                DependedOptionId = (int)f.Value
                            }).ToList();

                        var currentOptions = question.Options.ToList();
                        
                        var editedOptions = OptionlistView.Items.Cast<ListViewItem>().Select(f => new Option()
                        {
                            QuestionId = question.QuestionId,
                            OptionId = int.TryParse(f.Tag?.ToString(), out var id) ? id : 0,
                            Text = f.Text,
                            Value = int.TryParse(f.SubItems[1].Text, out var val) ? val : (int?)null,
                            IsDefault = f.SubItems[2].Text == true.ToString()
                        }).ToList();

                        var interstects = currentOptions.
                            Select(f => f.OptionId).ToList().
                            Intersect(editedOptions.Select(f => f.OptionId).ToList());

                        var left = currentOptions.Where(f => !interstects.Contains(f.OptionId)).ToList();
                        var right = editedOptions.Where(f => !interstects.Contains(f.OptionId)).ToList();

                        foreach (var oId in interstects)
                        {
                            var opt = question.Options.FirstOrDefault(f => f.OptionId == oId);
                            if (opt != null)
                            {
                                opt.Text = editedOptions.FirstOrDefault(f => f.OptionId == oId)?.Text;
                                opt.Value = editedOptions.FirstOrDefault(f => f.OptionId == oId)?.Value;
                                opt.IsDefault = editedOptions.FirstOrDefault(f => f.OptionId == oId)?.IsDefault ?? false;
                            }
                        }

                        foreach (var opt in left)
                        {
                            var o = question.Options.FirstOrDefault(f => f.OptionId == opt.OptionId);
                            question.Options.Remove(o);
                            model.Entry(o).State = EntityState.Deleted;
                        }
                        foreach (var item in right)
                        {
                            question.Options.Add(new Option()
                            {
                                QuestionId = question.QuestionId,
                                Text = item.Text,
                                Value = item.Value,
                                IsDefault = item.IsDefault
                            });
                        }

                        model.Questions.Attach(question);
                        model.Entry(question).State = EntityState.Modified;

                        if (model.SaveChanges() > 0)
                        {
                            MessageBox.Show("Update operation has been done succesfully.");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private List<Option> GetOptions()
        {
            var opts = new List<Option>();
            for (var i = 0; i < OptionlistView.Items.Count; i++)
            {
                var opt = new Option()
                {
                    Text = OptionlistView.Items[i].Text,
                    Value = int.TryParse(
                        OptionlistView.Items[i].SubItems[1].Text,
                        out var res) ? res : (int?)null,
                    IsDefault = OptionlistView.Items[i].SubItems[2].Text == true.ToString()
                };
                opts.Add(opt);
            }

            return opts;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var input = new InputBox(string.Empty, (int?)null, false);
            if (input.ShowDialog() == DialogResult.OK)
            {
                if (input.chkIsDefault.Checked)
                {
                    foreach (ListViewItem old in OptionlistView.Items)
                    {
                        old.SubItems[2].Text = false.ToString();
                    }
                }
                var item = OptionlistView.Items.Add(input.txtOption.Text);
                item.SubItems.
                Add(input.txtValue.Text);
                item.SubItems.Add(input.chkIsDefault.Checked.ToString());

            }

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InsertForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void DependendQuestCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DependendQuestCombo.SelectedItem is InsertQuest q)
            {
                layoutControlItem10.Visibility =
                    (q.QuestionId == -1) ?
                    DevExpress.XtraLayout.Utils.LayoutVisibility.Never :
                    DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                if (!_isLoadingToUpdate)
                {
                    RefreshDependedOption(q);
                }
            }
        }

        private void RefreshDependedOption(InsertQuest q)
        {
            dependendOptions.DataSource = q.Opts;
            dependendOptions.DisplayMember = "Text";
            dependendOptions.ValueMember = "OptId";

            foreach (CheckedListBoxItem item in dependendOptions.Items)
            {
                if (q.DependedOptionIds.Contains(int.Parse(item.Value?.ToString())) == true)
                {
                    item.CheckState = CheckState.Checked;
                }
            }

        }

        private void btnNewCat_Click(object sender, EventArgs e)
        {
            if (comboSurveyList.SelectedItem is InsertSurveyList il)
            {
                var f = new NewCategory(
                il.SurveyName,
                int.Parse(comboSurveyList.SelectedValue.ToString()));

                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadCombos(f.Result);
                }
            }
        }

        private void SilOption()
        {
            if (OptionlistView.SelectedItems.Count == 0)
            {
                return;
            }
            if (!_questionId.HasValue)
            {
                OptionlistView.SelectedItems[0]?.Remove();
            }
            else
            {
                var text = OptionlistView.SelectedItems[0]?.Text;
                using (var model = new Model())
                {
                    var optionId = model.Options.FirstOrDefault(f => f.QuestionId == _questionId.Value && f.Text == text)?.OptionId;
                    if (model.DependendOptions.Any(f => f.DependedOptionId == optionId))
                    {
                        MessageBox.Show("Bu seçenek başka bir sorunun bağımlılığını oluşturuyor. \n" +
                            "Alt soruyu silmeden veya alt sorunun bu seçeneğe bağımlılığını değiştirmeden bu seçeneği silemezsiniz");

                        return;
                    }
                    else { OptionlistView.SelectedItems[0]?.Remove(); }
                }

            }
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SilOption();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OptionlistView.SelectedItems.Count == 0)
            {
                return;
            }
            var input =
                new InputBox(
                    OptionlistView.SelectedItems[0].Text,
                    int.TryParse(OptionlistView.SelectedItems[0].SubItems[1].Text, out var val)
                    ? val : (int?)null,
                    OptionlistView.SelectedItems[0].SubItems[2].Text == true.ToString());
            if (input.ShowDialog() == DialogResult.OK)
            {
                if (input.chkIsDefault.Checked)
                {
                    foreach (ListViewItem old in OptionlistView.Items)
                    {
                        old.SubItems[2].Text = false.ToString();
                    }
                }
                OptionlistView.SelectedItems[0].Text = input.txtOption.Text;
                OptionlistView.SelectedItems[0].SubItems[1].Text = input.txtValue.Text;
                OptionlistView.SelectedItems[0].SubItems[2].Text = input.chkIsDefault.Checked.ToString();
            }
        }

        private void CategoryCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoryCombo.SelectedItem is InsertCat cat)
            {
                if (cat.CatId == -1)
                {
                    return;
                }
                var dependedQuestions = cat.Quests;

                dependedQuestions.Insert(0, new InsertQuest() { Description = "Seçiniz", QuestionId = -1 });
                DependendQuestCombo.DataSource = dependedQuestions;
                DependendQuestCombo.DisplayMember = nameof(Question.Description);
                DependendQuestCombo.ValueMember = nameof(Question.QuestionId);
            }
        }


        private void chkMultiple_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMultiple.Checked)
            {
                comboControl.SelectedValue = (int)OptionControls.CheckedListBox;
                comboControl.Enabled = false;
            }
            else
            {
                comboControl.Enabled = true;
            }
        }

        private void comboSurveyList_SelectedIndexChanged(object sender, EventArgs e)
        {

            CategoryCombo.DisplayMember = nameof(InsertCat.Title);
            CategoryCombo.ValueMember = nameof(InsertCat.CatId);
            CategoryCombo.DataSource =
                SurveyList.
                FirstOrDefault(f =>
                f.SurveylistId == int.Parse(comboSurveyList.SelectedValue.ToString()))?.Cat;

        }

        private class InsertQuest
        {
            public int CategoryId { get; set; }
            public int QuestionId { get; set; }
            public string Description { get; set; }
            public int? DependedQuestionId { get; set; }
            public List<int> DependedOptionIds { get; set; }
            public List<InsertOpt> Opts { get; set; }
            public bool IsMultiple { get; set; }
            public int ControlId { get; set; }
        }
        private class InsertOpt
        {
            public int OptId { get; set; }
            public string Text { get; set; }
            public int QuestionId { get; set; }
            public int? Value { get; set; }
            public bool IsDefault { get; set; }
        }
        private class InsertCat
        {
            public int CatId { get; set; }
            public string Title { get; set; }
            public List<InsertQuest> Quests { get; set; }
        }

        private class InsertSurveyList
        {
            public int SurveylistId { get; set; }
            public string SurveyName { get; set; }
            public List<InsertCat> Cat { get; set; }
        }
    }


}
