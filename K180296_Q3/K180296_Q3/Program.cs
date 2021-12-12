using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Configuration;

namespace K180296_Q3
{
    class Program
    {
        private List<string> PresidentsID = new List<string>();
        private List<string> VicePresidentsID = new List<string>();
        private List<string> GeneralSecretarysID = new List<string>();
        private static void MergeFiles()
        {
            try
            {
                DateTime CurrentTimeDate = DateTime.Now;
                // Getting the current time and subtracting one from it. - Accessing the one hour passed file.
                string time = (Int32.Parse(CurrentTimeDate.ToString("hh")) - 1).ToString();
                string date = CurrentTimeDate.ToString("ddMMMyy");
                string RetrievalPath = ConfigurationManager.AppSettings["CastedVoteFiles"];

                foreach (string file in Directory.EnumerateFiles(RetrievalPath, "*.xml"))
                {
                    string[] parsedName = file.Split('_');

                    // Polling IDS
                    string pollingStation1 = ConfigurationManager.AppSettings["MainCampus"];
                    string pollingStation2 = ConfigurationManager.AppSettings["CityCampus"];

                    string pollingID = parsedName[2];
                    string fileDate = parsedName[3];
                    string fileHour = parsedName[4];
                    fileHour = fileHour[0].ToString() + fileHour[1].ToString();
                    
                    if (fileDate == date && fileHour.Contains(time))
                    {
                       if(pollingID == pollingStation1)
                        {
         
                            XmlDocument doc = new XmlDocument();
                            doc.Load(file);

                            XmlElement root = doc.DocumentElement;
                            XmlNodeList nodes = root.SelectNodes("//Voters/Vote");

                            string mergedFileName = "AA_Elec_" + pollingID + "_" + date + ".xml";
                            // Path to save merged file
                            string path = ConfigurationManager.AppSettings["MergedFilePath"] + mergedFileName;

                            foreach (XmlNode node in nodes)
                            {
                                if (!File.Exists(path))
                                {
                                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                                    xmlWriterSettings.Indent = true;
                                    xmlWriterSettings.NewLineOnAttributes = true;
                                    using (XmlWriter xmlWriter = XmlWriter.Create(path, xmlWriterSettings))
                                    {
                                        xmlWriter.WriteStartDocument();
                                        xmlWriter.WriteStartElement("Voters");

                                        xmlWriter.WriteStartElement("Vote");
                                        xmlWriter.WriteElementString("NIC", node["NIC"].InnerText);
                                        xmlWriter.WriteElementString("Position", node["Position"].InnerText);
                                        xmlWriter.WriteElementString("CandidateID", node["CandidateID"].InnerText);
                                        xmlWriter.WriteEndElement();

                                        xmlWriter.WriteEndElement();
                                        xmlWriter.WriteEndDocument();
                                        xmlWriter.Flush();
                                        xmlWriter.Close();
                                    }
                                }
                                else
                                {
                                    XDocument xDocument = XDocument.Load(path);
                                    XElement rootElement = xDocument.Element("Voters");
                                    IEnumerable<XElement> rows = rootElement.Descendants("Vote");
                                    XElement lastRow = rows.Last();
                                    lastRow.AddAfterSelf(
                                       new XElement("Vote",
                                       new XElement("NIC", node["NIC"].InnerText),
                                       new XElement("Position", node["Position"].InnerText),
                                       new XElement("CandidateID", node["CandidateID"].InnerText)));
                                    xDocument.Save(path);
                                }
                            }

                        }
                        else if(pollingID == pollingStation2)
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(file);

                            XmlElement root = doc.DocumentElement;
                            XmlNodeList nodes = root.SelectNodes("//Voters/Vote");

                            string mergedFileName = "AA_Elec_" + pollingID + "_" + date + ".xml";
                            // Path to save merged file
                            string path = ConfigurationManager.AppSettings["MergedFilePath"] + mergedFileName;

                            foreach (XmlNode node in nodes)
                            {
                                if (!File.Exists(path))
                                {
                                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                                    xmlWriterSettings.Indent = true;
                                    xmlWriterSettings.NewLineOnAttributes = true;
                                    using (XmlWriter xmlWriter = XmlWriter.Create(path, xmlWriterSettings))
                                    {
                                        xmlWriter.WriteStartDocument();
                                        xmlWriter.WriteStartElement("Voters");

                                        xmlWriter.WriteStartElement("Vote");
                                        xmlWriter.WriteElementString("NIC", node["NIC"].InnerText);
                                        xmlWriter.WriteElementString("Position", node["Position"].InnerText);
                                        xmlWriter.WriteElementString("CandidateID", node["CandidateID"].InnerText);
                                        xmlWriter.WriteEndElement();

                                        xmlWriter.WriteEndElement();
                                        xmlWriter.WriteEndDocument();
                                        xmlWriter.Flush();
                                        xmlWriter.Close();
                                    }
                                }
                                else
                                {
                                    XDocument xDocument = XDocument.Load(path);
                                    XElement rootElement = xDocument.Element("Voters");
                                    IEnumerable<XElement> rows = rootElement.Descendants("Vote");
                                    XElement lastRow = rows.Last();
                                    lastRow.AddAfterSelf(
                                       new XElement("Vote",
                                       new XElement("NIC", node["NIC"].InnerText),
                                       new XElement("Position", node["Position"].InnerText),
                                       new XElement("CandidateID", node["CandidateID"].InnerText)));
                                    xDocument.Save(path);
                                }
                            }
                        }
                    }     
                 }
                
            }
            catch (Exception excp)
            {
                Console.WriteLine(excp.Message);
            }
        }
     
        static void Main(string[] args)
        {
            try
            {
                MergeFiles();
            }
            catch (Exception excp)
            {
                Console.WriteLine(excp.Message);
            }
        }
    }
}
