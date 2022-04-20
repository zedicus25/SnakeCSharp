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

        public override bool Equals(object? obj)
        {
            if (obj is Position)
            {
                Position tmp = obj as Position;
                if (Left == tmp.Left && Top == tmp.Top) 
                    return true;
            }

            return false;
        }
    }
}