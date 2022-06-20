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
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.radioOptions = new DevExpress.XtraEditors.RadioGroup();
            this.layoutControlRadio = new DevExpress.XtraLayout.LayoutControlItem();
            this.checkedListBoxOptions = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.layoutControlChecked = new DevExpress.XtraLayout.LayoutControlItem();
            this.comboOptions = new System.Windows.Forms.ComboBox();
            this.layoutControlCombo = new DevExpress.XtraLayout.LayoutControlItem();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioOptions.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlRadio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlChecked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlCombo)).BeginInit();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.Controls.Add(this.wizardPage1);
            this.wizardControl1.Controls.Add(this.completionWizardPage1);
            this.wizardControl1.Controls.Add(this.welcomeWizardPage1);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wizardPage1,
            this.completionWizardPage1});
            this.wizardControl1.Size = new System.Drawing.Size(677, 432);
            this.wizardControl1.WizardStyle = DevExpress.XtraWizard.WizardStyle.WizardAero;
            this.wizardControl1.NextClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wizardControl1_NextClick);
            this.wizardControl1.PrevClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wizardControl1_PrevClick);
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.layoutControl1);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(617, 264);
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.Size = new System.Drawing.Size(617, 264);
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
            this.layoutControl1.Size = new System.Drawing.Size(617, 264);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
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
            this.Root.Size = new System.Drawing.Size(617, 264);
            this.Root.TextVisible = false;
            // 
            // lblQuestion
            // 
            this.lblQuestion.Location = new System.Drawing.Point(12, 12);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(593, 57);
            this.lblQuestion.TabIndex = 4;
            this.lblQuestion.Text = "Question";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lblQuestion;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(597, 61);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // radioOptions
            // 
            this.radioOptions.Location = new System.Drawing.Point(53, 73);
            this.radioOptions.Name = "radioOptions";
            this.radioOptions.Size = new System.Drawing.Size(552, 57);
            this.radioOptions.StyleController = this.layoutControl1;
            this.radioOptions.TabIndex = 5;
            // 
            // layoutControlRadio
            // 
            this.layoutControlRadio.Control = this.radioOptions;
            this.layoutControlRadio.Location = new System.Drawing.Point(0, 61);
            this.layoutControlRadio.Name = "layoutControlRadio";
            this.layoutControlRadio.Size = new System.Drawing.Size(597, 61);
            this.layoutControlRadio.Text = "Options";
            this.layoutControlRadio.TextSize = new System.Drawing.Size(37, 13);
            // 
            // checkedListBoxOptions
            // 
            this.checkedListBoxOptions.Location = new System.Drawing.Point(53, 134);
            this.checkedListBoxOptions.Name = "checkedListBoxOptions";
            this.checkedListBoxOptions.Size = new System.Drawing.Size(552, 93);
            this.checkedListBoxOptions.StyleController = this.layoutControl1;
            this.checkedListBoxOptions.TabIndex = 6;
            // 
            // layoutControlChecked
            // 
            this.layoutControlChecked.Control = this.checkedListBoxOptions;
            this.layoutControlChecked.Location = new System.Drawing.Point(0, 122);
            this.layoutControlChecked.Name = "layoutControlChecked";
            this.layoutControlChecked.Size = new System.Drawing.Size(597, 97);
            this.layoutControlChecked.Text = "Options";
            this.layoutControlChecked.TextSize = new System.Drawing.Size(37, 13);
            this.layoutControlChecked.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // comboOptions
            // 
            this.comboOptions.FormattingEnabled = true;
            this.comboOptions.Location = new System.Drawing.Point(53, 231);
            this.comboOptions.Name = "comboOptions";
            this.comboOptions.Size = new System.Drawing.Size(552, 21);
            this.comboOptions.TabIndex = 7;
            // 
            // layoutControlCombo
            // 
            this.layoutControlCombo.Control = this.comboOptions;
            this.layoutControlCombo.Location = new System.Drawing.Point(0, 219);
            this.layoutControlCombo.Name = "layoutControlCombo";
            this.layoutControlCombo.Size = new System.Drawing.Size(597, 25);
            this.layoutControlCombo.Text = "Options";
            this.layoutControlCombo.TextSize = new System.Drawing.Size(37, 13);
            this.layoutControlCombo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(617, 264);
            // 
            // SurveyWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 432);
            this.Controls.Add(this.wizardControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SurveyWizardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SurveyWizardForm";
            this.Load += new System.EventHandler(this.SurveyWizardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.wizardPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioOptions.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlRadio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlChecked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlCombo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
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
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
    }
}