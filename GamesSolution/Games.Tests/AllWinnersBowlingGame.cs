namespace Games.Tests;

public class AllWinnersBowlingGame
{
    private readonly List<Player> _expectedWinners;
    private readonly List<Player> _expectedLosers;
    private readonly ScoreReport _report;

    public AllWinnersBowlingGame()
    {
        var game = new BowlingGame();
        var p1 = new Player("Jeff", 300);
        var p2 = new Player("Stacy", 300);
        game.AddPlayer(p1.name, p1.score);
        game.AddPlayer(p2.name, p2.score);

        _expectedWinners = new List<Player> { p1, p2 };
        _expectedLosers = new();
        var scorer = new GameScorer();

        _report = scorer.GenerateScoreReportFor(game);
    }

    [Fact]
    public void NoLosers()
    {
        Assert.Equal(_expectedLosers, _report.Losers);
    }

    [Fact]
    public void AllWinners()
    {
        Assert.Equal(_expectedWinners, _report.Winners);
    }
}
