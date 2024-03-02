using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unichess.Pieces;

namespace Unichess.GameStates
{
    public class MaginotState : GobangState
    {
        private List<Position> FitPositions { get; set; }
        private List<Position> Offsets => [new(1, 2), new(2, 1), new(-1, 2), new(2, -1), new(1, -2), new(-2, 1), new(-1, -2), new(-2, -1)];

        public MaginotState(int rows, int cols) : base(rows, cols)
        {
            FitPositions = [];
        }

        protected override List<Piece> PiecesList => [new BlackPiece(), new WhitePiece(), new BlackGhostPiece(), new WhiteGhostPiece()];

        public override string StateName => "马奇诺棋";

        public override int? Judge()
        {
            if (Round > 2)
            {
                if (FitPositions.Count == 0)
                {
                    return History.Peek2().Type;
                }
            }
            return GobangstyleJudge(5, 6);
        }

        private void RmFitPosFromDisplay()
        {
            DisplayList.RemoveRange(DisplayList.Count - FitPositions.Count, FitPositions.Count);
        }

        private void GetFitPositions()
        {
            Position lastPosition = History.Peek2().Position;
            foreach (var offset in Offsets)
            {
                var fitPosition = lastPosition + offset;
                if (Board.Check(fitPosition))
                {
                    FitPositions.Add(lastPosition + offset);
                    var ghost = PiecesList[History.Peek2().Type + 2];
                    ghost.Position = fitPosition;
                    DisplayList.Add(ghost);
                }
            }
        }

        public override void React(Position position)
        {
            if (!IsRunning) return;
            int type = (Round + 1) % 2;
            if (Board.Check(position))
            {
                if (Round > 2 && !FitPositions.Contains(position)) return;
                var piece = PiecesList[type];
                piece.Position = position;
                History.Push(piece);
                Board.Set(position, History.Peek().Type);
                FitPositions.Clear();
                RmFitPosFromDisplay();
                DisplayList.Add(piece);
                if (Round > 2)
                {
                    GetFitPositions();
                }
            }
        }

        public override void Redo()
        {
            if (RedoRec.Count > 0)
            {
                History.Push(RedoRec.Pop());
                Board.Set(History.Peek().Position, History.Peek().Type);
                DisplayList.Add(History.Peek());
                if (Round > 2)
                {
                    RmFitPosFromDisplay();
                    GetFitPositions();
                }
            }
        }

        public override void Undo()
        {
            if (History.Count > 0)
            {
                RedoRec.Push(History.Peek());
                Board.Remove(History.Peek().Position);
                if (Round > 2) RmFitPosFromDisplay();
                DisplayList.RemoveAt(DisplayList.Count - 1);
                if (Round > 2) GetFitPositions();
                History.Pop();
            }
        }

        public override void Restart()
        {
            base.Restart();
            FitPositions.Clear();
        }
    }
}
