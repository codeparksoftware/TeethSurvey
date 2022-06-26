using System;
using System.Linq;
using System.Windows.Forms;
using TeetSurvey.Repository.Model;

namespace Sample
{
    public partial class NewPollster : Form
    {
        public NewPollster()
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
                    if (!m.Pollsters.Any(f => f.Name == txtName.Text))
                    {
                        var poll = new Pollster()
                        {
                            Name = txtName.Text
                        };
                        var added = m.Pollsters.Add(poll);
                        if (await m.SaveChangesAsync() > 0)
                        {
                            Result = added.Id;
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu Pollster adı zaten mevcut");
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
