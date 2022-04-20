using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeApp 
{
    public class Snake : IRenderer
    {
        public SnakeCell Head { get; private set; }
        private Queue<SnakeCell> _body { get; }
        private MoveDirection _moves;

        public Snake(Position spawnPos)
        {
            Head = new SnakeCell(spawnPos);
            _body = new Queue<SnakeCell>(25);
            _moves = new MoveDirection(MoveRight, MoveLeft, MoveDown, MoveUp);
            Render();
        }

        public void Render()
        {
            Head.Render();
            foreach (var cell in _body)
            {
                cell.Render();
            }
        }

        public void Move(ConsoleKey key, bool eat = false)
        {
            Clear();
            
            _body.Enqueue(new SnakeCell(Head.Position.Top, Head.Position.Left));
            if (!eat)
                _body.Dequeue();

            Head = _moves[key]?.Invoke();

            Render();
        }

        public void Clear()
        {
            Head.Clear();
            foreach (var item in _body)
            {
                item.Clear();
            }
        }

        public bool IsDead(int mapHeight, int mapWidth)
        {
            return Head.Position.Top == mapHeight - 2 || Head.Position.Left == mapWidth - 2 || 
                   Head.Position.Top == 1 || Head.Position.Left == 1 ||
                   _body.Any(b => b.Position.Equals(Head.Position));
        }

        private SnakeCell MoveRight() => new SnakeCell(Head.Position.Top, Head.Position.Left + 1);

        private SnakeCell MoveLeft() => new SnakeCell(Head.Position.Top, Head.Position.Left - 1);

        private SnakeCell MoveUp() => new SnakeCell(Head.Position.Top - 1, Head.Position.Left);
        private SnakeCell MoveDown() => new SnakeCell(Head.Position.Top + 1, Head.Position.Left);
    }
}