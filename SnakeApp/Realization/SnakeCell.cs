using System;

namespace SnakeApp
{
    public class SnakeCell : IRenderer
    {
        public Position Position { get; private set; }

        public SnakeCell(Position position)
        {
            Position = new Position(position);
        }

        public void Render()
        {
            Console.SetCursorPosition(Position.Left, Position.Top);
            Console.WriteLine("#");
        }
        
        public SnakeCell RightByN(int n) => new SnakeCell(new Position(Position.Top, Position.Left + n));
        public SnakeCell DownByN(int n) => new SnakeCell(new Position(Position.Top+n, Position.Left));
    }
}