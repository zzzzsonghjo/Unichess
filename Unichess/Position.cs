namespace Unichess
{
    public class Position(int row, int col)
    {
        public int Row { get; set; } = row;
        public int Col { get; set; } = col;

        public static Position operator +(Position p1, Position p2)
        {
            return new Position(p1.Row + p2.Row, p1.Col + p2.Col);
        }

        public override bool Equals(object obj)
        {
            if (obj is Position position)
            {
                return position.Row == Row && position.Col == Col;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
