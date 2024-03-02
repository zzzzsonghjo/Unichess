namespace Unichess.GameStates
{
    public class SharpState(int rows, int cols) : GobangState(rows, cols)
    {
        public override int StateID => 2;
        public override string StateName => "井字棋";

        public override int? Judge()
        {
            if (Board.IsFull())
            {
                if (GobangstyleJudge(3, 3) == null)
                    return 0;
            }
            return GobangstyleJudge(3, 3);
        }
    }
}
