using System;
using System.Windows.Forms;
using TeetSurvey.Repository.Model;

namespace Sample
{
    public partial class InsertPatientForm : Form
    {
        public InsertPatientForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        public int ResultId = 0;
        private void btnOk_Click(object sender, EventArgs e)
        {
            using (var m = new Model())
            {
                var patient = new Patient()
                {
                    EnrollDate = enrollDate.Value,
                    PatientName = txtName.Text,
                    PatientSurname = txtSurname.Text,
                    PatientTCKN = txtTCKN.Text
                };

                m.Patients.Add(patient);
                if (m.SaveChanges() > 0)
                {
                    ResultId = patient.PatientId;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Hasta kaydında hata oldu tekrar deneyiniz", "Survey");
                }

            }
        }
    }
}
