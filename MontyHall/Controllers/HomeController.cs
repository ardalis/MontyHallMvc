using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MontyHall.Models;

namespace MontyHall.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var stats = Session["Stats"] as Stats;
            if (stats == null)
            {
                stats = new Stats();
                Session["Stats"] = stats;
            }
            Session["DoorState"] = new DoorState(3, PickDoor());

            return View(stats);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private int PickDoor()
        {
            return new Random().Next(3) + 1;
        }
    }
}