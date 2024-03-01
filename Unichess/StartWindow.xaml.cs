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

namespace Unichess
{
    /// <summary>
    /// StartWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StartWindow : Window
    {
        private GameConfig Config { get; set; }

        public StartWindow()
        {
            InitializeComponent();
            Config = new();
            slRows.Value = Config.Rows;
            slCols.Value = Config.Cols;
            LimitCB.IsChecked = Config.Limited;
        }

        public StartWindow(GameConfig config)
        {
            InitializeComponent();
            Config = config;
            slRows.Value = config.Rows;
            slCols.Value = config.Cols;
            LimitCB.IsChecked = Config.Limited;
        }

        private void B_Start_Click(object sender, RoutedEventArgs e)
        {
            Config.ResetSize((int)slRows.Value, (int)slCols.Value);
            Config.Limited = (bool)LimitCB.IsChecked;
            MainWindow ChessWindow = new(Config);
            ChessWindow.Show();
            this.Close();
        }
    }
}