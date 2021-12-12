namespace K180296_Q2
{
    partial class VoterDetailForm
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
            this.NICComboxBox = new System.Windows.Forms.TextBox();
            this.NICLabel = new System.Windows.Forms.Label();
            this.CandidateLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PositionComboBox = new System.Windows.Forms.ComboBox();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.CandidateIDComboxBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // NICComboxBox
            // 
            this.NICComboxBox.Location = new System.Drawing.Point(118, 61);
            this.NICComboxBox.Name = "NICComboxBox";
            this.NICComboxBox.Size = new System.Drawing.Size(183, 20);
            this.NICComboxBox.TabIndex = 0;
            // 
            // NICLabel
            // 
            this.NICLabel.AutoSize = true;
            this.NICLabel.Location = new System.Drawing.Point(33, 64);
            this.NICLabel.Name = "NICLabel";
            this.NICLabel.Size = new System.Drawing.Size(25, 13);
            this.NICLabel.TabIndex = 1;
            this.NICLabel.Text = "NIC";
            // 
            // CandidateLabel
            // 
            this.CandidateLabel.AutoSize = true;
            this.CandidateLabel.Location = new System.Drawing.Point(33, 153);
            this.CandidateLabel.Name = "CandidateLabel";
            this.CandidateLabel.Size = new System.Drawing.Size(69, 13);
            this.CandidateLabel.TabIndex = 3;
            this.CandidateLabel.Text = "Candidate ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Position";
            // 
            // PositionComboBox
            // 
            this.PositionComboBox.AllowDrop = true;
            this.PositionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PositionComboBox.FormattingEnabled = true;
            this.PositionComboBox.Items.AddRange(new object[] {
            "President",
            "Vice President",
            "General Secretary"});
            this.PositionComboBox.Location = new System.Drawing.Point(118, 105);
            this.PositionComboBox.Name = "PositionComboBox";
            this.PositionComboBox.Size = new System.Drawing.Size(183, 21);
            this.PositionComboBox.TabIndex = 5;
            this.PositionComboBox.SelectedIndexChanged += new System.EventHandler(this.PositionComboBox_SelectedIndexChanged);
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Location = new System.Drawing.Point(226, 190);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(75, 23);
            this.SubmitBtn.TabIndex = 6;
            this.SubmitBtn.Text = "Submit";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // CandidateIDComboxBox
            // 
            this.CandidateIDComboxBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CandidateIDComboxBox.FormattingEnabled = true;
            this.CandidateIDComboxBox.Location = new System.Drawing.Point(118, 144);
            this.CandidateIDComboxBox.Name = "CandidateIDComboxBox";
            this.CandidateIDComboxBox.Size = new System.Drawing.Size(183, 21);
            this.CandidateIDComboxBox.TabIndex = 7;
            this.CandidateIDComboxBox.SelectedIndexChanged += new System.EventHandler(this.CandidateIDComboxBox_SelectedIndexChanged);
            // 
            // VoterDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 261);
            this.Controls.Add(this.CandidateIDComboxBox);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.PositionComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CandidateLabel);
            this.Controls.Add(this.NICLabel);
            this.Controls.Add(this.NICComboxBox);
            this.Name = "VoterDetailForm";
            this.Text = "Voter Details";
            this.Load += new System.EventHandler(this.VoterDetailForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NICComboxBox;
        private System.Windows.Forms.Label NICLabel;
        private System.Windows.Forms.Label CandidateLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PositionComboBox;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.ComboBox CandidateIDComboxBox;
    }
}