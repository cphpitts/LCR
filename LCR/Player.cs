using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LCR
{
    public class Player
    {   
        public string Name { get; set; }
        public int Bank { get; set; }
        public bool Active { get; set; }
        public int timesWon { get; set; }

        public void PlayerTurn(Die die, Player leftPlayer, Player rightPlayer)
        {
            Console.WriteLine("{0} has {1} chips", this.Name, this.Bank);
            int timesRoll;
            if (this.Bank == 0)
            {
                timesRoll = 0;
            }
            else if (this.Bank > 2)
            {
                timesRoll = 3;
            }
            else
            {
                timesRoll = this.Bank;
            }

           List<string> dieResults = die.RollDie(timesRoll);
           for ( int i = 0; i < dieResults.Count(); i++)
            {
                Console.WriteLine("{0} rolled {1}", this.Name, dieResults[i]);
                if (dieResults[i] == "Left")
                {
                    Console.WriteLine("Pass 1 to the left");
                    this.Bank -= 1;
                    leftPlayer.Bank += 1;
                }
                else if (dieResults[i] == "Right")
                {
                    Console.WriteLine("Pass 1 to the right");
                    this.Bank -= 1;
                    rightPlayer.Bank += 1;
                }
                else if (dieResults[i] == "Center")
                {
                    Console.WriteLine("Put 1 in the pot");
                    this.Bank -= 1;
                }
                else
                {
                    Console.WriteLine("Nothing");
                }
            }
            Console.WriteLine("{0} has {1} chips left.\n", this.Name, this.Bank);
            if (this.Bank == 0)
            {
                this.Active = false;
            }
            else
            {
                this.Active = true;
            }

        }
    }
}
