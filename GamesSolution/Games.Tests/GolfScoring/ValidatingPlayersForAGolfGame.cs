namespace Games.Tests.GolfScoring;
public class ValidatingPlayersForAGolfGame
{
    [Fact]
    public void DuplicateNamesAreNotALlowed()
    {
        var game = new GolfGame();

        game.AddPlayer("Jim", 120);
        game.AddPlayer("Sue", 120);

        Assert.Throws<PlayerAlreadyAddedToGameException>(() => game.AddPlayer("Jim", 120));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-300)]
    public void InvalidGolfScores(int invalidScore)
    {
        var game = new GolfGame();

        Assert.Throws<InvalidGolfScoreException>(() => game.AddPlayer("Joe", invalidScore));
    }

    
}
