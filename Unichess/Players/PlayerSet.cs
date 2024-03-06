using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unichess.Players
{
    public class PlayerSet
    {
        private string Path => @".\Saves\Players.txt";
        private List<Player> Players { get; set; }
        private int Types { get; set; }

        public PlayerSet()
        {
            StreamReader sr = new(Path);
            int playerCount = int.Parse(sr.ReadLine());
            Types = int.Parse(sr.ReadLine());
            Players = [];
            for (int i = 0; i < playerCount; i++)
            {
            }
        }

        public void Add(string name)
        {
            Players.Add(new(name, Players.Count + 1, Types));
        }
    }
}
