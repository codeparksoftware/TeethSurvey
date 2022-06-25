using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraSplashScreen;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeethSurvey.Extensions;
using TeetSurvey.Repository.Model;

namespace Sample
{
    public partial class frmAdmin : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Survey Survey;
        private List<Quest> Quests { get; set; }
        public static List<OptionControl> GetOptionControls => new List<OptionControl>() {
            new OptionControl{
               Text= nameof(OptionControls.RadioButton),
               Id=(int)OptionControls.RadioButton        },
            new OptionControl{
               Text= nameof(OptionControls.CheckedListBox),
               Id=(int)OptionControls.CheckedListBox},
            new OptionControl{
               Text= nameof(OptionControls.ComboBox),
               Id=(int)OptionControls.ComboBox} };

        public frmAdmin()
        {
            InitializeComponent();
            colCat.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
        }

        private async void frmAdmin_LoadAsync(object sender, EventArgs e)
        {
            await InitMainPage();
        }

        private async Task InitMainPage()
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                await Task.Run(() =>
                {
                    using (var m = new Model())
                    {
                        var totalSurveyFuture = m.Surveys.FutureCount();
                        var totalQuestFuture = m.Questions.FutureCount();
                        txtAnketNumber.Invoke((Action)(() =>
                        {
                            txtAnketNumber.Text = totalSurveyFuture.Value.ToString();
                        }));
                        txtQuestionNumber.Invoke((Action)(() =>
                        txtQuestionNumber.Text = totalQuestFuture.Value.ToString()));
                    }
                });
            }
            finally
            {
                SplashScreenManager.CloseForm(false);

            }
        }

        private async Task InitAnketQuestion()
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                await DataLoad();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private async Task DataLoad()
        {
            await Task.Run(() =>
            {
                using (var ctx = new Model())
                {
                    var questionFuture = ctx.Questions.AsNoTracking().Future();
                    var surveyFuture = ctx.Surveys.AsNoTracking().Future();
                    var surveynameFuture =
                    ctx.Surveys.AsNoTracking().
                    Where(f => f.SurveyName != null).Future();



                    var questions = questionFuture.ToList();
                    var surveys = surveyFuture.ToList();
                    var surveynames = surveynameFuture.ToList();


                    Quests = questions.Select(f => CreateQuest(f, questions)).ToList();
                    gridControl1.Invoke(new Action(() =>
                    {
                        gridControl1.DataSource = Quests;
                    }));

                    cmbPollster.DataSource = surveys.DistinctBy(f => f.Pollster).ToList();
                    cmbPollster.DisplayMember = nameof(Survey.Pollster);


                    cmbSurcveys.DataSource = surveynames.DistinctBy(f => f.SurveyName).ToList();
                    cmbSurcveys.DisplayMember = nameof(Survey.SurveyName);
                }
            });
        }

        public static Quest CreateQuest(Question q, List<Question> questions)
        {
            var quest = new Quest
            (
               q.QuestionId,
                 q.Category.CategoryTitle,
                q.Description,
                q.TypeId,
                q.Question2?.Description,
                questions.
                Where(f => f.DependedQuestionId == q.QuestionId).
                Select(f => CreateQuest(f, questions)).ToList(),
                 q.Options?.Select(f => new Opt()
                 {
                     Id = f.OptionId,
                     QuestionId = f.QuestionId,
                     Text = f.Text,
                     Value = f.Value,
                     IsDefault = f.IsDefault
                 }).ToList(),
                 q.IsMultipleOption,
                 q.ControlId, q.DependedQuestionId);

            return quest;
        }

        private void gridView1_FocusedRowChanged(
            object sender,
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            var row = tileView1.GetFocusedRow();
            rgOption.Properties.Items.Clear();
            checkedListBoxOptions.Items.Clear();
            comboBoxOptions.DataSource = null;

            if (row is Quest q)
            {
                rightPanel.Visible = true;
                lblCategoryOnOption.Text = q.CategoryTitle;
                lblQuestionOnOption.Text = q.Description;
                lblDependedQuestionOnOption.Text = q.DependedQuestionDescription;
                chkIsMultiple.Checked = q.IsMultipleOption;

                layoutControlItem2.Visibility = string.IsNullOrWhiteSpace(
                    q.DependedQuestionDescription) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never :
                    DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                if (q.ControlId == (int)OptionControls.ComboBox)
                {
                    layoutControlItemCombo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItemChecked.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlItemRadio.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                }
                else if (q.ControlId == (int)OptionControls.CheckedListBox)
                {
                    layoutControlItemCombo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlItemChecked.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItemRadio.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                else if (q.ControlId == (int)OptionControls.RadioButton)
                {
                    layoutControlItemCombo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlItemChecked.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlItemRadio.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                var defaultOpt = q.Options.FirstOrDefault(f => f.IsDefault)?.Id;

                checkedListBoxOptions.Items.
                    AddRange(q.Options.
                    Select(f => new CheckedListBoxItem(f.Text, f.IsDefault)).ToArray());


                comboBoxOptions.DataSource = q.Options;
                comboBoxOptions.DisplayMember = nameof(Opt.Text);
                comboBoxOptions.ValueMember = nameof(Opt.Id);
                comboBoxOptions.SelectedValue = defaultOpt;

                rgOption.Properties.Items.
                    AddRange(
                    q.
                    Options.
                    Select(f => new RadioGroupItem(f.Id, f.Text)).ToArray());

                rgOption.EditValue =
                rgOption.Properties.Items.
                    FirstOrDefault(f => f.Value.ToString() == defaultOpt?.ToString())?.Value;
            }
            else
            {
                rightPanel.Visible = false;
            }

        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            using (var m = new Model())
            {

                var patient = m.Patients.Add(new Patient()
                {
                    EnrollDate = enrollDate.Value,
                    PatientName = txtName.Text,
                    PatientSurname = txtSurname.Text,
                    PatientTCKN = txtTCKN.Text
                });
                var sId = cmbSurcveys.SelectedValue?.ToString();
                var sur = m.Surveys.FirstOrDefault(f =>
                f.SurveyId.ToString() == sId);
                if (sur == null)
                {
                    sur = new Survey()
                    {
                        SurveyName = cmbSurcveys.Text,
                        Pollster = cmbPollster.Text,
                        SurveyDate = DateTime.Now,
                        Patient = patient
                    };

                    m.Surveys.Add(sur);
                    await m.SaveChangesAsync();
                }

                else
                {
                    sur.Patient = patient;
                    m.Entry(sur).State = EntityState.Modified;
                    await m.SaveChangesAsync();
                }
                Survey = m.Surveys.FirstOrDefault(f => f.SurveyId == sur.SurveyId);
                SingleService.Instance.Survey = Survey;
            }
            var surveyform = new SurveyWizardForm();
            surveyform.ShowDialog();

        }

        private async void barButtonItem1_ItemClick(
            object sender,
            DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var insert = new InsertForm(null);
            if (insert.ShowDialog() == DialogResult.OK)
            {
                await DataLoad();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cat = new Categories();
            cat.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tileView1.GetFocusedRow() is Quest quest)
            {
                var qId = quest.Id;
                var frm = new InsertForm(qId);
                frm.ShowDialog();
            }
        }

        private void tileView1_ContextButtonClick(object sender, DevExpress.Utils.ContextItemClickEventArgs e)
        {
            if (e.Item.Name == "cbEdit")
            {
                if (e.DataItem is TileViewItem item && tileView1.GetRow(item.RowHandle) is Quest quest)
                {
                    var qId = quest.Id;
                    var frm = new InsertForm(qId);
                    frm.ShowDialog();
                }
            }
        }

        private async void navigationFrame1_SelectedPageChanged(
            object sender,
            DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            if (navigationFrame1.SelectedPage == manageSurvey)
            {
                if (Quests is null || Quests?.Any() == false)
                {
                    await InitAnketQuestion();
                }
                anketYonetimGroup.Visible = true;
            }
            if (navigationFrame1.SelectedPage == mainPage)
            {
                anketYonetimGroup.Visible = false;
            }
            if (navigationFrame1.SelectedPage == takeSurvey)
            {
                await InitTakeSurvey();
            }

        }

        private async Task InitTakeSurvey()
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                await Task.Run(() =>
                {
                    using (var ctx = new Model())
                    {

                        var surveyFuture = ctx.Surveys.AsNoTracking().Future();
                        var surveynameFuture =
                        ctx.Surveys.AsNoTracking().
                        Where(f => f.SurveyName != null).Future();

                        var surveys = surveyFuture.ToList();
                        var surveynames = surveynameFuture.ToList();

                        cmbPollster.Invoke((Action)(() =>
                        {
                            cmbPollster.DataSource = surveys.DistinctBy(f => f.Pollster).ToList();
                            cmbPollster.DisplayMember = nameof(Survey.Pollster);
                        }));

                        cmbSurcveys.Invoke((Action)(() =>
                        {

                            cmbSurcveys.DataSource = surveynames.DistinctBy(f => f.SurveyName).ToList();
                            cmbSurcveys.DisplayMember = nameof(Survey.SurveyName);
                            cmbSurcveys.ValueMember = nameof(Survey.SurveyId);
                        }));

                    }
                });

            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private async void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (navigationFrame1.SelectedPage == manageSurvey)
            {
                await InitAnketQuestion();
            }
            else if (navigationFrame1.SelectedPage == mainPage)
            {
                await InitMainPage();
            }
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {

        }
    }



}
