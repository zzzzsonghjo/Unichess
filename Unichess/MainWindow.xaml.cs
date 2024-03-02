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
        private string TitleString { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }

        private static int PieceSize { get => 30; }

        public MainWindow()
        {
            InitializeComponent();
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
        }

        private void B_Redo_Click(object sender, RoutedEventArgs e)
        {
        }

        private void B_Restart_Click(object sender, RoutedEventArgs e)
        {
        }

        private void B_Back_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ClickGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
        }

        private static void DrawPiece(Grid grid, Grid piece, int row, int col)
        {
        }

        private void ResetTitle()
        {
        }

        private void Draw()
        {
        }
    }
}