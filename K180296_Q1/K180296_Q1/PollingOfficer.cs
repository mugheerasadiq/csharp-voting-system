using System;
using System.Collections.Generic;
using System.Text;

namespace k180296_Q1
{
    class PollingOfficer
    {
        public string Email { get; set; }
        public string StationID { get; }
        private string Password;
        private string EncryptedPassword;

        public PollingOfficer(string email, string password, string stationID)
        {
            Email = email;
            Password = password;
            StationID = stationID;
        }

        public string EncryptPassword()
        {
            byte[] EncodedPassword = System.Text.Encoding.UTF8.GetBytes(Password);
            EncryptedPassword = System.Convert.ToBase64String(EncodedPassword);
            return EncryptedPassword;
        }
    }
}
