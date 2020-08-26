using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCR
{
    public class Game
    {
        private List<Player> _Players = new List<Player>();
        public List<Player> Players {  get { return _Players; } set { _Players = value; } }
        public int Center { get; set; }

        public void SetPlayers()
        {
            Console.WriteLine("How many players?");
            int numPlayers = Convert.ToInt32(Console.ReadLine());
            for (int i  = 0; i< numPlayers; i++)
            {
                Console.WriteLine("Player {0}'s Name: ", i+1);
                string playerName = Console.ReadLine();
                Player player = new Player() { Bank = 3, Name = playerName, Active = true, timesWon = 0 };
                Players.Add(player);
            }
        }

        public void Reset()
        {
            for (int i = 0; i<this.Players.Count(); i++)
            {
                this.Players[i].Bank = 3;
                this.Players[i].Active = true;
            }
        }
    }
}
