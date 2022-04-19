namespace SnakeApp
{
    public class Position
    {
        public int Left { get; set; }
        public int Top { get; set; }

        public Position(int top, int left)
        {
            Top = top;
            Left = left;
        }
    }
}