namespace Unichess
{
    public class Board
    {
        public int[,] BoardState { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }

        public Board(int rows,int cols)
        {
            Rows = rows;
            Cols = cols;
            BoardState = new int[rows, cols];
        }

        public bool InRange(Position position)
        {
            return position.Row >= 0 && position.Row < Rows && position.Col >= 0 && position.Col < Cols;
        }

        public bool IsEmpty(Position position)
        {
            return BoardState[position.Row, position.Col] != Piece.White && BoardState[position.Row, position.Col] != Piece.Black;
        }
    }
}
