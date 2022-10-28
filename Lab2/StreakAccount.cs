public class StreakAccount : BasicAccount
{
    private uint Streak { get; set; }
    public StreakAccount(string name) : base(name)
    {
        Streak = 1;
    }
    public override void WinGame(Game game)
    {
        gamesList.Add(game);
        if (game.GetType() == typeof(TrainingGame)) return;
        if (Streak == 3)
        {
            CurrentRating += game.Score * 2;
            Streak = 1;
        }
        else
        {
            CurrentRating += game.Score;
            Streak++;
        }
    }
    public override void LoseGame(Game game)
    {
        
        gamesList.Add(game);
        if (game.GetType() == typeof(TrainingGame)) return;
        if (CurrentRating > (uint)(game.Score*Coeficient)) 
        {
            CurrentRating -= (uint) (game.Score * Coeficient);
        }
        else
        {
            CurrentRating = 1;
        }
        Streak = 1;
    }
}
