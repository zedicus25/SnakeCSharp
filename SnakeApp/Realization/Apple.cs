using System;

namespace SnakeApp
{
    public class Apple : IRenderer
    {
        public Position Position { get; private set; }
        private char _icon = '0';

        public Apple()
        {
            Position = new Position(0, 0);
        }
        public Apple(Position pos)
        {
            Position = new Position(pos.Top, pos.Left);
        }

        public void GenerateNewPosition(int height, int width)
        {
            Random r = new Random();
            Position = new Position(r.Next(2,height-2),r.Next(2,width-2));
        }
        public void Render()
        {
            Console.SetCursorPosition(Position.Left, Position.Top);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(_icon);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Clear()
        {
            Console.SetCursorPosition(Position.Left, Position.Top);
            Console.Write(" ");
        }
    }
}