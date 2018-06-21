using System.Collections.Generic;
using System.Linq;

namespace MontyHall.Models
{
    public class Door
    {
        public int DoorNumber { get; set; }
        public bool IsOpen { get; set; }
        public bool IsWinner { get; set; }

        public override string ToString()
        {
            string result = "Door Number " + DoorNumber + " ";
            if (IsOpen)
            {
                result += "is open ";
                if (IsWinner)
                {
                    result += "and has a NEW CAR!!!";
                }
                else
                {
                    result += "and has a GOAT.";
                }
            }
            else
            {
                result += "is closed.";
            }
            return result;
        }
    }

    public class DoorState
    {
        public List<Door> Doors { get; private set; }
        public int? ChosenDoor { get; set; }

        public int OtherDoor()
        {
            if (!ChosenDoor.HasValue) return 0;
            return Doors
                .Where(d => !d.IsOpen && d.DoorNumber != ChosenDoor.Value)
                .First(d => d.DoorNumber != ChosenDoor.Value).DoorNumber;
        }

        public Door WinningDoor()
        {
            return Doors.FirstOrDefault(d => d.IsWinner);
        }

        public DoorState(int quantity, int winningDoorNumberOneBased)
        {
            Doors = new List<Door>();
            for (int i = 1; i <= quantity; i++)
            {
                var door = new Door() {DoorNumber = i};
                if (i == winningDoorNumberOneBased) door.IsWinner = true;
                Doors.Add(door);
            }
        }

        public override string ToString()
        {
            var result = "";
            foreach (var door in Doors)
            {
                result += door + "<br />";
            }
            return result; 
        }
    }
}