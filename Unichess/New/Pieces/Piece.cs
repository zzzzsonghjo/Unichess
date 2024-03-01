using System.Windows.Controls;

namespace Unichess.New.Pieces
{
    public abstract class Piece
    {
        public Position Position { get; set; }
        public abstract int Type { get; }

        public Piece(Position position) => Position = position;

        public abstract Grid GetGrid { get; }
    }
}
