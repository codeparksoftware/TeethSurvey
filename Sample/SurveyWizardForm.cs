using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
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
                        Where(c => c.Questions.Count > 0).
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
                            }).
                                ToList(),
                            CategoryTitle = q.Category.CategoryTitle,
                            Description = q.Description,
                            QuestionType = q.TypeId,
                            DependedQuestionDescription = q.Question2.Description,
                            Options = q.Options.Select(f => new Opt()
                            {
                                Id = f.OptionId,
                                QuestionId = f.QuestionId,
                                Text = f.Text,
                                Value = f.Value
                            }).ToList(),
                            IsMultipleOption = q.IsMultipleOption,
                            ControlId = q.ControlId,
                            ParentQuestionId = q.DependedQuestionId
                        }).OrderBy(q => q.Id).ToList()
                        }).ToListAsync();
                }
                var first = CategoryWithQuestions.FirstOrDefault();
                var firstQ = first.Quests.FirstOrDefault();
                UpdateUI(firstQ);
            }
            finally
            {
                SplashScreenManager.CloseForm(false);

            }
        }

        public class Answer
        {
            public int AnswerId { get; set; }
            public int QuestionId { get; set; }
            public int OptionId { get; set; }
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
            public List<SurveyQuest> SubQuests { get; set; }
            public int? ParentQuestionId { get; set; }
            public List<Opt> Options { get; set; }
            public bool IsMultipleOption { get; set; }
            public int ControlId { get; set; }
            public List<Answer> Answers { get; set; }
        }
        int catIndex = 0;
        int qIndex = 0;
        bool isFinished = false;
        private void wizardControl1_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            if (wizardControl1.SelectedPage == wizardPage1)
            {
                e.Handled = true;
                if (CategoryWithQuestions?.Any() == false) { return; }
                if (isFinished == false)
                {
                    UpdateUI(CategoryWithQuestions[catIndex].Quests[qIndex]);
                    qIndex++;
                    if (CategoryWithQuestions[catIndex].Quests.Count <= qIndex)
                    {
                        qIndex = 0;
                        catIndex++;
                    }
                }
                if (CategoryWithQuestions.Count == catIndex)
                {
                    isFinished = true;
                    System.Windows.Forms.MessageBox.Show("Anket bitmiştir teşekkürler");
                }
            }

        }

        private void UpdateUI(SurveyQuest surveyQuest)
        {

            wizardPage1.Text = surveyQuest.CategoryTitle;
            lblQuestion.Text = surveyQuest.Description;
            radioOptions.Properties.Items.Clear();
            comboOptions.Items.Clear();
            checkedListBoxOptions.Items.Clear();

            if (surveyQuest.ControlId == (int)OptionControls.RadioButton)
            {
                layoutControlRadio.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlCombo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlChecked.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                radioOptions.Properties.Items.AddRange(
                    surveyQuest.
                    Options.
                    Select(f => new RadioGroupItem(f.Id, f.Text)).ToArray());
            }
            else if (surveyQuest.ControlId == (int)OptionControls.CheckedListBox)
            {

                layoutControlRadio.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlCombo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlChecked.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                checkedListBoxOptions.Items.AddRange(
                    surveyQuest.
                    Options.
                    Select(f => new RadioGroupItem(f.Id, f.Text)).ToArray());
            }
            else if (surveyQuest.ControlId == (int)OptionControls.ComboBox)
            {

                layoutControlRadio.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlCombo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlChecked.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                comboOptions.Items.AddRange(
                    surveyQuest.
                    Options.
                    Select(f => new RadioGroupItem(f.Id, f.Text)).ToArray());
            }
        }

        private void wizardControl1_PrevClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            if (wizardControl1.SelectedPage == wizardPage1)
            {
                e.Handled = true;
                if (CategoryWithQuestions?.Any() == false) { return; }
                if (0 == catIndex && 0 == qIndex)
                {
                    return;

                }
                if (isFinished == false)
                {
                    UpdateUI(CategoryWithQuestions[catIndex].Quests[qIndex]);
                    qIndex--;
                    if (0 < qIndex)
                    {
                        catIndex--;
                        qIndex = CategoryWithQuestions[catIndex].Quests.Count - 1;
                    }
                }
            }

        }
    }
}