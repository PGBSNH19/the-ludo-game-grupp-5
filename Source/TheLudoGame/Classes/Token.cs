namespace TheLudoGame
{
    public class Token
    {
        public int TokenID { get; set; }
        public Player Player { get; set; }
        public int GameBoardPosition { get; set; }
        public int EndLinePosition { get; set; }
        public bool AtEndLine { get; set; }
        public bool InGoal { get; set; }
    }
}