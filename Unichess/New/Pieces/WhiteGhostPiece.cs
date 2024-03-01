using System.Windows.Controls;
using System.Windows.Media;

namespace Unichess.New.Pieces
{
    public class WhiteGhostPiece : Piece
    {
        public WhiteGhostPiece(Position position) : base(position) { }

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
                brush.GradientStops.Add(new GradientStop(new Color() { R = 255, G = 205, B = 205, A = 136 }, 0));
                brush.GradientStops.Add(new GradientStop(new Color() { R = 255, G = 136, B = 136, A = 136 }, 0.5));
                brush.GradientStops.Add(new GradientStop(new Color() { R = 255, G = 102, B = 102, A = 136 }, 1));
                border.Background = brush;
                piece.Children.Add(border);
                piece.Margin = new System.Windows.Thickness(0.5);
                return piece;
            }
        }

        public override int Type => 0;
    }
}
