namespace Games;

public class BowlingGame
{
    private readonly List<Player> _players = new();

    public void AddPlayer(string name, int score)
    {
        GuardForValidScore(score);

        GuardForPlayerAlreadyExisting(name);

        _players.Add(new Player(name, score));

        //store some kind of list of players and their scores
        //unless a player with that same name exists
        //in that case, punch them in the nose.
    }

    private void GuardForPlayerAlreadyExisting(string name)
    {
        if (PlayerExists(name)) { throw new PlayerAlreadyAddedToGameException(); }
    }

    private static void GuardForValidScore(int score)
    {
        if (score < 0 || score > 300) { throw new InvalidBowlingScoreException(); }
    }

    private bool PlayerExists(string name)
    {
        return _players.Any(p => p.name.ToLowerInvariant().Trim() == name.ToLowerInvariant().Trim());
    }
}

public record Player(string name, int score);