public class GameAccount
{
    private string UserName;
    private uint CurrentRating;
    private uint GamesCount;
    List<Game> gamesList;
    public string getUserName()
    {
        return UserName;
    }
    public uint getCurrentRating()
    {
        return CurrentRating;
    }
    public uint getGamesCount()
    {
        return GamesCount;
    }
    public GameAccount(string name)
    {
        UserName = name;
        CurrentRating = 1;
        GamesCount = 0;
        gamesList = new List<Game>();
    }
    public void WinGame(GameAccount opponent, uint rating)
    {
        if (rating < 0) throw new ArgumentOutOfRangeException("Rating can't be negative");
        Game game = new Game(this, opponent, rating);
        opponent.LoseGame(this, rating, game);
        gamesList.Add(game);
        GamesCount++;
        CurrentRating += rating;
    }
    public void LoseGame(GameAccount opponent, uint rating, Game game)
    {
        gamesList.Add(game);
        GamesCount++;
        if (CurrentRating > rating)
        {
            CurrentRating -= rating;
        }
        else
        {
            CurrentRating = 1;
        }
    }
    public List<Game> GetStats()
    {
        Console.WriteLine(this.getUserName() + " Status:\nCurrent Rating - " + this.getCurrentRating() + "\tGames Played - " + this.getGamesCount());
        foreach (Game game in gamesList)
        {
            Console.Write("Winner - ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(game.getWinner().getUserName());
            Console.ResetColor();
            Console.Write("\tLoser - ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(game.getLoser().getUserName());
            Console.ResetColor();
            Console.Write("\tScore - ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(game.getScore());
            Console.ResetColor();
            Console.WriteLine("\tID - " + game.getId());
        }
        return gamesList;
    }
}

public class Game
{
    private GameAccount winner;
    private GameAccount loser;
    private uint score;
    private static uint id = 0;
    private uint gameId;
    public Game(GameAccount winner, GameAccount loser, uint score)
    {
        this.winner = winner;
        this.loser = loser;
        this.score = score;
        this.gameId = id++;
    }
    public GameAccount getWinner()
    {
        return winner;
    }
    public GameAccount getLoser()
    {
        return loser;
    }
    public uint getScore()
    {
        return score;
    }
    public uint getId()
    {
        return gameId;
    }
}

public class GamePlay
{
    public static void Main(string[] args)
    {
        GameAccount player1 = new GameAccount("Denys");
        GameAccount player2 = new GameAccount("Bogdan");
        GameAccount player3 = new GameAccount("John");
        play(player1, player2, 15);
        play(player1, player3, 15);
        play(player2, player1, 15);
        play(player2, player3, 15);
        play(player3, player1, 15);
        play(player3, player2, 15);
        player1.GetStats();
        player2.GetStats();
        player3.GetStats();
    }
    public static void play(GameAccount player1, GameAccount player2, uint score)
    {
        Random random = new Random();
        if (random.Next(0, 2) == 1)
        {
            player1.WinGame(player2, score);
        }
        else
        {
            player2.WinGame(player1, score);
        }
    }
}