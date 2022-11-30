using DevExpress.Data.ODataLinq.Helpers;
using DevExpress.Data.WcfLinq.Helpers;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPrinting;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeetSurvey.Repository.Model;

namespace Sample
{
    public partial class SurveyWizardForm : DevExpress.XtraEditors.XtraForm
    {
        public List<Cat> CategoryWithQuestions { get; set; }
        public Survey virtualSurvey;


        public SurveyWizardForm(Survey survey)
        {
            InitializeComponent();
            Text = survey.SurveyList.SurveyName +
                " [ " + survey.Pollster.Name + " ] ";
            virtualSurvey = survey;
        }



        private async void SurveyWizardForm_Load(object sender, System.EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            try
            {
                using (var model = new Model())
                {
                    CategoryWithQuestions =
                        await model.Categories.
                        AsNoTracking().
                        Where(c => c.Questions.Count > 0
                        && c.SurveyListId == virtualSurvey.SurveyListId).
                        Select(c => new Cat()
                        {
                            CatId = c.CategoryId,
                            Title = c.CategoryTitle,
                            Quests = c.Questions.
                        Select(q => new SurveyQuest()
                        {
                            Id = q.QuestionId,
                            Answers = q.Answers.
                            Where(a => a.SurveyId == 0).
                            Select(a => new Answer
                            {
                                AnswerId = a.AnswerId,
                                OptionId = a.OptionId,
                                QuestionId = a.QuestionId
                            }).ToList(),
                            DependedOptions = q.DependendOptions.
                            Select(h => new DependedOptions()
                            {
                                ParentQuestId = q.DependedQuestionId,
                                SubQuestId = q.QuestionId,
                                ParentQuestionOption = h.DependedOptionId
                            }).ToList(),
                            CategoryTitle = q.Category.CategoryTitle,
                            Description = q.Description,
                            QuestionType = q.TypeId,
                            DependedQuestionDescription = q.Question2.Description,
                            Options = q.Options.Select(f => new Opt()
                            {
                                Id = f.OptionId,
                                QuestionId = f.QuestionId,
                                Text = f.Text,
                                Value = f.Value,
                                IsDefault = f.IsDefault
                            }).ToList(),
                            IsMultipleOption = q.IsMultipleOption,
                            ControlId = q.ControlId,
                            ParentQuestionId = q.DependedQuestionId,
                            SubQuestIds = q.Question1.Select(sq => sq.QuestionId).ToList(),
                        }).OrderBy(q => q.Id).ToList()
                        }).ToListAsync();

                    var resQuest = new SurveyQuest
                    {
                        Id = 0,
                        ControlId = -1,
                        Description = "Anket bitti! \nTeşekkürler!\n Lütfen 'Finish' butonuna basarak anketi kaydediniz",
                        CategoryTitle = "Son",
                        Options = new List<Opt>(),
                        DependedOptions = new List<DependedOptions>(),
                        SubQuestIds = new List<int>(),
                        Answers = new List<Answer>()
                    };

                    var resCat = new Cat() { CatId = 0, Title = "Son", Quests = new List<SurveyQuest> { resQuest } };

                    CategoryWithQuestions.Add(resCat);


                    foreach (var cat in CategoryWithQuestions)
                    {
                        var grp = new ListViewGroup(cat.Title);
                        lstView.Groups.Add(grp);
                        foreach (var q in cat.Quests)
                        {
                            if (q.ParentQuestionId.HasValue == false)
                            {
                                var item = new ListViewItem(q.Id.ToString(), grp);
                                item.SubItems.Add(q.Description);
                                item.Tag = q;
                                lstView.Items.Add(item);
                            }
                        }

                    }

                    if (lstView.Items.Count > 0 && lstView.Items[0].Tag is SurveyQuest quest)
                    {
                        lstView.Items[0].Selected = true;
                    }

                    recolorListItems(lstView);

                    var answers =
                        model.
                        Answers.
                        Include(q => q.Question).
                        Where(f => f.SurveyId == virtualSurvey.Id).
                        ToList();

                    if (answers.Any())
                    {
                        foreach (var a in answers)
                        {
                            var lstItem = FindLstItem(a.QuestionId);

                            if (lstItem != null)
                            {
                                lstItem.Selected = true;
                                if (a.Question.ControlId == (int)OptionControls.RadioButton)
                                {
                                    radioOptions.EditValue = a.OptionId;

                                }
                                else if (a.Question.ControlId == (int)OptionControls.ComboBox)
                                {
                                    comboOptions.SelectedValue = a.OptionId;

                                }
                                else if (a.Question.ControlId == (int)OptionControls.CheckedListBox)
                                {
                                    foreach (CheckedListBoxItem chkItem in checkedListBoxOptions.Items)
                                    {

                                        Console.WriteLine(chkItem?.ToString());

                                        //if (Opt(chkItem)).Id == a.OptionId)
                                        //{
                                        //    chkItem.CheckState = CheckState.Checked;
                                        //}
                                        //else
                                        //{
                                        //    chkItem.CheckState = CheckState.Unchecked;
                                        //}
                                    }

                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private ListViewItem FindLstItem(int questionId)
        {
            for (int i = 0; i < lstView.Items.Count; i++)
            {
                if (lstView.Items[i].Tag is SurveyQuest quest && quest.Id == questionId)
                {
                    lstView.Items[i].Selected = true;
                    return lstView.Items[i];
                }
            }
            return null;
        }

        private static void recolorListItems(ListView lv)
        {
            for (int ix = 0; ix < lv.Items.Count; ++ix)
            {
                var item = lv.Items[ix];
                item.BackColor = (ix % 2 == 0) ? Color.Beige : Color.White;
            }
        }


        private void UpdateUI(SurveyQuest surveyQuest)
        {

            lblCat.Text = surveyQuest.CategoryTitle;
            lblQuestion.Text = surveyQuest.Description;

            radioOptions.Properties.Items.Clear();
            comboOptions.DataSource = null;
            checkedListBoxOptions.DataSource = null;


            layoutControlChecked.Visibility = surveyQuest.ControlId != -1
                ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlCombo.Visibility = surveyQuest.ControlId != -1
                ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlRadio.Visibility = surveyQuest.ControlId != -1
                ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            if (surveyQuest.ControlId == (int)OptionControls.RadioButton)
            {
                emptySpaceItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlRadio.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlCombo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlChecked.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                radioOptions.Properties.Items.AddRange(
                    surveyQuest.
                    Options.
                    Select(f => new RadioGroupItem(f.Id, f.Text)).ToArray());
                if (surveyQuest.Answers.Any() == false)
                {
                    radioOptions.EditValue = surveyQuest.Options.FirstOrDefault(g => g.IsDefault)?.Id ?? -1;
                }
                else
                {
                    radioOptions.EditValue = surveyQuest.Answers.FirstOrDefault().OptionId;
                }
            }
            else if (surveyQuest.ControlId == (int)OptionControls.CheckedListBox)
            {
                emptySpaceItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlRadio.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlCombo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlChecked.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                checkedListBoxOptions.DataSource = surveyQuest.
                    Options.ToList();

                checkedListBoxOptions.DisplayMember = nameof(Opt.Text);
                checkedListBoxOptions.ValueMember = nameof(Opt.Id);

                if (surveyQuest.Answers.Any() == false)
                {
                    checkedListBoxOptions.CheckMember = nameof(Opt.IsDefault);
                }
                else
                {
                    foreach (CheckedListBoxItem item in checkedListBoxOptions.Items)
                    {
                        if (surveyQuest.Answers.Select(a => a.OptionId).Contains(int.Parse(item.Value.ToString())))
                        {
                            item.CheckState = CheckState.Checked;
                        }
                        else
                        {
                            item.CheckState = CheckState.Unchecked;
                        }
                    }
                }
            }
            else if (surveyQuest.ControlId == (int)OptionControls.ComboBox)
            {
                layoutControlRadio.Visibility =
                    DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                emptySpaceItem1.Visibility =
                    DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlCombo.Visibility =
                    DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlChecked.Visibility =
                    DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                comboOptions.DataSource = surveyQuest.
                    Options.ToList();

                comboOptions.DisplayMember = nameof(Opt.Text);
                comboOptions.ValueMember = nameof(Opt.Id);

                if (surveyQuest.Answers.Any() == false)
                {
                    comboOptions.SelectedValue =
                        surveyQuest.Options.FirstOrDefault(f => f.IsDefault)?.Id;
                }
                else
                {
                    comboOptions.SelectedValue =
                        surveyQuest.Answers.FirstOrDefault().OptionId;
                }

            }

        }

        private void btnNext_ClickAsync(object sender, EventArgs e)
        {
            if (CategoryWithQuestions?.Any() == false ||
                lstView.SelectedItems.Count == 0)
            {
                return;
            }
            var currentIndex = lstView.SelectedIndices[0];
            UpdateAnswer();

            if (lstView.Items.Count > currentIndex + 1)
            {
                lstView.Items[currentIndex + 1].Selected = true;
            }

        }

        private void UpdateAnswer()
        {
            var squest = lstView.SelectedItems[0].Tag as SurveyQuest;
            if (squest.ControlId == (int)OptionControls.RadioButton)
            {
                squest.Answers = new List<Answer>()
                {
                    new Answer(){OptionId= int.Parse(radioOptions.EditValue.ToString()),QuestionId=squest.Id }
                };
            }
            else if (squest.ControlId == (int)OptionControls.ComboBox)
            {
                squest.Answers = new List<Answer>()
                {
                    new Answer(){OptionId= int.Parse(comboOptions.SelectedValue.ToString()),QuestionId=squest.Id }
                };
            }
            else if (squest.ControlId == (int)OptionControls.CheckedListBox)
            {
                squest.Answers = checkedListBoxOptions.CheckedItems.Cast<Opt>().
                    Select(f => new Answer() { OptionId = f.Id, QuestionId = f.QuestionId }).ToList();
            }

            if (squest.SubQuestIds.Any())

            {
                var subQuestions = CategoryWithQuestions.
                    SelectMany(f => f.Quests).
                    Where(q => squest.SubQuestIds.Contains(q.Id) == true).ToList();
                var nextIndex = lstView.SelectedItems[0].Index + 1;
                foreach (var sq in subQuestions)
                {
                    var dops = sq.DependedOptions.Select(dop => dop.ParentQuestionOption).ToList();
                    if (dops.Intersect(squest.Answers.Select(a => a.OptionId.Value).ToList()).Any())
                    {
                        if (IsSubQuestionExist(sq.Id) == false)
                        {
                            var newAddedItem = new ListViewItem(sq.Id.ToString(), lstView.SelectedItems[0].Group);
                            newAddedItem.SubItems.Add(sq.Description);
                            newAddedItem.Tag = sq;
                            lstView.Items.Insert(nextIndex, newAddedItem);
                            nextIndex++;
                        }

                    }
                    else
                    {
                        RemoveItemById(sq.Id);
                    }
                }

            }

            recolorListItems(lstView);
            UpdateTreeView();
        }
        public bool IsSubQuestionExist(int sqId)
        {
            foreach (ListViewItem item in lstView.Items)
            {
                if (item.Text == sqId.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public void RemoveItemById(int sqId)
        {
            foreach (ListViewItem item in lstView.Items)
            {
                if (item.Text == sqId.ToString())
                {
                    item.Remove();
                }
            }

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

            if (CategoryWithQuestions?.Any() == false || lstView.SelectedItems.Count == 0) { return; }
            var currentIndex = lstView.SelectedIndices[0];
            UpdateAnswer();

            if (currentIndex - 1 >= 0)
            {
                lstView.Items[currentIndex - 1].Selected = true;
            }
        }


        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node?.Tag is SurveyQuest surveyQuest)
            {
                UpdateUI(surveyQuest);
                lstView.Select();
                lstView.Focus();
            }
        }

        private void treeView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstView.SelectedItems.Count > 0 && lstView.SelectedItems[0].Tag is SurveyQuest surveyQuest)
            {
                UpdateUI(surveyQuest);
                lstView.Select();
                lstView.Focus();
                lstView.SelectedItems[0].Focused = true;
                lstView.SelectedItems[0].EnsureVisible();
                var currentIndex = lstView.SelectedIndices[0];
                btnNext.Enabled = lstView.Items.Count > currentIndex + 1;
                btnPrevious.Enabled = currentIndex > 0;
            }
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateTreeView();
        }

        private void UpdateTreeView()
        {
            foreach (ListViewItem item in lstView.Items)
            {
                if (item.Tag is SurveyQuest s)
                {
                    item.Checked = s.Answers.Any();
                }
            }
        }

        private async void btnFinish_Click(object sender, EventArgs e)
        {

            try
            {
                if (CategoryWithQuestions.SelectMany(f => f.Quests).Any(f => f.Answers.Count > 0))
                {

                    var res = MessageBox.Show(
                              "Anketi bitirip var olan bilgileri kaydetmek istiyor musunuz?",
                              virtualSurvey.SurveyList.SurveyName,
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (res == DialogResult.Yes)
                    {
                        var lst = lstView.Items.Cast<ListViewItem>().ToList().Take(lstView.Items.Count - 1);
                        ListViewItem listViewItem = null;

                        foreach (ListViewItem item in lst)
                        {

                            if ((item.Tag is SurveyQuest quest && quest.Answers.Any() == false) || item.Checked == false)
                            {

                                listViewItem = item;
                                break;

                            }

                        }

                        if (listViewItem != null)
                        {

                            if (MessageBox.Show("İşaretlenmeyen sorular var. Eksik olarak göndermek istiyor musunuz?",
                                                          virtualSurvey.SurveyList.SurveyName,
                                                          MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                                if (await SaveSurvey(true))
                                {
                                    SplashScreenManager.CloseForm();
                                    Close();
                                }
                            }
                            else
                            {
                                listViewItem.Selected = true;
                            }
                        }
                        else
                        {
                            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                            if (await SaveSurvey(true))
                            {
                                SplashScreenManager.CloseForm();
                                Close();
                            }
                            else
                            {
                                SplashScreenManager.CloseForm();
                                MessageBox.Show("Anket kaydedilemedi. Lütfen tekrar deneyiniz.");
                              
                            }
                        }


                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata oluştu:\n" + ex.Message);
            }

        }
        private async Task<bool> SaveSurvey(bool isSubmitted)
        {
            if (virtualSurvey.Id == 0)//insert
            {
                try
                {
                    using (var m = new Model())
                    {
                        var sur = new Survey()
                        {
                            SurveyListId = virtualSurvey.SurveyListId,
                            PollsterId = virtualSurvey.PollsterId,
                            SurveyDate = DateTime.Now,
                            PatientId = virtualSurvey.PatientId,
                            SessionId = virtualSurvey.SessionId
                        };

                        var answers = new List<TeetSurvey.Repository.Model.Answer>();

                        foreach (ListViewItem item in lstView.Items)
                        {
                            if (item.Tag is SurveyQuest quest && quest.Id > 0)
                            {
                                answers = quest.Answers.Select(f => new TeetSurvey.Repository.Model.Answer()
                                {
                                    OptionId = f.OptionId,
                                    QuestionId = f.QuestionId,

                                }).ToList();

                                foreach (var a in answers)
                                {
                                    sur.Answers.Add(a);
                                }

                            }
                        }

                        sur.IsSubmitted = isSubmitted;
                        sur.IsCompleted = true;
                        foreach (ListViewItem item in lstView.Items)
                        {
                            if ((item.Tag is SurveyQuest sq && sq.Answers.Any() == false) || item.Checked == false)
                            {
                                sur.IsCompleted = false;
                            }
                        }


                        var addedSurvey = m.Surveys.Add(sur);
                        var save = await m.SaveChangesAsync();
                        return save > 0;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                using (var m = new Model())
                {
                    var existSurvey = m.Surveys.FirstOrDefault(f => f.Id == virtualSurvey.Id);

                    if (existSurvey != null)
                    {
                        m.Answers.RemoveRange(m.Answers.Where(f => f.SurveyId == existSurvey.Id).ToList());

                        var answers = new List<TeetSurvey.Repository.Model.Answer>();

                        foreach (ListViewItem item in lstView.Items)
                        {
                            if (item.Tag is SurveyQuest quest && quest.Id > 0)
                            {
                                answers = quest.Answers.Select(f => new TeetSurvey.Repository.Model.Answer()
                                {
                                    OptionId = f.OptionId,
                                    QuestionId = f.QuestionId,

                                }).ToList();

                                foreach (var a in answers)
                                {
                                    existSurvey.Answers.Add(a);
                                }

                            }
                        }

                        existSurvey.IsSubmitted = isSubmitted;
                        existSurvey.IsCompleted = CategoryWithQuestions.SelectMany(c => c.Quests).Count(f => f.ControlId > -1) == existSurvey.Answers.Count;
                        var save = await m.SaveChangesAsync();
                        return save > 0;

                    }
                }
            }
            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (CategoryWithQuestions.SelectMany(f => f.Quests).Any(f => f.Answers.Count > 0))
            {
                var res = MessageBox.Show(
                          "İptal etmek istediğinizde emin misiniz?",
                       virtualSurvey.SurveyList.SurveyName,
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    Close();
                }
            }
        }
    }
}