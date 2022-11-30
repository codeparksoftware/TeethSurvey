using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraSplashScreen;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeetSurvey.Repository.Model;

namespace Sample
{
    public partial class frmAdmin : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private List<Quest> Quests { get; set; }
        private List<SurveyView> SavedSurveys { get; set; }
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
        public List<SurveyList> SurveyLists { get; set; }
        private async Task InitMainPage()
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

                using (var m = new Model())
                {
                    SurveyLists = await m.SurveyLists.ToListAsync();
                    surveyListlookUp.DataSource = SurveyLists;
                    surveyListlookUp.DisplayMember = nameof(SurveyList.SurveyName);
                    surveyListlookUp.ValueMember = nameof(SurveyList.Id);
                    var firstId = SurveyLists.First()?.Id;
                    barEditItem.EditValue = 0;//trick to trig reload taken survey
                    if (firstId.HasValue)
                    {
                        barEditItem.EditValue = firstId.Value;
                    }
                    //var surveys = await m.Surveys.
                    //    Select(f =>
                    //   new SurveyView()
                    //   {
                    //       Patient = f.Patient.PatientName,
                    //       Pollster = f.Pollster.Name,
                    //       SurveyId = f.Id,
                    //       SurveyDate = f.SurveyDate,
                    //       SurveyName = f.SurveyList.SurveyName,
                    //       IsSubmitted = f.IsSubmitted,
                    //       SessionId = f.SessionId,
                    //       Questions = f.Answers.Select(a => new AnsweredQuestion()
                    //       {
                    //           AnswerOptionDesc = a.Option.Text,
                    //           CategoryTitle = a.Question.Category.CategoryTitle,
                    //           QuestionDesc = a.Question.Description,
                    //           QuestionId = a.QuestionId
                    //       }).ToList()
                    //   }).ToListAsync();
                    //  var surveys = await m.Answers.Select(f => new PivotSurvey
                    //  {
                    //      Answer = f.Option.Text,
                    //      Category = f.Question.Category.CategoryTitle,
                    //      Question = f.Question.Description,
                    //      SurveyId = f.SurveyId

                    //  }).ToListAsync();
                    ////  SavedSurveys = surveys;
                    //  gridSurveys.DataSource = surveys;

                    //if (surveys.Count > 0 && gridResult.GetFocusedRow() == null)
                    //{
                    //    gridResult.MoveFirst();
                    //    UpdateResultGrid();
                    //}

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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

            using (var ctx = new Model())
            {
                var questions =
                    await ctx.Questions.
                    Include(f => f.Category).
                    Include(f => f.Options).
                    Include(f => f.DependendOptions).
                    AsNoTracking().
                    ToListAsync();


                Quests = questions.
                    Select(f => CreateQuest(f, questions)).
                    ToList();

                gridControl1.Invoke(new Action(() =>
                {
                    gridControl1.DataSource = Quests;
                }));
            }

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
                if (defaultOpt != null)
                {
                    comboBoxOptions.SelectedValue = defaultOpt;
                }
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

        private void btnStart_Click(object sender, EventArgs e)
        {

            if (cmbSurveys.SelectedIndex < 0 ||
                int.TryParse(cmbSurveys.SelectedValue?.ToString(), out var sId) == false)
            {
                return;
            }
            if (cmbPollster.SelectedIndex < 0 ||
               int.TryParse(cmbPollster.SelectedValue?.ToString(), out var pId) == false)
            {
                return;
            }
            if (cmbPatients.SelectedIndex < 0 ||
              int.TryParse(cmbPatients.SelectedValue?.ToString(), out var paId) == false)
            {
                return;
            }
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            using (var m = new Model())
            {

                if (m.Questions.Any(f => f.Category.SurveyListId == sId) == false)
                {
                    MessageBox.Show("Bu Ankete ait hiç soru bulunmamaktadır");

                    SplashScreenManager.CloseForm();
                    return;
                }

                var sur = new Survey()
                {
                    SurveyListId = sId,
                    PollsterId = pId,
                    SurveyDate = DateTime.Now,
                    PatientId = paId,
                    SessionId = m.Surveys.Count(f => f.PatientId == paId && f.SurveyListId == sId) + 1//auto calculated
                };

                sur.SurveyList =
                    m.SurveyLists.
                    AsNoTracking().
                    FirstOrDefault(f =>
                    f.Id.ToString() == cmbSurveys.SelectedValue.ToString());

                sur.Pollster =
                    m.
                    Pollsters.
                    FirstOrDefault(f => f.Id.ToString() == cmbPollster.SelectedValue.ToString());

                var wizard = new SurveyWizardForm(sur);
                wizard.ShowDialog();
            }
        }

        private async void barButtonItem1_ItemClick(
            object sender,
            DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var insert = new InsertForm(null);
            if (insert.ShowDialog() == DialogResult.OK)
            {
                await InitAnketQuestion();
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

        private async void tileView1_ContextButtonClick(object sender, DevExpress.Utils.ContextItemClickEventArgs e)
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
            if (e.Item.Name == "cbSil")
            {
                if (e.DataItem is TileViewItem item && tileView1.GetRow(item.RowHandle) is Quest quest)
                {
                    await SilSoru(quest);
                }

            }
        }

        async Task SilSoru(Quest quest)
        {
            var confirm = MessageBox.Show(
                quest.Description + " \n sorusu silinecektir. Emin misiniz?",
                "Soru Silme",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (var m = new Model())
                    {
                        var qId = quest.Id;
                        var IsAnswerExist = m.Answers.Any(f => f.QuestionId == qId);
                        var isDepended = m.Questions.Any(f => f.DependedQuestionId == qId);
                        if (isDepended || IsAnswerExist)
                        {
                            var res = MessageBox.Show("Bu soruya ait cevap ya da altsorular bulunmaktadır.\n" +
                                "Silmeniz durumunda alt sorular da silinecektir" +
                                "\nYine de silmek istiyor musunuz?", "Soru Sil",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (res == DialogResult.Yes)
                            {
                                await RemoveChildren(m, qId);
                                m.Questions.RemoveRange(m.Questions.Where(f => f.DependedQuestionId == qId).ToList());
                                m.Answers.RemoveRange(m.Answers.Where(f => f.QuestionId == qId).ToList());
                                m.Options.RemoveRange(m.Options.Where(f => f.QuestionId == qId).ToList());
                                m.DependendOptions.RemoveRange(m.DependendOptions.Where(f => f.QuestionId == qId).ToList());

                                await m.SaveChangesAsync();
                                m.Questions.Remove(m.Questions.First(f => f.QuestionId == qId));
                                await m.SaveChangesAsync();
                                await InitAnketQuestion();
                            }
                            else
                            {
                                return;
                            }

                        }
                        else
                        {
                            m.Options.RemoveRange(m.Options.Where(f => f.QuestionId == qId).ToList());
                            m.Questions.Remove(m.Questions.First(f => f.QuestionId == qId));
                            await m.SaveChangesAsync();
                            await InitAnketQuestion();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        async Task RemoveChildren(Model m, int id)
        {

            var children = await m.Questions.Where(c => c.DependedQuestionId == id).ToListAsync();
            foreach (var child in children)
            {
                await RemoveChildren(m, child.QuestionId);
                m.Questions.Remove(child);
                m.Answers.RemoveRange(m.Answers.Where(f => f.QuestionId == child.QuestionId).ToList());
                m.Options.RemoveRange(m.Options.Where(f => f.QuestionId == child.QuestionId).ToList());
                m.DependendOptions.RemoveRange(m.DependendOptions.Where(f => f.QuestionId == child.QuestionId).ToList());
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

                        var surveyListFuture = ctx.SurveyLists.AsNoTracking().Future();
                        var pollsterFuture =
                        ctx.Pollsters.AsNoTracking().Future();
                        var patientFuture = ctx.Patients.AsNoTracking().Future();

                        var surveyList = surveyListFuture.ToList();
                        var pollster = pollsterFuture.ToList();
                        var patients = patientFuture.ToList();

                        cmbPollster.Invoke((Action)(() =>
                        {
                            cmbPollster.DataSource = pollster;
                            cmbPollster.DisplayMember = nameof(Pollster.Name);
                            cmbPollster.ValueMember = nameof(Pollster.Id);
                        }));

                        cmbSurveys.Invoke((Action)(() =>
                        {

                            cmbSurveys.DataSource = surveyList;
                            cmbSurveys.DisplayMember = nameof(SurveyList.SurveyName);
                            cmbSurveys.ValueMember = nameof(SurveyList.Id);
                        }));
                        cmbPatients.Invoke((Action)(() =>
                        {
                            cmbPatients.DataSource = patients;
                            cmbPatients.DisplayMember = nameof(Patient.FullName);
                            cmbPatients.ValueMember = nameof(Patient.PatientId);
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
            else if (navigationFrame1.SelectedPage == takeSurvey)
            {
                await InitTakeSurvey();
            }
        }

        private async void btnAddPollster_Click(object sender, EventArgs e)
        {
            var pollsterAdd = new NewPollster();
            if (pollsterAdd.ShowDialog() == DialogResult.OK)
            {
                using (var ctx = new Model())
                {
                    var pollster = await ctx.Pollsters.ToListAsync();

                    cmbPollster.Invoke((Action)(() =>
                    {
                        cmbPollster.DataSource = pollster;
                        cmbPollster.DisplayMember = nameof(Pollster.Name);
                        cmbPollster.ValueMember = nameof(Pollster.Id);
                    }));
                    cmbPollster.SelectedValue = pollsterAdd.Result;
                }
            }
        }

        private async void btnAddAnket_Click(object sender, EventArgs e)
        {
            var surveyListAdd = new NewSurveyForm();
            if (surveyListAdd.ShowDialog() == DialogResult.OK)
            {
                using (var ctx = new Model())
                {
                    var surveyList = await ctx.SurveyLists.ToListAsync();

                    cmbSurveys.Invoke((Action)(() =>
                    {

                        cmbSurveys.DataSource = surveyList;
                        cmbSurveys.DisplayMember = nameof(SurveyList.SurveyName);
                        cmbSurveys.ValueMember = nameof(SurveyList.Id);
                    }));
                    cmbSurveys.SelectedValue = surveyListAdd.Result;
                }
            }
        }

        private async void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Delete question
            if (tileView1.GetRow(tileView1.FocusedRowHandle) is Quest quest)
            {
                await SilSoru(quest);
            }

        }

        private void gridSurveys_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UpdateResultGrid();

        }

        private void UpdateResultGrid()
        {
            if (int.TryParse(gridSurveys.GetFocusedRowCellValue("SurveyId")?.ToString(), out var surveyId))
            {
                var answers = SavedSurveys.Where(f => f.SurveyId == surveyId).FirstOrDefault();
                if (answers != null)
                {
                    txtPatient.Text = answers.Patient;
                    txtSessionNo.Text = answers.SessionId.ToString();
                    chkIsSubmitted.Checked = answers.IsSubmitted;
                    txtSurveyName.Text = answers.SurveyName;
                    txtSurveyDate.Text = answers.SurveyDate.ToLongDateString();


                }

                var quests = SavedSurveys.FirstOrDefault(f => f.SurveyId == surveyId)?.
                    Questions.
                    GroupBy(k => k.QuestionId).
                  Select(s => new Answers
                  {
                      QuestionId = s.Key,
                      CategoryTitle = s.Select(ss => ss.CategoryTitle).FirstOrDefault(),
                      AnswerOptionDesc = string.Join(" \n ", s.SelectMany(ss => ss.Answers)),
                      QuestionDesc = s.Select(ss => ss.QuestionDesc).FirstOrDefault(),
                  }).ToList();

                if (quests != null)
                {
                    gridControl2.DataSource = quests;
                    gridResult.ExpandAllGroups();
                }
            }
        }

        private void gridSurveys_Click(object sender, EventArgs e)
        {
            UpdateResultGrid();
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            var insertPatientForm = new InsertPatientForm();

            if (insertPatientForm.ShowDialog() == DialogResult.OK)
            {
                using (var ctx = new Model())
                {
                    var patients = await ctx.Patients.ToListAsync();

                    cmbPatients.Invoke((Action)(() =>
                    {
                        cmbPatients.DataSource = patients;
                        cmbPatients.DisplayMember = nameof(Patient.FullName);
                        cmbPatients.ValueMember = nameof(Patient.PatientId);
                    }));

                    cmbPatients.SelectedValue = insertPatientForm.ResultId;
                }
            }
        }

        private void gridSurveys_DoubleClick(object sender, EventArgs e)
        {
            if (int.TryParse(gridSurveys.GetFocusedRowCellValue("SurveyId")?.ToString(), out var surveyId))
            {
                using (var m = new Model())
                {
                    var survey = m.
                        Surveys.
                        Include(f => f.SurveyList).
                        Include(f => f.Pollster).
                        Include(f=>f.Answers).
                        FirstOrDefault(f => f.Id == surveyId);

                    //var qCount = m.SurveyLists.Where(f => f. == surveyId).Count(h=>h.SurveyList.Categories.);

                    if (survey != null)
                    {
                        //if(survey.Answers.Count== qCount)
                        //{
                        //    if(MessageBox.Show("Bu anket tamamen cevaplanmış. Bunu değiştirmek istediğinizden emin misiniz?")!= DialogResult.Yes)
                        //    {
                        //        return;
                        //    }
                        //}

                        var wizard = new SurveyWizardForm(survey);
                        wizard.ShowDialog();
                    }
                }
            }
        }

        private void reportSingle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridResult.ShowPrintPreview();
        }

        private async void barEditItem_EditValueChanged(object sender, EventArgs e)
        {
            await LoadTakenSurvey();
        }

        private async Task LoadTakenSurvey()
        {
            using (var m = new Model())
            {
                var takenSurvey = await m.Surveys.ToListAsync();
                var surveylistId = int.Parse(barEditItem.EditValue.ToString());

                var questions = await m.
                    Questions.
                    Where(f => f.Category.SurveyListId == surveylistId).
                    ToListAsync();
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("PatientInfo"));
                dt.Columns.Add(new DataColumn("SurveyId"));
                dt.Columns.Add(new DataColumn("SessionNo"));

                dt.Columns
                    .AddRange(
                    questions.
                    Select(f => new DataColumn(f.QuestionId.ToString() + "#" + f.Description)).ToArray());
                var answers = await m.Answers.Select(f =>
                  new PivotSurvey
                  {
                      Answer = f.Option.Text,
                      QuestionId = f.QuestionId,
                      Question = f.Question.Description,
                      SurveyId = f.SurveyId,
                      Category = f.Question.Category.CategoryTitle,
                      PatientName = f.Survey.Patient.PatientName,
                      PatientSurname = f.Survey.Patient.PatientSurname,
                      SessionNo = f.Survey.SessionId,
                  }).ToListAsync();

                SavedSurveys = m.Surveys.Select(f =>
                new SurveyView
                {
                    IsSubmitted = f.IsSubmitted,
                    SurveyDate = f.SurveyDate,
                    Pollster = f.Pollster.Name,
                    Patient = f.Patient.PatientName,
                    SurveyName = f.SurveyList.SurveyName,
                    SessionId = f.SessionId,
                    SurveyId = f.Id,
                    Questions = f.SurveyList.Categories.SelectMany(c => c.Questions).Select(g =>
                    new AnsweredQuestion
                    {
                        CategoryTitle = g.Category.CategoryTitle,
                        QuestionId = g.QuestionId,
                        QuestionDesc = g.Description,
                        Answers =                    
                        f.Answers.Where(h => h.QuestionId == g.QuestionId).Select(ss => ss.Option.Text).ToList()

                    }).ToList()
                }).ToList();

                foreach (var ts in takenSurvey)
                {
                    var takenAnswers = answers.Where(a => a.SurveyId == ts.Id).ToList();
                    var row = dt.NewRow();
                    var ta = takenAnswers.FirstOrDefault();
                    row["PatientInfo"] = ta?.PatientInfo;
                    row["SessionNo"] = ta?.SessionNo;
                    row["SurveyId"] = ta?.SurveyId;
                    foreach (var a in takenAnswers)
                    {
                        row[a.QuestionId + "#" + a.Question] = a.Answer;

                    }

                    dt.Rows.Add(row);
                }

                gridTakenSurveys.DataSource = dt;
                gridSurveys.Columns["SurveyId"].Visible = false;
                gridSurveys.BestFitColumns();
            }
        }

        private void reportAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridTakenSurveys.ShowPrintPreview();
        }
    }

    public class PivotSurvey
    {
        public int SurveyId { get; set; }
        public string Question { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public string Category { get; set; }
        public int SessionNo { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }

        public string PatientInfo => PatientSurname + ", " + PatientName;
    }

}
