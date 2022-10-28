public enum GameTypes
{
    Training, Competitive, Triple
}
public class GameFactory
{
    public static Game CreateGame(BasicAccount Winner, BasicAccount Loser, uint Score, GameTypes gameType)
    {
        switch (gameType)
        {
            case GameTypes.Triple:
                return new TripleGame(Winner, Loser, Score);
            case GameTypes.Competitive: 
                return new CompetitiveGame(Winner, Loser, Score);
            case GameTypes.Training: 
                return new TrainingGame(Winner, Loser);
            default:
                throw new ArgumentException("No such game type");
        }
    }
}

