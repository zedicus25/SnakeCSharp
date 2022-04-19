using System;
using System.Threading;

namespace SnakeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            while (true)
            {
                gameManager.StartGame();
                Thread.Sleep(2000);
                Console.ReadKey();
            }
     
           
            
        }
    }
}
