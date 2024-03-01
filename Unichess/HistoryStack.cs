namespace Unichess
{
    public class HistoryStack
    {
        public Stack<Piece> Black { get; set; }
        public Stack<Piece> White { get; set; }
        public int Count { get; set; }

        public HistoryStack()
        {
            Black = new Stack<Piece>();
            White = new Stack<Piece>();
            Count = 0;
        }

        public Piece Peek() => (Count % 2 == 1) ? Black.Peek() : White.Peek();
        public Piece SecondPeek() => (Count % 2 == 1) ? White.Peek() : Black.Peek();

        public Piece BlackPeek() => Black.Peek();
        public Piece WhitePeek() => White.Peek();

        public Piece Pop()
        {
            Count--;
            if (Count % 2 == 0)
                return Black.Pop();
            else
                return White.Pop();
        }

        public void Push(Piece piece)
        {
            Count++;
            if (Count % 2 == 1)
                Black.Push(piece);
            else
                White.Push(piece);
        }
    }
}
