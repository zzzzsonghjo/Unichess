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
using Unichess.GameStates;
using Unichess.Pieces;

namespace Unichess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameState State { get; set; }
        public int Rows => State.Rows;
        public int Cols => State.Cols;

        private static int PieceSize => 30;

        public MainWindow(GameState gameState)
        {
            InitializeComponent();
            State = gameState;
            ResetTitle();
            Height = Rows * 25 + 100;
            Width = Cols * 25;
            MinHeight = Math.Max(Rows * 13 + 100, 300);
            MinWidth = Math.Max(Cols * 13, (int)(300F * Rows / Cols));
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
            State.Undo();
            Draw();
        }

        private void B_Restart_Click(object sender, RoutedEventArgs e)
        {
            State.Restart();
            Draw();
        }

        private void B_Back_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ClickGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var p = e.GetPosition(ClickGrid);
            int row = (int)p.Y / PieceSize;
            int col = (int)p.X / PieceSize;
            State.React(new(row, col));
            var Winner = State.Judge();
            Draw();
            if (Winner != null)
            {
                MessageBox.Show(Winner == 0 ? "平局" : (Winner == 1 ? "先手方获胜" : "后手方获胜"), "胜负已分");
                State.IsRunning = false;
            }
        }

        private void DrawPiece(Piece piece)
        {
            var pieceGrid = piece.GetGrid;
            ClickGrid.Children.Add(pieceGrid);
            Grid.SetRow(pieceGrid, piece.Position.Row);
            Grid.SetColumn(pieceGrid, piece.Position.Col);
        }

        private void ResetTitle()
        {
            Title = $"{State.StateName} - {Rows}x{Cols} - Round {State.Round} - " + (State.Round % 2 == 1 ? "先手方" : "后手方");
        }

        private void Draw()
        {
            ClickGrid.Children.Clear();
            foreach (var piece in State.DisplayList)
            {
                DrawPiece(piece);
            }
            ResetTitle();
        }
    }
}