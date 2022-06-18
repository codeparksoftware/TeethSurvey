namespace Sample
{
    partial class QuestionView
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
            this.dgvAnswer = new System.Windows.Forms.DataGridView();
            this.colOptionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colInput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnswer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvAnswer);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblDesc);
            this.panel1.Controls.Add(this.lblCategory);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 582);
            this.panel1.TabIndex = 5;
            // 
            // dgvAnswer
            // 
            this.dgvAnswer.AllowUserToAddRows = false;
            this.dgvAnswer.AllowUserToDeleteRows = false;
            this.dgvAnswer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnswer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOptionId,
            this.colChk,
            this.colInput,
            this.colOption});
            this.dgvAnswer.Location = new System.Drawing.Point(31, 113);
            this.dgvAnswer.Name = "dgvAnswer";
            this.dgvAnswer.Size = new System.Drawing.Size(691, 338);
            this.dgvAnswer.TabIndex = 10;
            // 
            // colOptionId
            // 
            this.colOptionId.DataPropertyName = "OptionId";
            this.colOptionId.Frozen = true;
            this.colOptionId.HeaderText = "";
            this.colOptionId.Name = "colOptionId";
            this.colOptionId.ReadOnly = true;
            this.colOptionId.Visible = false;
            this.colOptionId.Width = 5;
            // 
            // colChk
            // 
            this.colChk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colChk.DataPropertyName = "SelectedValue";
            this.colChk.FalseValue = "false";
            this.colChk.HeaderText = "";
            this.colChk.IndeterminateValue = "false";
            this.colChk.Name = "colChk";
            this.colChk.TrueValue = "true";
            this.colChk.Width = 5;
            // 
            // colInput
            // 
            this.colInput.DataPropertyName = "InputValue";
            this.colInput.HeaderText = "Input";
            this.colInput.Name = "colInput";
            // 
            // colOption
            // 
            this.colOption.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colOption.DataPropertyName = "Text";
            this.colOption.HeaderText = "Option";
            this.colOption.Name = "colOption";
            this.colOption.ReadOnly = true;
            this.colOption.Width = 63;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(368, 484);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Next";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(287, 484);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Prior";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(31, 70);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(35, 13);
            this.lblDesc.TabIndex = 6;
            this.lblDesc.Text = "label1";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCategory.Location = new System.Drawing.Point(25, 35);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(86, 31);
            this.lblCategory.TabIndex = 5;
            this.lblCategory.Text = "label1";
            // 
            // QuestionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 582);
            this.Controls.Add(this.panel1);
            this.Name = "QuestionView";
            this.Text = "QuestionView";
            this.Load += new System.EventHandler(this.QuestionView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnswer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.DataGridView dgvAnswer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOptionId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOption;
    }
}