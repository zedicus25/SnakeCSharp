using System;
using System.Threading;

namespace SnakeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            //Console.WriteLine();
            while (gameManager.SnakeMove == false)
            {
                gameManager.StartGame();
                Thread.Sleep(2000);
            }
            Console.Clear();
            Console.WriteLine("Game over!");
            
        }
    }
}
