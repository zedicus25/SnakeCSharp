namespace SnakeApp
{
    public class Position
    {
        public int Left { get; }
        public int Top { get; }

        public Position(int top, int left)
        {
            Top = top;
            Left = left;
        }

        public Position(Position tmp)
        {
            Top = tmp.Top;
            Left = tmp.Left;
        }
    }
}