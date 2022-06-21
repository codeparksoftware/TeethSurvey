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
            this.Text = SingleService.Instance.Survey.SurveyName +
                " [ " + SingleService.Instance.Survey.Pollster + " ] ";
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
                            }).ToList(),
                            DependedOptions = q.DependendOptions.
                            Select(h => new DependedOptions()
                            {
                                ParentQuestId = q.DependedQuestionId,
                                SubQuestId = q.QuestionId,
                                ParentQuestionOptions = q.DependendOptions.Select(o => o.DependedOptionId).ToList(),
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
            public List<DependedOptions> DependedOptions { get; set; }
            public bool IsSubQuestion => ParentQuestionId.HasValue;
        }

        public class DependedOptions
        {
            public int SubQuestId { get; set; }
            public int? ParentQuestId { get; set; }
            public List<int> ParentQuestionOptions { get; set; }
        }


        private void UpdateUI(SurveyQuest surveyQuest)
        {

            lblCat.Text = surveyQuest.CategoryTitle;
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


        private async void btnNext_ClickAsync(object sender, EventArgs e)
        {
            if (CategoryWithQuestions?.Any() == false) { return; }

            qIndex++;
            if (CategoryWithQuestions[catIndex].Quests.Count <= qIndex)
            {
                qIndex = 0;
                catIndex++;
            }

            if (CategoryWithQuestions.Count == catIndex)
            {

                var res = MessageBox.Show(
                      "Anket bitmiştir teşekkürler. Anketi bilgilerini kaydetmek istiyor musunuz?",
                      SingleService.Instance.Survey.SurveyName,
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    if (await SaveSurvey())
                    {
                        btnNext.Visible = false;
                        btnCancel.Visible = false;
                    }
                }
                return;
            }

            UpdateUI(CategoryWithQuestions[catIndex].Quests[qIndex]);

        }

        private async Task<bool> SaveSurvey()
        {
            await Task.Delay(1000);
            return true;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

            if (CategoryWithQuestions?.Any() == false) { return; }
            if (0 == catIndex && 0 == qIndex)
            {
                return;

            }


            qIndex--;
            if (qIndex < 0)
            {
                catIndex--;
                qIndex = CategoryWithQuestions[catIndex].Quests.Count - 1;
            }
            UpdateUI(CategoryWithQuestions[catIndex].Quests[qIndex]);


        }
    }
}