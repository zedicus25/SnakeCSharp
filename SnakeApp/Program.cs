using System;
using System.Threading;

namespace SnakeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Snake s = new Snake();
            while (true)
            {
                s.Render();
                s.Move(Direction.Right);
                Thread.Sleep(1000);
            }
            
        }
    }
}
