using System;
using System.Collections.Generic;

namespace SnakeApp 
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    public class Snake : IRenderer
    {
        private List<SnakeCell> _body;
        private SnakeCell Head => _body[0];

        public Snake()
        {
            _body = new List<SnakeCell>();
            _body.Add(new SnakeCell(new Position(0,0)));
        }
        public void Move(Direction direction)
        {
            SnakeCell newHead = null;

            switch (direction)
            {
                case Direction.Up:
                    newHead = Head.DownByN(-1);
                    break;

                case Direction.Left:
                    newHead = Head.RightByN(-1);
                    break;

                case Direction.Down:
                    newHead = Head.DownByN(1);
                    break;

                case Direction.Right:
                    newHead = Head.RightByN(1);
                    break;

            }

            _body.Insert(0, newHead);
            _body.RemoveAt(_body.Count - 1);
        }

        public void Render()
        {
            Console.Clear();
            Console.SetCursorPosition(Head.Position.Left+1, Head.Position.Top);
            Console.Write("@");

            foreach (var cell in _body)
            {
                cell.Render();
            }
        }
    }
}