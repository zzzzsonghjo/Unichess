using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unichess.Players.GobangAIService
{
    public class StupidGobangAI : IGobangAI
    {
        private Board board;
        private int Rows => board.Rows;
        private int Cols => board.Cols;
        public int pieceType;

        private static readonly int INF = int.MaxValue / 2;

        public Position GetPosition(string board)
        {
            throw new NotImplementedException();
        }
    }
}
