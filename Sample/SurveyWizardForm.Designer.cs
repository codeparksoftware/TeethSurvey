using System.Windows.Forms;

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
            this.treeView1 = new System.Windows.Forms.ListView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFinish = new DevExpress.XtraEditors.SimpleButton();
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
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCat = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colDesc});
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.FullRowSelect = true;
            this.treeView1.GridLines = true;
            this.treeView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.MultiSelect = false;
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(159, 432);
            this.treeView1.TabIndex = 4;
            this.treeView1.UseCompatibleStateImageBehavior = false;
            this.treeView1.View = System.Windows.Forms.View.Details;
            this.treeView1.SelectedIndexChanged += new System.EventHandler(this.treeView1_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(159, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(668, 432);
            this.panel4.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnFinish);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnPrevious);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 377);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(668, 55);
            this.panel2.TabIndex = 1;
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(341, 20);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 1;
            this.btnFinish.Text = "Finish";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(422, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(503, 20);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(584, 20);
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
            this.panel3.Size = new System.Drawing.Size(668, 374);
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
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(716, 125, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(668, 374);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = " ";
            // 
            // comboOptions
            // 
            this.comboOptions.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.comboOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOptions.FormattingEnabled = true;
            this.comboOptions.Location = new System.Drawing.Point(52, 97);
            this.comboOptions.Name = "comboOptions";
            this.comboOptions.Size = new System.Drawing.Size(613, 21);
            this.comboOptions.TabIndex = 7;
            // 
            // checkedListBoxOptions
            // 
            this.checkedListBoxOptions.Location = new System.Drawing.Point(52, 198);
            this.checkedListBoxOptions.Name = "checkedListBoxOptions";
            this.checkedListBoxOptions.Size = new System.Drawing.Size(613, 72);
            this.checkedListBoxOptions.StyleController = this.layoutControl1;
            this.checkedListBoxOptions.TabIndex = 6;
            // 
            // radioOptions
            // 
            this.radioOptions.Location = new System.Drawing.Point(52, 122);
            this.radioOptions.Name = "radioOptions";
            this.radioOptions.Properties.ItemVertAlignment = DevExpress.XtraEditors.RadioItemVertAlignment.Top;
            this.radioOptions.Size = new System.Drawing.Size(613, 72);
            this.radioOptions.StyleController = this.layoutControl1;
            this.radioOptions.TabIndex = 5;
            // 
            // lblQuestion
            // 
            this.lblQuestion.Location = new System.Drawing.Point(12, 12);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(653, 81);
            this.lblQuestion.TabIndex = 4;
            this.lblQuestion.Text = "Question";
            // 
            // Root
            // 
            this.Root.DefaultLayoutType = DevExpress.XtraLayout.Utils.LayoutType.Horizontal;
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlRadio,
            this.layoutControlChecked,
            this.layoutControlCombo,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(677, 357);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lblQuestion;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(657, 85);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlRadio
            // 
            this.layoutControlRadio.Control = this.radioOptions;
            this.layoutControlRadio.Location = new System.Drawing.Point(0, 110);
            this.layoutControlRadio.Name = "layoutControlRadio";
            this.layoutControlRadio.Size = new System.Drawing.Size(657, 76);
            this.layoutControlRadio.Text = "Options";
            this.layoutControlRadio.TextSize = new System.Drawing.Size(37, 13);
            this.layoutControlRadio.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlChecked
            // 
            this.layoutControlChecked.Control = this.checkedListBoxOptions;
            this.layoutControlChecked.Location = new System.Drawing.Point(0, 186);
            this.layoutControlChecked.Name = "layoutControlChecked";
            this.layoutControlChecked.Size = new System.Drawing.Size(657, 76);
            this.layoutControlChecked.Text = "Options";
            this.layoutControlChecked.TextSize = new System.Drawing.Size(37, 13);
            this.layoutControlChecked.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlCombo
            // 
            this.layoutControlCombo.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.layoutControlCombo.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlCombo.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlCombo.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.layoutControlCombo.Control = this.comboOptions;
            this.layoutControlCombo.Location = new System.Drawing.Point(0, 85);
            this.layoutControlCombo.MaxSize = new System.Drawing.Size(657, 25);
            this.layoutControlCombo.MinSize = new System.Drawing.Size(657, 25);
            this.layoutControlCombo.Name = "layoutControlCombo";
            this.layoutControlCombo.OptionsPrint.AppearanceItemCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.layoutControlCombo.OptionsPrint.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlCombo.Size = new System.Drawing.Size(657, 25);
            this.layoutControlCombo.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlCombo.Text = "Options";
            this.layoutControlCombo.TextSize = new System.Drawing.Size(37, 13);
            this.layoutControlCombo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 262);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(657, 75);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.lblCat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 58);
            this.panel1.TabIndex = 0;
            // 
            // lblCat
            // 
            this.lblCat.AutoSize = true;
            this.lblCat.Font = new System.Drawing.Font("Tahoma", 18.25F);
            this.lblCat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCat.Location = new System.Drawing.Point(12, 9);
            this.lblCat.Name = "lblCat";
            this.lblCat.Size = new System.Drawing.Size(141, 30);
            this.lblCat.TabIndex = 0;
            this.lblCat.Text = "                ";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(159, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 432);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // colId
            // 
            this.colId.Text = "";
            this.colId.Width = 0;
            // 
            // colDesc
            // 
            this.colDesc.Text = "Question";
            this.colDesc.Width = 120;
            // 
            // SurveyWizardForm
            // 
            this.AcceptButton = this.btnFinish;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(827, 432);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SurveyWizardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Survey ";
            this.Load += new System.EventHandler(this.SurveyWizardForm_Load);
            this.panel4.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ListView treeView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnFinish;
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
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCat;
        private System.Windows.Forms.Splitter splitter1;
        private ColumnHeader colId;
        private ColumnHeader colDesc;
    }
}