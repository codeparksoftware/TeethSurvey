using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeetSurvey.Repository.Model;

namespace Sample
{
    public partial class NewSurveyForm : Form
    {
        public NewSurveyForm()
        {
            InitializeComponent();
        }
        public int Result { get; set; }
        private async void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) == false)
            {
                using (var m = new Model())
                {
                    if (!m.SurveyLists.Any(f => f.SurveyName == txtName.Text))
                    {
                        var surveyList = new SurveyList()
                        {
                            SurveyName = txtName.Text
                        };
                        var added = m.SurveyLists.Add(surveyList);
                        if (await m.SaveChangesAsync() > 0)
                        {
                            Result = added.Id;
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu Survey adı zaten mevcut");
                        txtName.SelectAll();
                        return;
                    }
                }


            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
