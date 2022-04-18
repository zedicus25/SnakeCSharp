using System;

namespace SnakeApp
{
    public class Apple : IRenderer
    {
        private Position _pos;

        public Apple(Position position)
        {
            _pos = new Position(position);
        }
        public void Render()
        {
            Console.SetCursorPosition(_pos.Left, _pos.Top);
            Console.Write("0");
            Console.SetCursorPosition(0,0);
        }
    }
}