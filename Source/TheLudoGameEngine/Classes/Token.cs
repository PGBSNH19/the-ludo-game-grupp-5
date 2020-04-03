namespace TheLudoGameEngine
{
    public class Token
    {
        public int TokenID { get; set; }
        public Player Player { get; set; }
        public int GameBoardPosition { get; set; }
        public string TokenColor { get; set; }
        public int TokenNumber { get; set; }
        public bool InNest { get; set; }
        public bool InGoal { get; set; }

        public int MoveToken(int dieResult)
        {
            for (int i = 1; i <= dieResult; i++)
            {
                if (this.GameBoardPosition >= 45)
                {
                    for (int y = i; y <= dieResult; y++)
                    {
                        i++;
                        this.GameBoardPosition--;
                    }
                }
                else
                {
                    this.GameBoardPosition++;
                }
            }
            return this.GameBoardPosition;
        }

        public bool HasFinished()
        {
            this.InGoal = false;

            if (this.GameBoardPosition == 45)
            {
                this.InGoal = true;
            }

            return this.InGoal;
        }
    }
}