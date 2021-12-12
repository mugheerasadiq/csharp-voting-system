namespace K180296_Q2
{
    partial class loginForm
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
            this.emailLabel = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.pollingID = new System.Windows.Forms.TextBox();
            this.PollingStation = new System.Windows.Forms.Label();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(43, 79);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(32, 13);
            this.emailLabel.TabIndex = 0;
            this.emailLabel.Text = "Email";
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(132, 72);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(183, 20);
            this.Email.TabIndex = 1;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(132, 110);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(183, 20);
            this.Password.TabIndex = 3;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(43, 117);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password";
            // 
            // pollingID
            // 
            this.pollingID.Location = new System.Drawing.Point(132, 152);
            this.pollingID.Name = "pollingID";
            this.pollingID.Size = new System.Drawing.Size(183, 20);
            this.pollingID.TabIndex = 5;
            // 
            // PollingStation
            // 
            this.PollingStation.AutoSize = true;
            this.PollingStation.Location = new System.Drawing.Point(43, 159);
            this.PollingStation.Name = "PollingStation";
            this.PollingStation.Size = new System.Drawing.Size(74, 13);
            this.PollingStation.TabIndex = 4;
            this.PollingStation.Text = "Polling Station";
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(240, 200);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(75, 23);
            this.LoginBtn.TabIndex = 6;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 272);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.pollingID);
            this.Controls.Add(this.PollingStation);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.emailLabel);
            this.Name = "loginForm";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox pollingID;
        private System.Windows.Forms.Label PollingStation;
        private System.Windows.Forms.Button LoginBtn;
    }
}

