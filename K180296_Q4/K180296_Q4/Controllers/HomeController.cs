using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using K180296_Q4.Models;
using K180296_Q4.Functions;

namespace K180296_Q4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Voters Votes = new Voters();
            Votes.LoadCandidates();
            Votes.CountVotes();

            ViewBag.President = Votes.President;
            ViewBag.GeneralSecretary = Votes.GeneralSecretary;
            ViewBag.VicePresident = Votes.VicePresident;

            return View();
        }
    }
}