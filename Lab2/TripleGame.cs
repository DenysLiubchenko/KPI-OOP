public class TripleGame : Game
{
    public TripleGame(BasicAccount Winner, BasicAccount Loser, uint Score) : base(Winner, Loser)
    {
        this.Score = Score*3;
        Winner.WinGame(this);
        Loser.LoseGame(this);
    }
}
