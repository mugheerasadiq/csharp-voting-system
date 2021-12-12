using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K180296_Q4.Models
{
    public class PositionModel
    {
            public string name;
            public int votes { get; set; }
            public string id;

            public PositionModel(string id, string name, int votes)
            {
                this.id = id;
                this.name = name;
                this.votes = votes;
            }
    }
}