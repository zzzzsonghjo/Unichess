using System.Windows.Controls;
using System.Windows.Media;

namespace Unichess.Pieces
{
    public class BlackGhostPiece : Piece
    {
        public BlackGhostPiece() : base() { }
        public BlackGhostPiece(Position position) : base(position) { }

        public override Grid GetGrid
        {
            get
            {
                Grid piece = new();
                Border border = new()
                {
                    CornerRadius = new System.Windows.CornerRadius(15)
                };
                RadialGradientBrush brush = new()
                {
                    Center = new System.Windows.Point(0.3, 0.3),
                    GradientOrigin = new System.Windows.Point(0.3, 0.3),
                    RadiusX = 0.4,
                    RadiusY = 0.4
                };
                brush.GradientStops.Add(new GradientStop(new Color() { R = 255, G = 0, B = 0, A = 136 }, 0));
                brush.GradientStops.Add(new GradientStop(new Color() { R = 160, G = 0, B = 0, A = 136 }, 0.5));
                brush.GradientStops.Add(new GradientStop(new Color() { R = 79, G = 0, B = 0, A = 136 }, 1));
                border.Background = brush;
                piece.Children.Add(border);
                piece.Margin = new System.Windows.Thickness(0.5);
                return piece;
            }
        }

        public override int Type => 0;
    }
}
