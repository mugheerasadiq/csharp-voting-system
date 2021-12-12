using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using K180296_Q4.Models;
using System.Configuration;

namespace K180296_Q4.Functions
{
    public class Voters
    {
        public Dictionary<string, PositionModel> President = new Dictionary<string, PositionModel>();
        public Dictionary<string, PositionModel> VicePresident = new Dictionary<string, PositionModel>();
        public Dictionary<string, PositionModel> GeneralSecretary = new Dictionary<string, PositionModel>();
        public void LoadCandidates()
        {
            try
            {
                string path = ConfigurationManager.AppSettings["CandidateListPath"], line = "";
                StreamReader Reader = System.IO.File.OpenText(path);
                if (System.IO.File.Exists(path))
                {
                    while ((line = Reader.ReadLine()) != null)
                    {
                        string[] items = line.Split(',');
                        string ID = items[0].Trim();
                        string Name = items[1].Trim();
                        string Position = items[2].Trim();

                        if (Position == "President")
                        {
                            President.Add(ID, new PositionModel(ID, Name, 0));
                        }
                        else if (Position == "Vice President")
                        {
                            VicePresident.Add(ID, new PositionModel(ID, Name, 0));
                        }
                        else if (Position == "General Secretary")
                        {
                            GeneralSecretary.Add(ID, new PositionModel(ID, Name, 0));
                        }

                    }
                }
                else
                    Console.WriteLine("File does not exists!");
                Reader.Close();
            }
            catch (Exception excp)
            {
                Console.WriteLine(excp.Message);
            }
        }
        public void CountVotes()
        {
            try
            {
                string RetrievalPath = ConfigurationManager.AppSettings["CastedVoteFiles"];

                foreach (string file in Directory.EnumerateFiles(RetrievalPath, "*.xml"))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(file);

                    XmlElement root = doc.DocumentElement;
                    XmlNodeList nodes = root.SelectNodes("//Voters/Vote");

                    foreach (XmlNode node in nodes)
                    {
                        string CandidateID = node["CandidateID"].InnerText;
                        string Position = node["Position"].InnerText;

                        if (Position == "PRES")
                        {
                            PositionModel tempObj = President[CandidateID];
                            int vote = tempObj.votes;
                            vote = vote + 1;
                            tempObj.votes = vote;
                            President[CandidateID] = tempObj;
                        }
                        else if (Position == "VPRE")
                        {
                            PositionModel tempObj = VicePresident[CandidateID];
                            int vote = tempObj.votes;
                            vote = vote + 1;
                            tempObj.votes = vote;
                            VicePresident[CandidateID] = tempObj;
                        }
                        else if (Position == "GSEC")
                        {
                            PositionModel tempObj = GeneralSecretary[CandidateID];
                            int vote = tempObj.votes;
                            vote = vote + 1;
                            tempObj.votes = vote;
                            GeneralSecretary[CandidateID] = tempObj;
                        }
                    }
                }
            }
            catch (Exception excp)
            {
                Console.WriteLine("Exception" + excp.Message);
            }
        }
    }
}