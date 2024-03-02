namespace Unichess
{
    public class Board(int rows, int cols)
    {
        private int?[,] BoardState { get; set; } = new int?[rows, cols];
        public int Rows { get; set; } = rows;
        public int Cols { get; set; } = cols;

        private bool IsIn(Position position) =>
            position.Row >= 0 && position.Row < Rows && position.Col >= 0 && position.Col < Cols;

        public bool Check(Position position) =>
            IsIn(position) && BoardState[position.Row, position.Col] == null;

        public void Set(Position position, int type)
        {
            if (IsIn(position))
            {
                if (Check(position)) { BoardState[position.Row, position.Col] = type; }
                else { throw new Exception("The position has already occupied"); }
            }
            else { throw new Exception("Invalid Position"); }
        }

        public int? Get(Position position) =>
            IsIn(position) ? BoardState[position.Row, position.Col] : null;

        public int? Remove(Position position)
        {
            if (IsIn(position))
            {
                var type = BoardState[position.Row, position.Col];
                BoardState[position.Row, position.Col] = null;
                return type;
            }
            else { throw new Exception("Invalid Position"); }
        }

        public void Clear()
        {
            BoardState = new int?[Rows, Cols];
        }

        public bool IsFull() => BoardState.Cast<int?>().All(x => x != null);
        public bool IsEmpty() => BoardState.Cast<int?>().All(x => x == null);
    }
}
