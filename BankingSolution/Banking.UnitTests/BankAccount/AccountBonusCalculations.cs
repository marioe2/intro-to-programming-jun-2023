using Banking.UnitTests.TestDoubles;

namespace Banking.UnitTests.BankAccount;
public class AccountBonusCalculations
{
    [Fact]
    public void DepositUsesTheBonusCalculator()
    {
        var stubbedBonusCalculator = new Mock<ICanCalculateBonuses>();

        var account = new Account(stubbedBonusCalculator.Object);
        var openingBalance = account.GetBalance();

        account.Deposit(112);

        Assert.Equal(openingBalance + 112M + 42M, account.GetBalance());
    }
}
