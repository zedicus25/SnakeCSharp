using System;
using System.Threading;

namespace SnakeApp
{
    internal class GameManager
    {
        private int _mapWidth = 30;
        private int _mapHeight = 20;
        private Snake _snake;
        private Apple _apple;
        private ConsoleKeyInfo _key;
        private char _borderIcon = '#';
        public bool SnakeMove => _snake.IsDead(_mapHeight, _mapWidth);

        public GameManager()
        {
            _snake = new Snake(new Position(5, 5));
            _apple = new Apple();
        }
        public void StartGame()
        {
            Console.CursorVisible = false;
            Console.Clear();
            DrawField();

            _apple.GenerateNewPosition(_mapHeight, _mapWidth);
            _apple.Render();

            while (true)
            {
                UserInput();
                ConsoleKey old = _key.Key;
                if (_key.Key == 0)
                    old = ConsoleKey.RightArrow;

                if(_snake.Head.Position.Equals(_apple.Position))
                {
                    _snake.Move(old, true);
                    _apple.GenerateNewPosition(_mapHeight, _mapWidth);
                    _apple.Render();
                }
                else
                {
                    _snake.Move(old);
                }

                if (_snake.IsDead(_mapHeight,_mapWidth))
                    break;

                Thread.Sleep(250);
            }

            Console.CursorVisible = true;
        }

        private void DrawField()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            for (int i = 0; i < _mapWidth; i++)
            {
                Console.SetCursorPosition(i,0);
                Console.Write(_borderIcon);
                Console.SetCursorPosition(i, _mapHeight-1);
                Console.Write(_borderIcon);
            }
            for (int i = 0; i < _mapHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(_borderIcon);
                Console.SetCursorPosition(_mapWidth-1, i);
                Console.Write(_borderIcon);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void UserInput()
        {
            if (!Console.KeyAvailable)
                return;
            ConsoleKeyInfo key = Console.ReadKey(true);
            _key = _key.Key != key.Key ? key : _key;
        }

    }
}
