using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TeetSurvey.Repository.Model;

namespace Sample
{
    public partial class QuestionView : Form
    {
        const string Input = "Input";
        const string Single = "Single";
        public enum QType
        {
          Single,
          Input
        }

        public QuestionView()
        {
            InitializeComponent();
            _questions = new Model().Questions.ToList();
            Question = _questions.FirstOrDefault();
            dgvAnswer.CellDoubleClick += DgvAnswer_CellDoubleClick;
            dgvAnswer.CellMouseUp += DgvAnswer_CellMouseUp;
            dgvAnswer.CellContentClick += DgvAnswer_CellContentClick;
        }

        private void DgvAnswer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            
            if (e.ColumnIndex != dgvAnswer.Columns[colChk.Name].Index)
            {
                return;
            }
            dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dataGridView.EndEdit();

            if (!(bool)dataGridView[e.ColumnIndex, e.RowIndex].Value)
            {
                return;
            }

            foreach (DataGridViewRow row in dataGridView.Rows.Cast<DataGridViewRow>().Where(row => row.Index != e.RowIndex))
            {
                row.Cells[colChk.Name].Value = false;
            }
        }

        //private void DgvAnswer_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == dgvAnswer.Columns[colChk.Name].Index && e.RowIndex != -1)
        //    {
        //        dgvAnswer.Rows[e.RowIndex].Cells[colChk.Name].Value = true;
        //        for (int i = 0; i < dgvAnswer.RowCount; i++)
        //        {
        //            if (i != e.RowIndex)
        //            {
        //                dgvAnswer.Rows[i].Cells[colChk.Name].Value = false;
        //            }
        //        }
        //    }
        //}

        private void DgvAnswer_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Qtype == QType.Single)
            {
                if (e.ColumnIndex == dgvAnswer.Columns[colChk.Name].Index && e.RowIndex != -1)
                {
                    dgvAnswer.EndEdit();
                }
            }

        }

        private void DgvAnswer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Qtype == QType.Single)
            {
                if (e.ColumnIndex == dgvAnswer.Columns[colChk.Name].Index && e.RowIndex != -1)
                {
                    dgvAnswer.EndEdit();
                }
            }
        }

        private List<Question> _questions;

        private Question _question;
        public Question Question
        {
            get { return _question; }
            set
            {
                _question = value;
                OnQuestionChanged();
            }

        }
        public QType Qtype { get; set; }

        private void OnQuestionChanged()
        {
            lblCategory.Text = Question.Category.CategoryTitle;
            lblDesc.Text = Question.Description;

            //dgvAnswer.Columns[nameof(colInput)].Visible = Question.QuestionType.Name == Input;
            //dgvAnswer.Columns[nameof(colChk)].Visible = Question.QuestionType.Name == Single;
            //Qtype = Question.QuestionType.Name == Input ? QType.Input : QType.Single;

            dgvAnswer.DataSource = new List<OptionAnswer>();
       var options =
                Question.Options.Where(f => f.QuestionId == Question.QuestionId).
                Select(f => new OptionAnswer()
                {

                    Text = f.Text,
                    InputValue = string.Empty,
                    OptionId = f.OptionId,
                    SelectedValue = false
                }).ToList();

            dgvAnswer.DataSource = options;
            dgvAnswer.Refresh();
            dgvAnswer.Update();
            
 
           
        }
        private class OptionAnswer
        {
            public string Text { get; set; }
            public bool SelectedValue { get; set; }
            public string InputValue { get; set; }
            public int OptionId { get; set; }

        }

        private void QuestionView_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //using (var m = new Model())
            //{
            //    var answer = new Answer();
            //    answer.QuestionId = Question.QuestionId;
            //    answer.SurveyId = SingleService.Instance.Survey.SurveyId;

            //    var optId =
            //        Question.Option.
            //        FirstOrDefault(f => f.Text == singleChck.SelectedItem.ToString())?.
            //        OptionId;
            //    if (Question.QuestionType.Name == Single)
            //    {
            //        answer.OptionId = optId;
            //        answer.Value = null;

            //    }

            //    if (Question.QuestionType.Name == Input && pnlInput.Controls.Count == 0)
            //    {
            //        MessageBox.Show("Soru hatalı");
            //    }

            //    else if (Question.QuestionType.Name == Input && pnlInput.Controls.Count > 0)
            //    {
            //        var cnt = 0;
            //        var val = "";
            //        foreach (var item in pnlInput.Controls)
            //        {
            //            if (item is InputControl && string.IsNullOrWhiteSpace((item as InputControl).textBox1.Text))
            //            {
            //                cnt++;
            //            }
            //            if (item is InputControl && !string.IsNullOrWhiteSpace((item as InputControl).textBox1.Text))
            //            {
            //                val = (item as InputControl).textBox1.Text;
            //            }
            //        }
            //        if (cnt == pnlInput.Controls.Count)
            //        {
            //            MessageBox.Show("Lütfen bir değer giriniz");
            //        }
            //        answer.Value = val;
            //    }

            //    m.Answer.Add(answer);
            //    var res = m.SaveChanges();

            //    if (res > 0)
            //    {
            //        var q =
            //            _questions.FirstOrDefault(f => f.QuestionId > Question.QuestionId);
            //        Question = q == null ? Question : q;
            //    }
            //}

            var q =
            _questions.FirstOrDefault(f => f.QuestionId > Question.QuestionId);
            Question = q == null ? Question : q;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var q =
             _questions.FirstOrDefault(f => f.QuestionId < Question.QuestionId);
            Question = q == null ? Question : q;

        }

        private void singleChck_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }
    }
}
