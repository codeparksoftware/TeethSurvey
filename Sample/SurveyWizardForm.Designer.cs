namespace Sample
{
    partial class SurveyWizardForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCat = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrevious = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.comboOptions = new System.Windows.Forms.ComboBox();
            this.checkedListBoxOptions = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.radioOptions = new DevExpress.XtraEditors.RadioGroup();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlRadio = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlChecked = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlCombo = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioOptions.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlRadio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlChecked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlCombo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 58);
            this.panel1.TabIndex = 0;
            // 
            // lblCat
            // 
            this.lblCat.AutoSize = true;
            this.lblCat.Font = new System.Drawing.Font("Tahoma", 18.25F);
            this.lblCat.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblCat.Location = new System.Drawing.Point(12, 9);
            this.lblCat.Name = "lblCat";
            this.lblCat.Size = new System.Drawing.Size(79, 30);
            this.lblCat.TabIndex = 0;
            this.lblCat.Text = "label1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.simpleButton1);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnPrevious);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 377);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(677, 55);
            this.panel2.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(414, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(495, 20);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(576, 20);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_ClickAsync);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.layoutControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 58);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(677, 319);
            this.panel3.TabIndex = 2;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.comboOptions);
            this.layoutControl1.Controls.Add(this.checkedListBoxOptions);
            this.layoutControl1.Controls.Add(this.radioOptions);
            this.layoutControl1.Controls.Add(this.lblQuestion);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(677, 319);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // comboOptions
            // 
            this.comboOptions.FormattingEnabled = true;
            this.comboOptions.Location = new System.Drawing.Point(52, 286);
            this.comboOptions.Name = "comboOptions";
            this.comboOptions.Size = new System.Drawing.Size(613, 21);
            this.comboOptions.TabIndex = 7;
            // 
            // checkedListBoxOptions
            // 
            this.checkedListBoxOptions.Location = new System.Drawing.Point(52, 162);
            this.checkedListBoxOptions.Name = "checkedListBoxOptions";
            this.checkedListBoxOptions.Size = new System.Drawing.Size(613, 120);
            this.checkedListBoxOptions.StyleController = this.layoutControl1;
            this.checkedListBoxOptions.TabIndex = 6;
            // 
            // radioOptions
            // 
            this.radioOptions.Location = new System.Drawing.Point(52, 87);
            this.radioOptions.Name = "radioOptions";
            this.radioOptions.Size = new System.Drawing.Size(613, 71);
            this.radioOptions.StyleController = this.layoutControl1;
            this.radioOptions.TabIndex = 5;
            // 
            // lblQuestion
            // 
            this.lblQuestion.Location = new System.Drawing.Point(12, 12);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(653, 71);
            this.lblQuestion.TabIndex = 4;
            this.lblQuestion.Text = "Question";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlRadio,
            this.layoutControlChecked,
            this.layoutControlCombo});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(677, 319);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lblQuestion;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(657, 75);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlRadio
            // 
            this.layoutControlRadio.Control = this.radioOptions;
            this.layoutControlRadio.Location = new System.Drawing.Point(0, 75);
            this.layoutControlRadio.Name = "layoutControlRadio";
            this.layoutControlRadio.Size = new System.Drawing.Size(657, 75);
            this.layoutControlRadio.Text = "Options";
            this.layoutControlRadio.TextSize = new System.Drawing.Size(37, 13);
            // 
            // layoutControlChecked
            // 
            this.layoutControlChecked.Control = this.checkedListBoxOptions;
            this.layoutControlChecked.Location = new System.Drawing.Point(0, 150);
            this.layoutControlChecked.Name = "layoutControlChecked";
            this.layoutControlChecked.Size = new System.Drawing.Size(657, 124);
            this.layoutControlChecked.Text = "Options";
            this.layoutControlChecked.TextSize = new System.Drawing.Size(37, 13);
            this.layoutControlChecked.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlCombo
            // 
            this.layoutControlCombo.Control = this.comboOptions;
            this.layoutControlCombo.Location = new System.Drawing.Point(0, 274);
            this.layoutControlCombo.Name = "layoutControlCombo";
            this.layoutControlCombo.Size = new System.Drawing.Size(657, 25);
            this.layoutControlCombo.Text = "Options";
            this.layoutControlCombo.TextSize = new System.Drawing.Size(37, 13);
            this.layoutControlCombo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(333, 20);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Finish";
            // 
            // SurveyWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 432);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SurveyWizardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Survey ";
            this.Load += new System.EventHandler(this.SurveyWizardForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioOptions.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlRadio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlChecked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlCombo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCat;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnPrevious;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.ComboBox comboOptions;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxOptions;
        private DevExpress.XtraEditors.RadioGroup radioOptions;
        private System.Windows.Forms.Label lblQuestion;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlRadio;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlChecked;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlCombo;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}