namespace Games;

public record ScoreReport
{
    public List<Player> Winners { get; set; } = new();
    public List<Player> Losers { get; set; }
    public double Average { get; init; }

    public string Message { get; set; } = string.Empty;

}