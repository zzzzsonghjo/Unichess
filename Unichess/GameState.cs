namespace Unichess
{
    public class GameState
    {
        public Board Board { get; set; }
        private HistoryStack History { get; set; }
        private HistoryStack RedoStack { get; set; }

        private int Rows { get; set; }
        private int Cols { get; set; }
        private int WinCounts { get; set; }

        public int Round { get => History.Count + 1; }
        public int? Winner { get; set; }
        public List<Position> FitPositions { get; set; }

        private bool Limited { get; set; }
        private static readonly Position[] _offsets = [new(1, 2), new(2, 1), new(-1, 2), new(2, -1), new(1, -2), new(-2, 1), new(-1, -2), new(-2, -1)];

        public GameState(GameConfig config)
        {
            Board = new Board(config.Rows, config.Cols);
            History = new HistoryStack();
            RedoStack = new HistoryStack();
            FitPositions = [];
            Rows = config.Rows; Cols = config.Cols;
            Winner = null; Limited = config.Limited;
            WinCounts = config.WinCount;
        }

        public bool Undo()
        {
            if (History.Count > 0)
            {
                var piece = History.Pop();
                RedoStack.Push(piece);
                Board.BoardState[piece.Position.Row, piece.Position.Col] = 0;
                GetFitPositions();
                return true;
            }
            return false;
        }

        public bool Redo()
        {
            if (RedoStack.Count > 0)
            {
                var piece = RedoStack.Pop();
                History.Push(piece);
                Board.BoardState[piece.Position.Row, piece.Position.Col] = piece.Color;
                GetFitPositions();
                return true;
            }
            return false;
        }

        public bool IsFit(Position position)
        {
            if ((!Board.InRange(position)) || (!Board.IsEmpty(position)))
            {
                return false;
            }
            if (Round <= 2 || Limited == false) return true;
            foreach (var fitPosition in FitPositions)
            {
                if (fitPosition.Row == position.Row && fitPosition.Col == position.Col)
                {
                    return true;
                }
            }
            return false;
        }

        public bool getWinner(Piece piece)
        {
            // 纵向
            int count = 1;
            for (int row = piece.Position.Row + 1; row < Rows; row++)
            {
                if (Board.BoardState[row, piece.Position.Col] == piece.Color) count++;
                else break;
            }
            for (int row = piece.Position.Row - 1; row >= 0; row--)
            {
                if (Board.BoardState[row, piece.Position.Col] == piece.Color) count++;
                else break;
            }
            if (count >= WinCounts)
            {
                Winner = piece.Color;
                return true;
            }

            // 横向
            count = 1;
            for (int col = piece.Position.Col + 1; col < Cols; col++)
            {
                if (Board.BoardState[piece.Position.Row, col] == piece.Color) count++;
                else break;
            }
            for (int col = piece.Position.Col - 1; col >= 0; col--)
            {
                if (Board.BoardState[piece.Position.Row, col] == piece.Color) count++;
                else break;
            }
            if (count >= WinCounts)
            {
                Winner = piece.Color;
                return true;
            }

            // 左上到右下
            count = 1;
            for (int row = piece.Position.Row + 1, col = piece.Position.Col + 1; row < Rows && col < Cols; row++, col++)
            {
                if (Board.BoardState[row, col] == piece.Color) count++;
                else break;
            }
            for (int row = piece.Position.Row - 1, col = piece.Position.Col - 1; row >= 0 && col >= 0; row--, col--)
            {
                if (Board.BoardState[row, col] == piece.Color) count++;
                else break;
            }
            if (count >= WinCounts)
            {
                Winner = piece.Color;
                return true;
            }

            // 右上到左下
            count = 1;
            for (int row = piece.Position.Row + 1, col = piece.Position.Col - 1; row < Rows && col >= 0; row++, col--)
            {
                if (Board.BoardState[row, col] == piece.Color) count++;
                else break;
            }
            for (int row = piece.Position.Row - 1, col = piece.Position.Col + 1; row >= 0 && col < Cols; row--, col++)
            {

                if (Board.BoardState[row, col] == piece.Color) count++;
                else break;
            }
            if (count >= WinCounts)
            {
                Winner = piece.Color;
                return true;
            }

            return false;
        }

        private bool GetFitPositions()
        {
            FitPositions.Clear();
            if (Round <= 2 || Limited == false) return false;
            var now = History.SecondPeek().Position;
            foreach (var offset in _offsets)
            {
                var next = now + offset;
                if (Board.InRange(next) && Board.IsEmpty(next))
                {
                    FitPositions.Add(next);
                }
            }
            if (FitPositions.Count == 0)
            {
                Winner = History.Peek().Color;
                return true;
            }
            return false;
        }

        public bool Put(Position position)
        {
            if (IsFit(position))
            {
                History.Push(new Piece(position, (Round % 2 == 1) ? Piece.Black : Piece.White));
                Board.BoardState[position.Row, position.Col] = History.Peek().Color;
                GetFitPositions();
                getWinner(History.Peek());
                return true;
            }
            return false;
        }
    }
}
