using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unichess
{
    public class GameConfig
    {
        public int Rows { get; set; }
        public int Cols { get; set; }
        public bool Limited { get; set; }
        public Position[] Offsets { get; set; }
        public int WinCount { get; set; }

        public GameConfig()
        {
            Rows = Cols = 19;
            Limited = true;
            Offsets = [new(1, 2), new(2, 1), new(-1, 2), new(2, -1), new(1, -2), new(-2, 1), new(-1, -2), new(-2, -1)];
            WinCount = 5;
        }

        public GameConfig(int rows, int cols, bool limited, Position[] offsets, int winCount)
        {
            Rows = rows;
            Cols = cols;
            Limited = limited;
            Offsets = offsets;
            WinCount = winCount;
        }

        public void ResetSize(int rows, int cols) { Rows = rows; Cols = cols; }
    }
}
