using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace k180296_Q1
{
    class Program
    {
        // Checking if the email exists or not
        public static Boolean isEmailExists(string email)
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
                        string Email = items[0].Trim();

                        if (Email == email)
                            return true;
                    }

                }
                else
                    Console.WriteLine("File does not exists!");
                Reader.Close();
                return false;
            }
            catch (Exception excp)
            {
                    Console.WriteLine("File does not exists!");
                return false;
            }
        }
        static void SaveData(string Email, string StationID, string EncryptedPassword)
        {
            try
            {
                FileStream FileObject = new FileStream(ConfigurationManager.AppSettings["LoginCredentialFile"], FileMode.Append, FileAccess.Write);
                StreamWriter StreamWriterObj = new StreamWriter(FileObject);
                StreamWriterObj.WriteLine(Email + ',' + EncryptedPassword + ',' + StationID);
                StreamWriterObj.Flush();
                StreamWriterObj.Close();
                StreamWriterObj.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            if (args.Length > 3 || args.Length < 3)
            {
                Console.WriteLine("Please enter the correct data");
                Console.ReadLine();
                Environment.Exit(1);
            }
            else
            {
                try
                {
                    string Email = args[0];
                    string Password = args[1];
                    string StationID = args[2];
                    PollingOfficer Person = new PollingOfficer(Email, Password, StationID);
                    string EncryptedText = Person.EncryptPassword();
                    if (!isEmailExists(Email))
                    {
                        SaveData(Person.Email, Person.StationID, EncryptedText);
                    }
                    else
                    {
                        Console.WriteLine("Email already exists!");
                    }
                   
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }

        }
    }
}