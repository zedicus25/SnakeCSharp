using System;
using System.Collections.Generic;

namespace SnakeApp
{
    public class MoveDirection
    {
        private List<Func<SnakeCell>> _moves;

        public Func<SnakeCell> this[ConsoleKey key]
        {
            get
            {
                if (key == ConsoleKey.RightArrow)
                    return _moves[0];
                if (key == ConsoleKey.LeftArrow)
                    return _moves[1];
                if (key == ConsoleKey.DownArrow)
                    return _moves[2];
                if (key == ConsoleKey.UpArrow) 
                    return _moves[3];
                return null;
            }
            set => _moves[0] = value;
        }

        public MoveDirection(params Func<SnakeCell>[] arg)
        {
            _moves = new List<Func<SnakeCell>>();
            for (int i = 0; i < arg.Length; i++)
            {
                _moves.Add(arg[i]);
            }
        }
    }
}