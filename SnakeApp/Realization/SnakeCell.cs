using System;

namespace SnakeApp
{
    public class SnakeCell : IRenderer
    {
        public Position Position { get; private set; }
        private char _icon = '#';

        public SnakeCell(Position pos)
        {
            Position = new Position(pos.Top, pos.Left);
        }

        public SnakeCell(int top, int left)
        {
            Position = new Position(top,left);
        }

        public void Render()
        {
            Console.SetCursorPosition(Position.Left, Position.Top);
            Console.Write(_icon);
        }
    }
}