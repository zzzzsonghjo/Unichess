using System.Windows.Controls;

namespace Unichess.Pieces
{
    public abstract class Piece
    {
        public Position Position { get; set; }
        public abstract int Type { get; }

        public Piece() { Position = new(0, 0); }
        public Piece(Position position) => Position = position;

        public abstract Grid GetGrid { get; }
    }
}
