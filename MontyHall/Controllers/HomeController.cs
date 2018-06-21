using System;
using System.Web.Mvc;
using MontyHall.Models;

namespace MontyHall.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var stayStats = Session["StayStats"] as Stats;
            if (stayStats == null)
            {
                stayStats = new Stats();
                Session["StayStats"] = stayStats;
            }
            var switchStats = Session["SwitchStats"] as Stats;
            if (switchStats == null)
            {
                switchStats = new Stats();
                Session["SwitchStats"] = switchStats;
            }
            Session["DoorState"] = new DoorState(3, PickDoor());

            var model = new StatModel()
            {
                StayStats = stayStats,
                SwitchStats = switchStats
            };

            return View(model);
        }

        public ActionResult Reset()
        {
            Session["Stats"] = null;
            ViewBag.Message = "Stats reset.";
            return View();
        }

        private int PickDoor()
        {
            return new Random().Next(3) + 1;
        }
    }
}