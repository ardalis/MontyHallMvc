using System;
using System.Linq;
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
            int otherDoor = doorState.OtherDoor();

            var eligibleDoors = doorState.Doors
                .Where(d => !d.IsWinner && d.DoorNumber != id);

            int doorsToSkip = new Random().Next(eligibleDoors.Count());

            var chosenDoor = eligibleDoors.Skip(doorsToSkip).First();
            chosenDoor.IsOpen = true;

            return View(doorState);
        }
         
        public ActionResult Confirm(int id, string choice)
        {
            var doorState = Session["DoorState"] as DoorState;
            if (doorState == null)
            {
                return RedirectToAction("Index", "Home");
            }
            doorState.ChosenDoor = id;
            string sessionKey = "StayStats";
            if(choice=="switch")
            {
                sessionKey = "SwitchStats";
            }
            var stats = Session[sessionKey] as Stats;
            bool isWinner = doorState.ChosenDoor == doorState.WinningDoor().DoorNumber;
            if (isWinner)
            {
                stats.AddWin();
            }
            else
            { 
                stats.AddLoss();
            }
            Session[sessionKey] = stats;
            return View(isWinner);
        }
    }
}