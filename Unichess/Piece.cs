using System.Windows.Controls;
using System.Windows.Media;

namespace Unichess
{
    public class Piece
    {
        public Position Position { get; set; }
        public int Color { get; set; }

        public Piece(Position position, int color)
        {
            Position = position;
            Color = color;
        }

        public static int Black { get => 1; }
        public static int White { get => 2; }

        public static Grid BlackPiece
        {
            get
            {
                /* XAML code:
                <Grid>
                    <Border CornerRadius="15">
                        <Border.Background>
                            <RadialGradientBrush Center="0.3,0.3" GradientOrigin="0.3,0.3" RadiusX="0.4" RadiusY="0.4">
                                <GradientStop Color="White"/>
                                <GradientStop x:Name="gsColor1" Color="LightGray" Offset="0.2"/>
                                <GradientStop x:Name="gsColor2" Color="Black" Offset="1"/>
                            </RadialGradientBrush>
                        </Border.Background>
                    </Border>
                </Grid>
                */
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
                brush.GradientStops.Add(new GradientStop(Colors.White, 0));
                brush.GradientStops.Add(new GradientStop(Colors.LightGray, 0.2));
                brush.GradientStops.Add(new GradientStop(Colors.Black, 1));
                border.Background = brush;
                piece.Children.Add(border);
                piece.Margin = new System.Windows.Thickness(0.5);
                return piece;
            }
        }

        public static Grid WhitePiece
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
                brush.GradientStops.Add(new GradientStop(Colors.White, 0));
                brush.GradientStops.Add(new GradientStop(new Color() { R = 239, G = 239, B = 239, A = 255 }, 0.5));
                brush.GradientStops.Add(new GradientStop(new Color() { R = 227, G = 227, B = 227, A = 255 }, 1));
                border.Background = brush;
                piece.Children.Add(border);
                piece.Margin = new System.Windows.Thickness(0.5);
                return piece;
            }
        }

        public static Grid BlackRedPiece
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

        public static Grid WhiteRedPiece
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
    }
}
