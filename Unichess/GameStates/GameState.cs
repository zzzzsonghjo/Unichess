using Unichess.Pieces;

namespace Unichess.GameStates
{
    public abstract class GameState(int rows, int cols)
    {
        public abstract string StateName { get; }
        public abstract int StateID { get; }
        public abstract List<string> WinnerNames { get; }

        public Board Board { get; private set; } = new Board(rows, cols);
        public int Rows => Board.Rows;
        public int Cols => Board.Cols;
        public bool IsRunning { get; set; } = true;

        protected PieceRecorder History { get; set; } = new PieceRecorder();

        public int Round => History.Count + 1;
        protected abstract List<Piece> PiecesList { get; }

        public List<Piece> DisplayList { get; private set; } = [];

        public abstract void React(Position position);
        public abstract void Undo();

        public abstract int? Judge();
        public abstract void Restart();
    }
}
