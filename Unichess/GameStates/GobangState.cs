using Unichess.Pieces;

namespace Unichess.GameStates
{
    public class GobangState(int rows, int cols) : GameState(rows, cols)
    {
        protected override List<Piece> PiecesList => [new BlackPiece(), new WhitePiece()];

        public override string StateName => "五子棋";

        public override int? Judge()
        {
            if (Board.IsFull())
            {
                if (GobangstyleJudge(5, 5) == null)
                    return 0;
            }
            return GobangstyleJudge(5, 5);
        }

        public override void React(Position position)
        {
            if (!IsRunning) return;
            int type = (Round + 1) % 2;
            if (Board.Check(position))
            {
                var piece = PiecesList[type];
                piece.Position = position;
                History.Push(piece);
                Board.Set(position, History.Peek().Type);
                DisplayList.Add(piece);
            }
        }

        public override void Undo()
        {
            if (History.Count > 0)
            {
                Board.Remove(History.Peek().Position);
                DisplayList.RemoveAt(DisplayList.Count - 1);
                History.Pop();
            }
        }

        public override void Restart()
        {
            History.Clear();
            DisplayList.Clear();
            Board.Clear();
            IsRunning = true;
        }

        /// <summary>
        /// 五子棋式胜负判断
        /// </summary>
        /// <param name="horiReq">横向赢棋所需棋子数</param>
        /// <param name="slashReq">斜向赢棋所需棋子数</param>
        /// <returns>胜者，若无胜者则为空</returns>
        protected int? GobangstyleJudge(int horiReq, int slashReq)
        {
            var piece = History.Peek();

            // 纵向
            int count = 1;
            for (int row = piece.Position.Row + 1; row < Rows; row++)
            {
                if (Board.Get(new(row, piece.Position.Col)) == piece.Type) count++;
                else break;
            }
            for (int row = piece.Position.Row - 1; row >= 0; row--)
            {
                if (Board.Get(new(row, piece.Position.Col)) == piece.Type) count++;
                else break;
            }
            if (count >= horiReq)
            {
                return piece.Type;
            }

            // 横向
            count = 1;
            for (int col = piece.Position.Col + 1; col < Cols; col++)
            {
                if (Board.Get(new(piece.Position.Row, col)) == piece.Type) count++;
                else break;
            }
            for (int col = piece.Position.Col - 1; col >= 0; col--)
            {
                if (Board.Get(new(piece.Position.Row, col)) == piece.Type) count++;
                else break;
            }
            if (count >= horiReq)
            {
                return piece.Type;
            }

            // 左上到右下
            count = 1;
            for (int row = piece.Position.Row + 1, col = piece.Position.Col + 1; row < Rows && col < Cols; row++, col++)
            {
                if (Board.Get(new(row, col)) == piece.Type) count++;
                else break;
            }
            for (int row = piece.Position.Row - 1, col = piece.Position.Col - 1; row >= 0 && col >= 0; row--, col--)
            {
                if (Board.Get(new(row, col)) == piece.Type) count++;
                else break;
            }
            if (count >= slashReq)
            {
                return piece.Type;
            }

            // 右上到左下
            count = 1;
            for (int row = piece.Position.Row + 1, col = piece.Position.Col - 1; row < Rows && col >= 0; row++, col--)
            {
                if (Board.Get(new(row, col)) == piece.Type) count++;
                else break;
            }
            for (int row = piece.Position.Row - 1, col = piece.Position.Col + 1; row >= 0 && col < Cols; row--, col++)
            {

                if (Board.Get(new(row, col)) == piece.Type) count++;
                else break;
            }
            if (count >= slashReq)
            {
                return piece.Type;
            }

            return null;
        }
    }
}
