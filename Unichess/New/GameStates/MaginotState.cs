using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unichess.New.GameStates
{
    public class MaginotState : GobangState
    {
        private List<Position> FitPositions { get; set; }
        private List<Position> Offsets => [new(1, 2), new(2, 1), new(-1, 2), new(2, -1), new(1, -2), new(-2, 1), new(-1, -2), new(-2, -1)];

        public MaginotState(int rows, int cols) : base(rows, cols)
        {
            FitPositions = [];
        }
    }
}
