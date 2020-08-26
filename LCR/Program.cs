using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCR
{
    class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            Die die = new Die();
            game.SetPlayers();

            Console.WriteLine("How many games would you like to play?");
            int gameLoop = Convert.ToInt32(Console.ReadLine());

            for (int j = 0; j < gameLoop; j++)
            {
                while (game.Players.Where(x => x.Active == true).Count() > 1)
                {
                    int test = game.Players.Where(x => x.Active == true).Count();
                    for (int i = 0; i < game.Players.Count(); i++)
                    {
                        Player leftPlayer, rightPlayer;
                        if (i == 0)
                        {
                            rightPlayer = game.Players[game.Players.Count() - 1];
                            leftPlayer = game.Players[i + 1];
                        }
                        else if (i == game.Players.Count() - 1)
                        {
                            rightPlayer = game.Players[i - 1];
                            leftPlayer = game.Players[0];
                        }
                        else
                        {
                            leftPlayer = game.Players[i + 1];
                            rightPlayer = game.Players[i - 1];
                        }
                        game.Players[i].PlayerTurn(die, leftPlayer, rightPlayer);
                        if (game.Players.Where(x => x.Active == true).Count() == 1)
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine("{0} WINS!", game.Players.Where(x => x.Active == true).First().Name);
                game.Players.Where(x => x.Active == true).First().timesWon += 1;
                game.Reset();
            }
            Console.WriteLine("\n-----------------------------\nFinal Results:");
            for (int i = 0; i < game.Players.Count(); i++)
            {
                Console.WriteLine("{0} won {1} times.", game.Players[i].Name, game.Players[i].timesWon);
            }
            Console.ReadLine();
        }
        
    }
}
