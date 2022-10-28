public class TrainingGame:Game
{
    public TrainingGame(BasicAccount Winner, BasicAccount Loser) : base(Winner, Loser)
    {
        Score = 0;
        Winner.WinGame(this);
        Loser.LoseGame(this);
    }
}
