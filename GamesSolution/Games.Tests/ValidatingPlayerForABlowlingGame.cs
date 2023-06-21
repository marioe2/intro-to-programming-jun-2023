namespace Games.Tests;
public class ValidatingPlayerForABlowlingGame
{
    [Fact]
    public void DuplicateNamesAreNotALlowed()
    {
        var game = new BowlingGame();

        game.AddPlayer("Jim", 120);
        game.AddPlayer("Sue", 120);

        Assert.Throws<PlayerAlreadyAddedToGameException>(() => game.AddPlayer("Jim", 120));
    }

    [Theory]
    [InlineData(301)]
    public void InvalidScoresThrowAnException(int invalidScore)
    {
        var game = new BowlingGame();

        Assert.Throws<InvalidBowlingScoreException>(() => game.AddPlayer("Jim", invalidScore));
    }
}
