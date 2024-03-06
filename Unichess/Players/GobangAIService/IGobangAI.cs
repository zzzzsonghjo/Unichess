using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unichess.Players.GobangAIService
{
    public interface IGobangAI
    {
        public Position GetPosition(string board);
    }
}
