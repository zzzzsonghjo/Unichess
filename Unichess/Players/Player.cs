using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unichess.Players
{
    public class Player
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public int AllWin { get; set; }
        public int[] Wins { get; set; }
        public int AllLoss { get; set; }
        public int[] Losses { get; set; }

        public int[] Speeds { get; set; }

        public Player(string name,int id,int types)
        {
            Name = name;
            Id = id;
            AllWin = 0;
            Wins = new int[types];
            AllLoss = 0;
            Losses = new int[types];
            Speeds = new int[types];
        }

        public Player(string name, int id, int allWin, int[] wins, int allLoss, int[] losses, int[] speeds)
        {
            Name = name;
            Id = id;
            AllWin = allWin;
            Wins = wins;
            AllLoss = allLoss;
            Losses = losses;
            Speeds = speeds;
        }
    }
}
