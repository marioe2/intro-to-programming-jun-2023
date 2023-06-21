namespace Games.Tests;
public class ScoringBowlingGame
{
    private readonly List<Player> _expectedWinners;
    private readonly List<Player> _expectedLosers;
    private readonly ScoreReport _report;
    private readonly double _expectedAverage;

    public ScoringBowlingGame()
    {
        var game = new BowlingGame();
        var p1 = new Player("Jeff", 212);
        var p2 = new Player("Stacy", 287);
        game.AddPlayer(p1.name, p1.score);
        game.AddPlayer(p2.name, p2.score);

        _expectedWinners = new List<Player> { p2 };
        _expectedLosers = new List<Player> { p1 };
        _expectedAverage = 249.5;

        var scorer = new GameScorer();

        _report = scorer.GenerateScoreReportFor(game);
    }

    [Fact]
    public void HasCorrectWinners()
    {
        Assert.Equal(_expectedWinners, _report.Winners);
    }

    [Fact]
    public void HasCorrectLosers()
    {
        Assert.Equal(_expectedLosers, _report.Losers);
    }

    [Fact]
    public void HasCorrectAverage()
    {
        Assert.Equal(_expectedAverage, _report.Average);
    }
}
