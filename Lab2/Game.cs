public abstract class Game
{
    public BasicAccount Winner { get; set; }
    public BasicAccount Loser { get; set; }
    public uint Score { get; set; }
    public static uint id = 0;
    public uint GameId { get; set; }

    public Game(BasicAccount Winner, BasicAccount Loser)
    {
        this.Winner = Winner;
        this.Loser = Loser;
        this.GameId = id++;
    }
}
