using System;
using System.Collections.Generic;

namespace SnakeApp 
{
    public class Snake : IRenderer
    {
        public SnakeCell Head { get; private set; }

        public Queue<SnakeCell> Body { get; }

        public Snake(Position spawnPos)
        {
            Head = new SnakeCell(spawnPos);
            Body = new Queue<SnakeCell>(25);
            for (int i = 2; i >= 0; i--)
            {
                Body.Enqueue(new SnakeCell(Head.Position.Left -i - 1, Head.Position.Top));
            }

            Render();
        }

        public void Render()
        {

            foreach (var cell in Body)
            {
                cell.Render();
            }
        }

        public void Move(Direction direction, bool eat = false)
        {
            Head.Render();
            Body.Enqueue(new SnakeCell(Head.Position.Left, Head.Position.Top));
            if (!eat)
                Body.Dequeue();

            Head = direction switch
            {
                Direction.Down => new SnakeCell(Head.Position.Top, Head.Position.Left + 1),
                Direction.Up => new SnakeCell(Head.Position.Top, Head.Position.Left - 1),
                Direction.Left => new SnakeCell(Head.Position.Top - 1, Head.Position.Left),
                Direction.Right => new SnakeCell(Head.Position.Top + 1, Head.Position.Left),
                _ => Head
            };

            Render();
        }
    }
}