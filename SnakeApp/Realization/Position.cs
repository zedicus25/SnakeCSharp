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

        public Position RightByN(int n) => new Position(Top, Left + n);
        public Position DownByN(int n) => new Position(Top+n, Left);
    }
}