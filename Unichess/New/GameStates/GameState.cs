using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unichess.New.GameStates
{
    public abstract class GameState
    {
        public Board Board { get; private set; }
        protected int Rows => Board.Rows;
        protected int Cols => Board.Cols;

        protected PieceRecorder History { get; set; }
        protected PieceRecorder RedoRec { get; set; }

        public int Round => History.Count + 1;
        protected abstract List<Piece> PiecesList { get; }

        public List<Piece> DisplayList { get; private set; }

        public GameState(int rows, int cols)
        {
            Board = new Board(rows, cols);
            History = new PieceRecorder();
            RedoRec = new PieceRecorder();
            DisplayList = [];
        }

        public abstract void React(Position position);

        public abstract void Undo();
        public abstract void Redo();

        public abstract int? Judge();
    }
}
