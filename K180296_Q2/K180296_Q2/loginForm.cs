using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace K180296_Q2
{
    public partial class loginForm : Form
    {
        public static string DecodePassword(string encryptedPassword)
        {
            byte[] base64EncodedBytes = System.Convert.FromBase64String(encryptedPassword);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        // Function to verify the credentials of a polling officer
        Boolean VerifyCredentials(string email, string password, string pollingStation)
        {
            try
            {
                string path = ConfigurationManager.AppSettings["LoginCredentialFile"], line = "";
                StreamReader Reader = File.OpenText(path);
                if (File.Exists(path))
                {
                    while ((line = Reader.ReadLine()) != null)
                    {
                        string[] items = line.Split(',');
                        string Email = items[0];
                        string EncryptedPassword = items[1];
                        string PollingID = items[2];

                        if (Email == email && PollingID == pollingStation)
                        {
                            return DecodePassword(EncryptedPassword) == password;
                        }
                    }
                }
                else
                    Console.WriteLine("File does not exists!");
                Reader.Close();
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public loginForm()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string email = Email.Text.Trim();
            string password = Password.Text.Trim();
            string pollingStation = pollingID.Text.Trim();

            if(VerifyCredentials(email, password, pollingStation))
            {
                Vote.StationID = pollingStation;
                this.Visible = false;
                VoterDetailForm votingDetailForm = new VoterDetailForm();
                votingDetailForm.Show();
            }
            else
            {
                MessageBox.Show("Wrong Credentials", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
