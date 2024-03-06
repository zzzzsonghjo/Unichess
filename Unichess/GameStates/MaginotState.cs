using Unichess.Pieces;

namespace Unichess.GameStates
{
    public class MaginotState(int rows, int cols) : GobangState(rows, cols)
    {
        public override int StateID => 0;
        public override string StateName => "马奇诺棋";

        private List<Position> FitPositions { get; set; } = [];
        private List<Position> Offsets => [new(1, 2), new(2, 1), new(-1, 2), new(2, -1), new(1, -2), new(-2, 1), new(-1, -2), new(-2, -1)];

        protected override List<Piece> PiecesList => [new BlackPiece(), new WhitePiece(), new BlackGhostPiece(), new WhiteGhostPiece()];

        public override int? Judge()
        {
            if (Round > 2)
            {
                if (FitPositions.Count == 0)
                {
                    return History.Peek().Type;
                }
            }
            return GobangstyleJudge(5, 6);
        }

        private void RemoveFitPositions()
        {
            DisplayList.RemoveRange(DisplayList.Count - FitPositions.Count, FitPositions.Count);
            FitPositions.Clear();
        }

        private void GetFitPositions()
        {
            Position lastPosition = History.Peek2().Position;
            foreach (var offset in Offsets)
            {
                var fitPosition = lastPosition + offset;
                if (Board.Check(fitPosition))
                {
                    var ghost = PiecesList[History.Peek2().Type + 1];
                    ghost.Position = fitPosition;
                    FitPositions.Add(fitPosition);
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
                if (Round > 2 && (!FitPositions.Contains(position))) return;
                var piece = PiecesList[type];
                piece.Position = position;
                History.Push(piece);
                Board.Set(position, History.Peek().Type);
                RemoveFitPositions();
                DisplayList.Add(piece);
                if (Round > 2)
                {
                    GetFitPositions();
                }
            }
        }

        public override void Undo()
        {
            if (History.Count > 0)
            {
                Board.Remove(History.Peek().Position);
                RemoveFitPositions();
                DisplayList.RemoveAt(DisplayList.Count - 1);
                History.Pop();
                if (Round > 2) GetFitPositions();
                IsRunning = true;
            }
        }

        public override void Restart()
        {
            base.Restart();
            FitPositions.Clear();
        }
    }
}
