using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class BlackJackMain
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Game game = new Game();
                game.PlayGame();

                Console.WriteLine("\nPress any key for new game or 'q' to quit.");
                var response = Console.ReadLine();
                if (response == "q")
                    break;
            }
        }
    }
}
