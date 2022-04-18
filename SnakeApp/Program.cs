using System;

namespace SnakeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Apple apple = new Apple(new Position(10, 5));
            apple.Render();
        }
    }
}
