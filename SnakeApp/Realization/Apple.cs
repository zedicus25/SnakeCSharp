using System;

namespace SnakeApp
{
    public class Apple : IRenderer
    {
        public Position Position { get; private set; }

        public Apple()
        {
            Position = new Position(0, 0);
        }
        public Apple(Position pos)
        {
            Position = new Position(pos.Top, pos.Left);
        }

        public Apple GenerateApple(int height, int width, Snake s)
        {
            Apple apl = null;
            Random r = new Random();
            do
            {
                apl = new Apple(new Position(r.Next(1,width-2),r.Next(1,height-2)));

            } while (s.Head.Position.Top == apl.Position.Top && s.Head.Position.Left == apl.Position.Left);

            return apl;
        }
        public void Render()
        {
            Console.SetCursorPosition(Position.Left, Position.Top);
            Console.Write("0");
        }
    }
}