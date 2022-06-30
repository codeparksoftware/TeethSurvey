using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeetSurvey.Repository.Model;
using static Sample.InsertForm;

namespace Sample
{
    public partial class SurveyWizardForm : DevExpress.XtraEditors.XtraForm
    {
        public List<Cat> CategoryWithQuestions { get; set; }

        public SurveyWizardForm()
        {
            InitializeComponent();
            this.Text = SingleService.Instance.Survey.SurveyList.SurveyName +
                " [ " + SingleService.Instance.Survey.Pollster.Name + " ] ";

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
                        && c.SurveyListId == SingleService.Instance.Survey.SurveyListId).
                        Select(c => new Cat()
                        {
                            CatId = c.CategoryId,
                            Title = c.CategoryTitle,
                            Quests = c.Questions.
                        Select(q => new SurveyQuest()
                        {
                            Id = q.QuestionId,
                            Answers = q.Answers.
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
                }
            
                //var first = CategoryWithQuestions.FirstOrDefault();
                //var firstQ = first?.Quests.FirstOrDefault();
                //if (firstQ != null)
                //{
                //    UpdateUI(firstQ);
                //}

                foreach (var cat in CategoryWithQuestions)
                {
                    var grp = new ListViewGroup(cat.Title);
                    treeView1.Groups.Add(grp);
                    foreach (var q in cat.Quests)
                    {
                        if (q.ParentQuestionId.HasValue == false)
                        {
                            var item = new ListViewItem(q.Id.ToString(), grp);
                            item.SubItems.Add(q.Description);
                            item.Tag = q;
                            treeView1.Items.Add(item);
                        }
                    }

                }

                if (treeView1.Items.Count > 0 && treeView1.Items[0].Tag is SurveyQuest quest)
                {
                    treeView1.Items[0].Selected = true;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        void FillTreeView(TreeNode parent, List<int> questIds)
        {

            var quests = CategoryWithQuestions.SelectMany(f => f.Quests).Where(g => questIds.Contains(g.Id)).ToList();
            foreach (var q in quests)
            {
                var parentNode = parent.Nodes.Add(q.Id.ToString(), q.Description + "...");

                parentNode.Tag = q;
                if (q.SubQuestIds?.Any() == true)
                {
                    FillTreeView(parentNode, q.SubQuestIds);
                }
            }
        }

        public class Answer
        {
            public int AnswerId { get; set; }
            public int QuestionId { get; set; }
            public int? OptionId { get; set; }
        }


        public class Cat
        {
            public int CatId { get; set; }
            public string Title { get; set; }
            public List<SurveyQuest> Quests { get; set; }
        }
        public class SurveyQuest
        {

            public int Id { get; set; }
            public string CategoryTitle { get; set; }
            public string Description { get; set; }
            public int QuestionType { get; set; }
            public string DependedQuestionDescription { get; set; }
            public List<int> SubQuestIds { get; set; }
            public int? ParentQuestionId { get; set; }
            public List<Opt> Options { get; set; }
            public bool IsMultipleOption { get; set; }
            public int ControlId { get; set; }
            public List<Answer> Answers { get; set; }
            public List<DependedOptions> DependedOptions { get; set; }
            public bool IsSubQuestion => ParentQuestionId.HasValue;
            public bool IsRootQuestion => !ParentQuestionId.HasValue;

        }

        public class DependedOptions
        {
            public int SubQuestId { get; set; }
            public int? ParentQuestId { get; set; }
            public int ParentQuestionOption { get; set; }
        }

        private void UpdateUI(SurveyQuest surveyQuest)
        {

            lblCat.Text = surveyQuest.CategoryTitle;
            lblQuestion.Text = surveyQuest.Description;

            radioOptions.Properties.Items.Clear();
            comboOptions.DataSource = null;
            checkedListBoxOptions.DataSource = null;

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

                layoutControlRadio.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                emptySpaceItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlCombo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlChecked.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                comboOptions.DataSource = surveyQuest.
                    Options.ToList();

                comboOptions.DisplayMember = nameof(Opt.Text);
                comboOptions.ValueMember = nameof(Opt.Id);

                if (surveyQuest.Answers.Any() == false)
                {
                    comboOptions.SelectedValue = surveyQuest.Options.FirstOrDefault(f => f.IsDefault)?.Id;
                }
                else
                {
                    comboOptions.SelectedValue = surveyQuest.Answers.FirstOrDefault().OptionId;
                }


            }




        }


        private int _catIndex = 0;
        public int catIndex
        {
            get => _catIndex;
            set
            {
                _catIndex = value;

            }
        }
        int qIndex = 0;


        private void btnNext_ClickAsync(object sender, EventArgs e)
        {
            if (CategoryWithQuestions?.Any() == false || treeView1.SelectedItems.Count == 0) { return; }
            var node = treeView1.SelectedItems[0];
            UpdateAnswer();
            if (treeView1.Items.Count > node.Index + 1)
            {
                treeView1.Items[node.Index + 1].Selected = true;
            }




            //qIndex++;
            //if (CategoryWithQuestions[catIndex].Quests.Count <= qIndex)
            //{
            //    qIndex = 0;
            //    catIndex++;
            //}

            //if (CategoryWithQuestions.Count == catIndex)
            //{

            //    var res = MessageBox.Show(
            //          "Anket bitmiştir teşekkürler. Anketi bilgilerini kaydetmek istiyor musunuz?",
            //          SingleService.Instance.Survey.SurveyList.SurveyName,
            //           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (res == DialogResult.Yes)
            //    {
            //        if (await SaveSurvey())
            //        {
            //            btnNext.Visible = false;
            //            btnCancel.Visible = false;
            //        }
            //    }
            //    return;
            //}



        }

        private void UpdateAnswer()
        {
            var squest = treeView1.SelectedItems[0].Tag as SurveyQuest;
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

                foreach (var sq in subQuestions)
                {
                    var dops = sq.DependedOptions.Select(dop => dop.ParentQuestionOption).ToList();
                    if (dops.Intersect(squest.Answers.Select(a => a.OptionId.Value).ToList()).Any() &&
                        treeView1.Items.Find(sq.Id.ToString(), false).Count() == 0)
                    {
                        var newAddedItem = new ListViewItem(sq.Id.ToString(), treeView1.SelectedItems[0].Group);
                        newAddedItem.SubItems.Add(sq.Description);
                        newAddedItem.Tag = sq;
                        treeView1.Items.Insert(treeView1.SelectedItems[0].Index + 1, newAddedItem);

                    }
                    else
                    {
                        var removedSubNode = treeView1.Items.Find(sq.Id.ToString(), true);
                        if (removedSubNode != null)
                        {
                            treeView1.Items.RemoveByKey(sq.Id.ToString());
                        }
                    }
                }

            }
        }

        private async Task<bool> SaveSurvey()
        {
            await Task.Delay(1000);
            return true;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

            if (CategoryWithQuestions?.Any() == false || treeView1.SelectedItems.Count == 0) { return; }
            UpdateAnswer();


            //if (0 == catIndex && 0 == qIndex)
            //{
            //    return;

            //}


            //qIndex--;
            //if (qIndex < 0)
            //{
            //    catIndex--;
            //    qIndex = CategoryWithQuestions[catIndex].Quests.Count - 1;
            //}
            //UpdateUI(CategoryWithQuestions[catIndex].Quests[qIndex]);


        }


        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node?.Tag is SurveyQuest surveyQuest)
            {
                UpdateUI(surveyQuest);
                treeView1.Select();
                treeView1.Focus();
            }
        }

        private void treeView1_SelectedNodeChanged(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (treeView1.SelectedItems.Count > 0 && treeView1.SelectedItems[0].Tag is SurveyQuest surveyQuest)
            {
                UpdateUI(surveyQuest);
                treeView1.Select();
                treeView1.Focus();
            }
        }
    }
}