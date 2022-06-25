using System;
using System.Windows.Forms;

namespace Sample
{
    public partial class InputBox : Form
    {
        public InputBox(string text,int? val, bool isDefault)
        {
            InitializeComponent();
            if (string.IsNullOrWhiteSpace(text) == false)
            {
                txtOption.Text = text;
            }
            if (val.HasValue)
            {
                txtValue.Text = ""+val;
            }
            chkIsDefault.Checked = isDefault;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCncl_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
