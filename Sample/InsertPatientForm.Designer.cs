namespace Sample
{
    partial class InsertPatientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txtName = new System.Windows.Forms.TextBox();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.enrollDate = new System.Windows.Forms.DateTimePicker();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtTCKN = new System.Windows.Forms.MaskedTextBox();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Controls.Add(this.txtSurname);
            this.layoutControl1.Controls.Add(this.enrollDate);
            this.layoutControl1.Controls.Add(this.txtTCKN);
            this.layoutControl1.Controls.Add(this.btnOk);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(800, 145);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem18,
            this.layoutControlItem20,
            this.layoutControlItem23,
            this.layoutControlItem24,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(800, 145);
            this.Root.TextVisible = false;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(83, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(705, 20);
            this.txtName.TabIndex = 18;
            this.txtName.Text = "örnek ad";
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.txtName;
            this.layoutControlItem18.CustomizationFormText = "Hasta Adi:";
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(780, 24);
            this.layoutControlItem18.Text = "Hasta Adi:";
            this.layoutControlItem18.TextSize = new System.Drawing.Size(67, 13);
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(83, 36);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(705, 20);
            this.txtSurname.TabIndex = 20;
            this.txtSurname.Text = "soyad";
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.txtSurname;
            this.layoutControlItem20.CustomizationFormText = "Hasta Soyadi:";
            this.layoutControlItem20.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(780, 24);
            this.layoutControlItem20.Text = "Hasta Soyadi:";
            this.layoutControlItem20.TextSize = new System.Drawing.Size(67, 13);
            // 
            // enrollDate
            // 
            this.enrollDate.Location = new System.Drawing.Point(83, 60);
            this.enrollDate.Name = "enrollDate";
            this.enrollDate.Size = new System.Drawing.Size(705, 20);
            this.enrollDate.TabIndex = 23;
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.enrollDate;
            this.layoutControlItem23.CustomizationFormText = "Enroll Date";
            this.layoutControlItem23.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(780, 24);
            this.layoutControlItem23.Text = "Enroll Date";
            this.layoutControlItem23.TextSize = new System.Drawing.Size(67, 13);
            // 
            // txtTCKN
            // 
            this.txtTCKN.Location = new System.Drawing.Point(83, 84);
            this.txtTCKN.Mask = "00000000000";
            this.txtTCKN.Name = "txtTCKN";
            this.txtTCKN.Size = new System.Drawing.Size(705, 23);
            this.txtTCKN.TabIndex = 24;
            this.txtTCKN.Text = "12345678901";
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.txtTCKN;
            this.layoutControlItem24.CustomizationFormText = "Tc No:";
            this.layoutControlItem24.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(780, 27);
            this.layoutControlItem24.Text = "Tc No:";
            this.layoutControlItem24.TextSize = new System.Drawing.Size(67, 13);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(402, 111);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(386, 22);
            this.btnOk.StyleController = this.layoutControl1;
            this.btnOk.TabIndex = 25;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnOk;
            this.layoutControlItem1.Location = new System.Drawing.Point(390, 99);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(390, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 111);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(386, 22);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnCancel;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 99);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(390, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // InsertPatientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 145);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertPatientForm";
            this.Text = "InsertPatientForm";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private System.Windows.Forms.TextBox txtName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private System.Windows.Forms.TextBox txtSurname;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private System.Windows.Forms.DateTimePicker enrollDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private System.Windows.Forms.MaskedTextBox txtTCKN;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}