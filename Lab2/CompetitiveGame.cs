public class CompetitiveGame : Game
{
    public CompetitiveGame(BasicAccount Winner, BasicAccount Loser, uint Score) : base(Winner, Loser)
    {
        this.Score = Score;
        Winner.WinGame(this);
        Loser.LoseGame(this);
    }
}
