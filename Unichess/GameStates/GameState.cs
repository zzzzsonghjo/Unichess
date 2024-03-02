using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unichess.Pieces;

namespace Unichess.GameStates
{
    public abstract class GameState
    {
        public Board Board { get; private set; }
        public int Rows => Board.Rows;
        public int Cols => Board.Cols;
        public bool IsRunning { get; set; }

        protected PieceRecorder History { get; set; }
        protected PieceRecorder RedoRec { get; set; }

        public int Round => History.Count + 1;
        public abstract string StateName { get; }
        protected abstract List<Piece> PiecesList { get; }

        public List<Piece> DisplayList { get; private set; }

        public GameState(int rows, int cols)
        {
            Board = new Board(rows, cols);
            History = new PieceRecorder();
            RedoRec = new PieceRecorder();
            DisplayList = [];
            IsRunning = true;
        }

        public abstract void React(Position position);

        public abstract void Undo();
        public abstract void Redo();

        public abstract int? Judge();
        public abstract void Restart();
    }
}
