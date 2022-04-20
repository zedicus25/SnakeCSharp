using System;
using System.Threading;

namespace SnakeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            int userInput = -1;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Play");
                Console.WriteLine("0 - Exit");
                string str = Console.ReadLine();
                if (int.TryParse(str, out userInput))
                {
                    switch (userInput)
                    {
                        case 1:
                            gameManager = new GameManager();
                            Console.Clear();
                            do
                            {
                                gameManager.StartGame();
                                Thread.Sleep(1000);
                                
                            } while (gameManager.SnakeMove == false);
                            Console.Clear();
                            Console.WriteLine("Game over!");
                            Thread.Sleep(1000);
                            break;
                    }
                }
            } while (userInput != 0);
        }
    }
}
