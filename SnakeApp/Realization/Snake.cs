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
                Body.Enqueue(new SnakeCell(Head.Position.Top, Head.Position.Left));
            }

            Render();
        }

        public void Render()
        {
            Head.Render();
            foreach (var cell in Body)
            {
                cell.Render();
            }
        }

        public void Move(Direction direction, bool eat = false)
        {
            Clear();
            
            Body.Enqueue(new SnakeCell(Head.Position.Top, Head.Position.Left));
            if (!eat)
                Body.Dequeue();

            Head = direction switch
            {
                Direction.Right => new SnakeCell(Head.Position.Top, Head.Position.Left + 1),
                Direction.Left => new SnakeCell(Head.Position.Top, Head.Position.Left - 1),
                Direction.Up => new SnakeCell(Head.Position.Top - 1, Head.Position.Left),
                Direction.Down => new SnakeCell(Head.Position.Top + 1, Head.Position.Left),
                _ => Head
            };

            Render();
        }

        public void Clear()
        {
            Head.Clear();
            foreach (var item in Body)
            {
                item.Clear();
            }
        }
    }
}