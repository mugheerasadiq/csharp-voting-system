using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K180296_Q2
{
    class Vote
    {
        public string CNIC { get; }
        public string Position { get; }
        public string CandidateID { get; }
        public static string StationID { get; set; }
        public Vote(string cnic, string position, string candidateID)
        {
            CNIC = cnic;
            Position = position;
            CandidateID = candidateID;
        }

    }
}
