using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using MontyHall.Models;

namespace MontyHall.Controllers
{
    public class DoorController : Controller
    {
        // GET: Door
        public ActionResult Choose(int id)
        {
            var doorState = Session["DoorState"] as DoorState;
            if (doorState == null)
            {
                return RedirectToAction("Index", "Home");
            }
            doorState.ChosenDoor = id;
            int doorsToSkip = new Random().Next(2); // return 0 or 1
            doorState.Doors.Where(d => !d.IsWinner)
                .Skip(doorsToSkip)
                .FirstOrDefault()
                .IsOpen = true;

            return View(doorState);
        }
         
        public ActionResult Confirm(int id)
        {
            var doorState = Session["DoorState"] as DoorState;
            if (doorState == null)
            {
                return RedirectToAction("Index", "Home");
            }
            doorState.ChosenDoor = id;
            var stats = Session["Stats"] as Stats;
            bool isWinner = doorState.ChosenDoor == doorState.WinningDoor().DoorNumber;
            if (isWinner)
            {
                stats.AddWin();
            }
            else
            {
                stats.AddLoss();
            }
            Session["Stats"] = stats;
            return View(isWinner);
        }
    }
}