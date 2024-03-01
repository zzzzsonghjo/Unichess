using Unichess.New.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Unichess.New.GameStates
{
    public class GobangState : GameState
    {
        public GobangState(int rows, int cols) : base(rows, cols)
        {
        }

        protected override List<Piece> PiecesList => throw new NotImplementedException();

        public override int? Judge()
        {
            return GobangstyleJudge(5, 5);
        }

        public override void React(Position position)
        {
            throw new NotImplementedException();
        }

        public override void Redo()
        {
            throw new NotImplementedException();
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 五子棋式胜负判断
        /// </summary>
        /// <param name="horiReq">横向赢棋所需棋子数</param>
        /// <param name="slashReq">纵向赢棋所需棋子数</param>
        /// <returns>胜者，若无胜者则为空</returns>
        protected int? GobangstyleJudge(int horiReq, int slashReq)
        {
            var piece = History.Peek();

            // 纵向
            int count = 1;
            for (int row = piece.Position.Row + 1; row < Rows; row++)
            {
                if (Board.Get(new(row, piece.Position.Col)) == piece.Color) count++;
                else break;
            }
            for (int row = piece.Position.Row - 1; row >= 0; row--)
            {
                if (Board.Get(new(row, piece.Position.Col)) == piece.Color) count++;
                else break;
            }
            if (count >= horiReq)
            {
                return piece.Color;
            }

            // 横向
            count = 1;
            for (int col = piece.Position.Col + 1; col < Cols; col++)
            {
                if (Board.Get(new(piece.Position.Row, col)) == piece.Color) count++;
                else break;
            }
            for (int col = piece.Position.Col - 1; col >= 0; col--)
            {
                if (Board.Get(new(piece.Position.Row, col)) == piece.Color) count++;
                else break;
            }
            if (count >= horiReq)
            {
                return piece.Color;
            }

            // 左上到右下
            count = 1;
            for (int row = piece.Position.Row + 1, col = piece.Position.Col + 1; row < Rows && col < Cols; row++, col++)
            {
                if (Board.Get(new(row, col)) == piece.Color) count++;
                else break;
            }
            for (int row = piece.Position.Row - 1, col = piece.Position.Col - 1; row >= 0 && col >= 0; row--, col--)
            {
                if (Board.Get(new(row, col)) == piece.Color) count++;
                else break;
            }
            if (count >= slashReq)
            {
                return piece.Color;
            }

            // 右上到左下
            count = 1;
            for (int row = piece.Position.Row + 1, col = piece.Position.Col - 1; row < Rows && col >= 0; row++, col--)
            {
                if (Board.Get(new(row, col)) == piece.Color) count++;
                else break;
            }
            for (int row = piece.Position.Row - 1, col = piece.Position.Col + 1; row >= 0 && col < Cols; row--, col++)
            {

                if (Board.Get(new(row, col)) == piece.Color) count++;
                else break;
            }
            if (count >= slashReq)
            {
                return piece.Color;
            }

            return null;
        }
    }
}
