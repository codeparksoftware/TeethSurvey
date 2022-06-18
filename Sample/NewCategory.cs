using System;
using System.Linq;
using System.Windows.Forms;
using TeetSurvey.Repository.Model;

namespace Sample
{
    public partial class NewCategory : DevExpress.XtraEditors.XtraForm
    {
        public NewCategory()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        public int Result { get; set; }
        private async void btnOk_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtName.Text) == false)
            {
                using (var m = new Model())
                {
                    if (!m.Categories.Any(f => f.CategoryTitle == txtName.Text))
                    {
                        var cat = new Category()
                        {
                            CategoryTitle = txtName.Text
                        };
                        var added = m.Categories.Add(cat);
                        if (await m.SaveChangesAsync() > 0)
                        {
                            Result = added.CategoryId;
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu Kategori adı zaten mevcut");
                        txtName.SelectAll();
                        return;
                    }
                }


            }
        }
    }
}