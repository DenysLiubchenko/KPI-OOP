public class BasicAccount
{
    internal int Streak;

    protected string UserName { get; set; }
    protected uint CurrentRating { get; set; }
    protected uint GamesCount { get { return (uint) gamesList.Count; } }
    protected double Coeficient { get; set; }
    protected List<Game> gamesList { get; set; }

    public BasicAccount(string name)
    {
        UserName = name;
        CurrentRating = 1;
        Coeficient = 1;
        gamesList = new List<Game>();
    }

    public virtual void WinGame(Game game)
    {
        gamesList.Add(game);
        CurrentRating += game.Score;
    }
    public virtual void LoseGame(Game game)
    {
        gamesList.Add(game);
        if (CurrentRating > game.Score) CurrentRating -= (uint) (game.Score*Coeficient);
    }
    public List<Game> GetStats()
    {
        Console.WriteLine(this.UserName + " Status:\nCurrent Rating - " + this.CurrentRating + "\tGames Played - " + this.GamesCount + "\tAccount type - " + this.GetType());
        foreach (Game game in gamesList)
        {
            Console.Write("Winner - ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(game.Winner.UserName);
            Console.ResetColor();
            Console.Write("\tLoser - ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(game.Loser.UserName);
            Console.ResetColor();
            Console.Write("\tScore - ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(game.Score);
            Console.ResetColor();
            Console.WriteLine("\tID - " + game.GameId + "\tType - " + game.GetType());
        }
        return gamesList;
    }
}



