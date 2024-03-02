using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Unichess.GameStates;

namespace Unichess
{
    /// <summary>
    /// StartWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private int Rows
        {
            get => int.Parse(Tb_Rows.Text);
            set => Sl_Rows.Value = value;
        }

        private int Cols
        {
            get => int.Parse(Tb_Cols.Text);
            set => Sl_Cols.Value = value;
        }

        private int GameMode
        {
            get => Cb_GameMode.SelectedIndex;
            set => Cb_GameMode.SelectedIndex = value;
        }

        private GameState CurrGameState => GameMode switch
        {
            0 => new MaginotState(Rows, Cols),
            1 => new GobangState(Rows, Cols),
            2 => new SharpState(Rows, Cols),
            _ => new MaginotState(Rows, Cols),
        };

        private (int, int) CurrSizeRange => GameMode switch
        {
            0 => (14, 30),
            1 => (14, 30),
            2 => (3, 3),
            _ => (14, 30),
        };

        public StartWindow(int rows, int cols, int gameMode)
        {
            InitializeComponent();
            (Sl_Cols.Minimum, Sl_Cols.Maximum) = CurrSizeRange;
            (Sl_Rows.Minimum, Sl_Rows.Maximum) = CurrSizeRange;
            Rows = rows;
            Cols = cols;
            GameMode = gameMode;
        }

        private void B_Start_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new(CurrGameState);
            mainWindow.Show();
            this.Close();
        }

        private void Cb_GameMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (Sl_Cols.Minimum, Sl_Cols.Maximum) = CurrSizeRange;
            (Sl_Rows.Minimum, Sl_Rows.Maximum) = CurrSizeRange;
        }
    }
}