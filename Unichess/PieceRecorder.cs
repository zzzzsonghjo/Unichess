﻿using Unichess.Pieces;

namespace Unichess
{
    public class PieceRecorder
    {
        private readonly List<Piece> Black = [];
        private readonly List<Piece> White = [];
        public int Count { get; private set; } = 0;

        public Piece Peek() => (Count % 2 == 1) ? Black.Last() : White.Last();
        public Piece Peek2() => (Count % 2 == 0) ? Black.Last() : White.Last();

        public Piece Pop()
        {
            if (Count % 2 == 1)
            {
                if (Black.Count > 0)
                {
                    var piece = Black.Last();
                    Black.RemoveAt(Black.Count - 1);
                    Count--;
                    return piece;
                }
                throw new Exception("No more pieces");
            }
            else
            {
                if (White.Count > 0)
                {
                    var piece = White.Last();
                    White.RemoveAt(White.Count - 1);
                    Count--;
                    return piece;
                }
                throw new Exception("No more pieces");
            }
        }

        public void Push(Piece piece)
        {
            Count++;
            if (Count % 2 == 1)
                Black.Add(piece);
            else
                White.Add(piece);
        }

        public void Clear()
        {
            Count = 0;
            Black.Clear();
            White.Clear();
        }

        public Piece this[int index]
        {
            get
            {
                if (index >= Count) throw new Exception("Index out of range");
                if (index % 2 == 0)
                    return Black[index / 2];
                else
                    return White[index / 2];
            }
        }
    }
}
