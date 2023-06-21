namespace Games;

public abstract class Game
{
    private readonly List<Player> _players = new();

    protected abstract void GuardForValidScore(int score);

    public void AddPlayer(string name, int score)
    {
        GuardForValidScore(score);

        GuardForPlayerAlreadyExisting(name);

        _players.Add(new Player(name, score));

        //store some kind of list of players and their scores
        //unless a player with that same name exists
        //in that case, punch them in the nose.
    }

    internal List<Player> GetPlayers()
    {
        return _players;
    }

    private void GuardForPlayerAlreadyExisting(string name)
    {
        if (PlayerExists(name)) { throw new PlayerAlreadyAddedToGameException(); }
    }

    private bool PlayerExists(string name)
    {
        return _players.Any(p => p.name.ToLowerInvariant().Trim() == name.ToLowerInvariant().Trim());
    }
}