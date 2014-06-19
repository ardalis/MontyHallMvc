namespace MontyHall.Models
{
    public class Stats
    {
        public int Wins { get; set; }
        private int losses;

        public void AddWin()
        {
            Wins++;
        }

        public void AddLoss()
        {
            losses++;
        }

        public int TotalGames()
        {
            return Wins + losses;
        }

        public float WinPercentage()
        {
            if (TotalGames() == 0) return 0;
            return (float)Wins/(float)TotalGames() * 100;
        }
    }
}