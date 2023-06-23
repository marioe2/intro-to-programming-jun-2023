using Castle.Core.Logging;
using Moq;

namespace Greeter.UnitTests;
public  class GreetingTests
{
    private readonly Mock<IBlackList> _blackList;
    private readonly Mock<INotification> _notification;
    private readonly GreetingMaker _greetingMaker;

    public GreetingTests()
    {
        this._blackList = new Mock<IBlackList>();
        this._notification = new Mock<INotification>();
        this._greetingMaker = new GreetingMaker(new Mock<IBlackList>().Object, new Mock<INotification>().Object);
    }

    [Theory]
    [InlineData("Windom", "Hello, Windom.")]
    public void SingleName(string name, string expected)
    {
        string greeting = _greetingMaker.Greet(name);

        Assert.Equal(expected, greeting);
    }

    [Theory]
    [InlineData("", "Hello, Chief!")]
    public void NullName(string name, string expected)
    { 
        string greeting = _greetingMaker.Greet(null);

        Assert.Equal(expected, greeting);
    }

    [Theory]
    [InlineData("WINDOM", "HELLO, WINDOM!")]
    public void UppercaseName(string name, string expected)
    {
        string greeting = _greetingMaker.Greet(name);

        Assert.Equal(expected, greeting);
    }

    [Theory]
    [InlineData("Bob", "Sue", "Hello, Bob and Sue!")]
    public void TwoNames(string name1, string name2, string expected)
    {
        string greeting = _greetingMaker.Greet(name1, name2);

        Assert.Equal(expected, greeting);
    }

    [Fact]
    public void MultipleNames()
    {
        string greeting = _greetingMaker.Greet("Bob", "Sue", "Jeff");

        Assert.Equal("Hello, Bob, Sue, and Jeff!", greeting);
    }

    [Fact]
    public void MultipleNamesUpper()
    {
        string greeting = _greetingMaker.Greet("BOB", "SUE", "JEFF");

        Assert.Equal("HELLO, BOB, SUE, AND JEFF!", greeting);
    }

    [Fact]
    public void MultipleNamesMixed()
    {
        string greeting = _greetingMaker.Greet("BOB", "Sue", "Jeff");

        Assert.Equal("Hello, Sue, Jeff, AND BOB!", greeting);
    }

    [Fact]
    public void BlacklistedNames()
    {
        string greeting = _greetingMaker.Greet("Bob", "Jack", "Jeff");

        _blackList.Setup(m => m.Check("Jack")).Throws(new Exception());

        Assert.Equal("Hello, Sue, Jeff, AND BOB!", greeting);
    }
}

