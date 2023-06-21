

namespace Games.Tests;
public class ThinkingAboutTheGame
{
    [Fact]
    public void DuplicateNamesAreNotAllowed()
    {
        
        // Given
        var game = new BowlingGame();

       
        game.AddPlayer("Jim", 120);
        game.AddPlayer("Sue", 200);

        
        // Then / When
      Assert.Throws<PlayerAlreadyAddedToGameException>(() => game.AddPlayer(" jim ", 200));
    }
}
