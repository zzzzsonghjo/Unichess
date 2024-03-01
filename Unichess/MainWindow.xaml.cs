using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Unichess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameState GameState { get; set; }
        private string TitleString { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }
        private GameConfig Config { get; set; }

        private static int PieceSize { get => 30; }

        public MainWindow(GameConfig config)
        {
            InitializeComponent();
            Config = config;
            Rows = Config.Rows; Cols = Config.Cols;
            TitleString = Config.Limited ? "马奇诺棋" : "五子棋";
            GameState = new GameState(Config);
            ResetTitle();
            Height = Rows * 25 + 60;
            MinWidth = Cols * 25;
            MinHeight = Math.Max(Rows * 15 + 60, 100);
            MinWidth = Math.Max(Cols * 15, (int)(100F / Rows * Cols));
            InitBoardGrid();
        }

        private void InitBoardGrid()
        {
            MotherGrid.Height = Rows * PieceSize;
            MotherGrid.Width = Cols * PieceSize;
            Grid.SetColumnSpan(ClickGrid, Cols * 2);
            Grid.SetRowSpan(ClickGrid, Rows * 2);
            Grid.SetColumn(ClickGrid, 0);
            Grid.SetRow(ClickGrid, 0);
            Grid.SetColumnSpan(DisplayBorder, Cols * 2 - 2);
            Grid.SetRowSpan(DisplayBorder, Rows * 2 - 2);
            Grid.SetColumn(DisplayBorder, 1);
            Grid.SetRow(DisplayBorder, 1);

            MotherGrid.RowDefinitions.Clear();
            MotherGrid.ColumnDefinitions.Clear();
            ClickGrid.RowDefinitions.Clear();
            ClickGrid.ColumnDefinitions.Clear();
            DisplayGrid.RowDefinitions.Clear();
            DisplayGrid.ColumnDefinitions.Clear();

            for (int i = 0; i < Rows; i++) ClickGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            for (int i = 0; i < Rows * 2; i++) MotherGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            for (int i = 0; i < Rows - 1; i++) DisplayGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            for (int i = 0; i < Cols; i++) ClickGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            for (int i = 0; i < Cols * 2; i++) MotherGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            for (int i = 0; i < Cols - 1; i++) DisplayGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            DisplayGrid.ShowGridLines = true;
        }

        private void B_Undo_Click(object sender, RoutedEventArgs e)
        {
            GameState.Undo();
            ResetTitle();
            Draw();
        }

        private void B_Redo_Click(object sender, RoutedEventArgs e)
        {
            GameState.Redo();
            ResetTitle();
            Draw();
        }

        private void B_Restart_Click(object sender, RoutedEventArgs e)
        {
            GameState = new GameState(Config);
            ResetTitle();
            Draw();
        }

        private void B_Back_Click(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new(Config);
            startWindow.Show();
            this.Close();
        }

        private void ClickGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var p = e.GetPosition(ClickGrid);
            if (GameState.Put(new Position((int)p.Y / PieceSize, (int)p.X / PieceSize)))
            {
                ResetTitle();
                Draw();
                if (GameState.Winner != null)
                {
                    MessageBox.Show((GameState.Winner == Piece.Black ? "黑" : "白") + "子获胜", "游戏结束");
                    GameState = new GameState(Config);
                    ResetTitle();
                    Draw();
                }
            }
        }

        private static void DrawPiece(Grid grid, Grid piece, int row, int col)
        {
            Grid.SetRow(piece, row);
            Grid.SetColumn(piece, col);
            grid.Children.Add(piece);
        }

        private void ResetTitle()
        {
            Title = TitleString + $" - {Rows}x{Cols} - Round {GameState.Round} " + ((GameState.Round % 2 == 1) ? "(Black)" : "(White)");
        }

        private void Draw()
        {
            ClickGrid.Children.Clear();
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    if (GameState.Board.BoardState[row, col] == Piece.Black)
                    {
                        DrawPiece(ClickGrid, Piece.BlackPiece, row, col);
                    }
                    else if (GameState.Board.BoardState[row, col] == Piece.White)
                    {
                        DrawPiece(ClickGrid, Piece.WhitePiece, row, col);
                    }
                }
            }
            foreach (var position in GameState.FitPositions)
            {
                DrawPiece(ClickGrid, (GameState.Round % 2 == 0) ? Piece.WhiteRedPiece : Piece.BlackRedPiece, position.Row, position.Col);
            }
        }
    }
}