
namespace StringCalculator;

public class StringCalculator
{

    private readonly ILogger _logger;

    public StringCalculator(ILogger logger)
    {
        _logger = logger;
    }

    public int Add(string numbers)
    {
        int result = 0;

        if (numbers == "") { result = 0; }
        else
        {

            result = numbers.Split(',', '\n').Select(int.Parse).Sum();
        }
        _logger.Write(result.ToString());
        return result;
    }
}

public interface ILogger
{
    void Write(string message);
}