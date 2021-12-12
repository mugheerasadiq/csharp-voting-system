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
using System.Xml;
using System.Xml.Linq;
using System.Configuration;

namespace K180296_Q2
{
    public partial class VoterDetailForm : Form
    {
        private List<string> PresidentsID = new List<string>();
        private List<string> VicePresidentsID = new List<string>();
        private List<string> GeneralSecretarysID = new List<string>();
        private List<string> VotersNIC = new List<string>();
        public void LoadCandidates()
        {
            try
            {
                string path = ConfigurationManager.AppSettings["CandidateListPath"], line = "";
                StreamReader Reader = File.OpenText(path);
                if (File.Exists(path))
                {
                    while ((line = Reader.ReadLine()) != null)
                    {
                        string[] items = line.Split(',');
                        string ID = items[0].Trim();
                        string Name = items[1].Trim();
                        string Position = items[2].Trim();

                        if (Position == "PRES")
                        {
                            PresidentsID.Add(ID);
                        }
                        else if(Position == "VPRE")
                        {
                            VicePresidentsID.Add(ID);
                        }
                        else if(Position == "GSEC")
                        {
                            GeneralSecretarysID.Add(ID);
                        }
                    }
                    
                }
                else
                    MessageBox.Show("File does not exists!", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Reader.Close();
            }
            catch (Exception excp)
            {
                MessageBox.Show("Exception: " + excp.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadVoters()
        {
            try
            {
                
                string path = ConfigurationManager.AppSettings["EligibleVotersPath"], line = "";
                StreamReader Reader = File.OpenText(path);
                if (File.Exists(path))
                {
                    while ((line = Reader.ReadLine()) != null)
                    {
                        string[] items = line.Split(',');
                        string NIC = items[2].Trim();
                        VotersNIC.Add(NIC);
                    }
                }
                else
                    MessageBox.Show("File does not exists!", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Reader.Close();
            }
            catch (Exception excp)
            {
                MessageBox.Show("Exception: " + excp.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public VoterDetailForm()
        {
            InitializeComponent();
        }

        // Checking if the vote exists or not
        public Boolean IsVoterExists(string NIC, string Position)
        {
            try
            {
                string path = ConfigurationManager.AppSettings["CastedVoteFiles"];
                foreach (string file in Directory.EnumerateFiles(path, "*.xml"))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(file);

                    XmlElement root = doc.DocumentElement;
                    XmlNodeList nodes = root.SelectNodes("//Voters/Vote");

                    foreach (XmlNode node in nodes)
                    {
                        if (node["NIC"].InnerText == NIC && node["Position"].InnerText == Position)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception excp)
            {
                MessageBox.Show("Exception: " + excp.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public void SaveXML(string NIC, string Position, string CandidateID)
        {
            try
            {
                DateTime CurrentTimeDate = DateTime.Now;
                string FileName = "AA_Elec_" + Vote.StationID + "_" + CurrentTimeDate.ToString("ddMMMyy") + '_' + CurrentTimeDate.ToString("hh") + "00.xml";

                // TODO: Change the position name - shorten it
                string path = ConfigurationManager.AppSettings["CastedVoteFiles"] + FileName;
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
                        xmlWriter.WriteElementString("NIC", NIC);
                        xmlWriter.WriteElementString("Position", Position);
                        xmlWriter.WriteElementString("CandidateID", CandidateID);
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
                    XElement root = xDocument.Element("Voters");
                    IEnumerable<XElement> rows = root.Descendants("Vote");
                    XElement lastRow = rows.Last();
                    lastRow.AddAfterSelf(
                       new XElement("Vote",
                       new XElement("NIC", NIC),
                       new XElement("Position", Position),
                       new XElement("CandidateID", CandidateID)));
                    xDocument.Save(path);
                }
            }
            catch (Exception excp)
            {
                MessageBox.Show("Exception: " + excp.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PositionComboBox.Text != "" && CandidateIDComboxBox.Text != "" && NICComboxBox.Text != "")
                {

                    string NICNumber = NICComboxBox.Text.Trim();
                    string Position = PositionComboBox.Text;
                    string CandidateID = CandidateIDComboxBox.Text;

                    if (Position == "President")
                        Position = "PRE";
                    else if (Position == "Vice President")
                        Position = "VPRE";
                    else if (Position == "General Secretary")
                        Position = "GSEC";

                    if(!VotersNIC.Contains(NICNumber))
                    {
                        MessageBox.Show("The NIC is incorrect", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if(IsVoterExists(NICNumber, Position))
                    {
                        MessageBox.Show("The voter already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        SaveXML(NICNumber, Position, CandidateID);
                        MessageBox.Show("Congratulations the vote is casted!", "Vote Casted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception excp)
            {
                MessageBox.Show("Exception: " + excp.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VoterDetailForm_Load(object sender, EventArgs e)
        {
            // Loading the candidates list
            LoadCandidates();
            // Loading the voters list
            LoadVoters();
            // AutoComplete for the NIC
            string[] Voters = VotersNIC.ToArray();
            NICComboxBox.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            NICComboxBox.AutoCompleteCustomSource.AddRange(Voters);
            NICComboxBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            NICComboxBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        // OnChange event of the Position ComboBox
        private void PositionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CandidateIDComboxBox.Text == "Please select the Position")
                CandidateIDComboxBox.Text = "";

            // President
            if (PositionComboBox.SelectedIndex == 0)
            {
                string[] Presidents = PresidentsID.ToArray();
                CandidateIDComboxBox.Items.Clear();
                for (int i = 0; i<Presidents.Length; i++)
                    CandidateIDComboxBox.Items.Add(Presidents[i]);
            }
            // Vice President
             else if(PositionComboBox.SelectedIndex == 1)
            {
                string[] VicePresidents = VicePresidentsID.ToArray();
                CandidateIDComboxBox.Items.Clear();
                for (int i = 0; i < VicePresidents.Length; i++)
                    CandidateIDComboxBox.Items.Add(VicePresidents[i]);
                
            }
            // General Secretary
            else if(PositionComboBox.SelectedIndex == 2)
            {
                string[] GeneralSecretary = GeneralSecretarysID.ToArray();
                CandidateIDComboxBox.Items.Clear();
                for (int i = 0; i < GeneralSecretary.Length; i++)
                    CandidateIDComboxBox.Items.Add(GeneralSecretary[i]);

            }
        }

        private void CandidateIDComboxBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
