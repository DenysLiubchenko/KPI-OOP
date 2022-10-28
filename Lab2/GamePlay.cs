public class GamePlay
{
    public static void Main(string[] args)
    {
        BasicAccount player1 = new PlusAccount("Denys");
        BasicAccount player2 = new BasicAccount("Bogdan");
        BasicAccount player3 = new StreakAccount("John");
        Play(player1, player2, 0, GameTypes.Training);
        Play(player1, player3, 15, GameTypes.Competitive);
        Play(player1, player2, 15, GameTypes.Triple);
        Play(player2, player1, 0, GameTypes.Training);
        Play(player2, player3, 15, GameTypes.Competitive);
        Play(player2, player3, 15, GameTypes.Triple);
        Play(player3, player1, 0, GameTypes.Training);
        Play(player3, player2, 15, GameTypes.Competitive);
        Play(player3, player1, 15, GameTypes.Triple);
        player1.GetStats();
        player2.GetStats();
        player3.GetStats();
    }
    public static void Play(BasicAccount player1, BasicAccount player2, uint score, GameTypes gameType)
    {
        Random random = new Random();
        if (random.Next(0, 2) == 1)
        {
            GameFactory.CreateGame(player1, player2, score, gameType);
        }
        else
        {
            GameFactory.CreateGame(player2, player1, score, gameType);
        }
    }
}
