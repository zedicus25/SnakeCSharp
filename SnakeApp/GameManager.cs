using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeApp
{
    internal class GameManager
    {
        private int _mapWidth = 20;
        private int _mapHeight = 30;
        private Snake _snake;
        private Apple _apple;
        private Direction _direction;

        public GameManager()
        {
            _snake = new Snake(new Position(5, 5));
            _apple = new Apple();
            _direction = Direction.Right;
        }
        public void StartGame()
        {
            Console.Clear();
            DrawField();

            _apple = _apple.GenerateApple(_mapHeight, _mapWidth, _snake);
            _apple.Render();

            while (true)
            {
                Direction old = _direction;
                if (_direction == old)
                    _direction = UserInput();

                if(_snake.Head.Position.Top == _apple.Position.Top &&
                    _snake.Head.Position.Left == _apple.Position.Left)
                {
                    _snake.Move(_direction, true);
                    _apple = _apple.GenerateApple(_mapHeight, _mapWidth, _snake);
                    _apple.Render();
                }
                else
                {
                    _snake.Move(_direction);
                }

                if (_snake.Head.Position.Top == _mapHeight - 2
                    || _snake.Head.Position.Top == 0
                    || _snake.Head.Position.Left == _mapWidth - 2
                    || _snake.Head.Position.Left == 0 ||
                    _snake.Body.Any(b => b.Position.Left == _snake.Head.Position.Left 
                    && b.Position.Top == _snake.Head.Position.Top))
                    break;

                Thread.Sleep(250);
            }
        }

        public void DrawField()
        {
            for (int i = 0; i < _mapWidth; i++)
            {
                Console.SetCursorPosition(i,0);
                Console.Write("*");
                Console.SetCursorPosition(i, _mapHeight-1);
                Console.Write("*");
            }
            for (int i = 0; i < _mapHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("*");
                Console.SetCursorPosition(_mapWidth-1, i);
                Console.Write("*");
            }
        }

        private Direction UserInput()
        {
            if (!Console.KeyAvailable)
                return _direction;

            ConsoleKey key = Console.ReadKey(true).Key;

            _direction = key switch
            {
                ConsoleKey.UpArrow when _direction != Direction.Down => Direction.Up,
                ConsoleKey.DownArrow when _direction != Direction.Up => Direction.Down,
                ConsoleKey.LeftArrow when _direction != Direction.Right => Direction.Left,
                ConsoleKey.RightArrow when _direction != Direction.Left => Direction.Right,
                _ => _direction
            };

            return _direction;
        }
    }
}
