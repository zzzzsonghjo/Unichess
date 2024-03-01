namespace Unichess
{
    public class Position(int row, int col)
    {
        public int Row { get; set; } = row;
        public int Col { get; set; } = col;

        static public Position operator +(Position a, Position b)
        {
            return new Position(a.Row + b.Row, a.Col + b.Col);
        }
    }
}
