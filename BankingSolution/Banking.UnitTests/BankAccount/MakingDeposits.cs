using Banking.UnitTests.TestDoubles;

namespace Banking.UnitTests.BankAccount;

public class MakingDeposits
{
    [Fact]
    public void DepositIncreasesBalance()
    {
        //Given
        //If i have an account and i want to deposit 100
        Account account = new Account(new DummyBonusCalculator());
        decimal openingBalance = account.GetBalance(); //query
        decimal amountToDeposit = 100M;

        //When - I do the deposit
        account.Deposit(amountToDeposit); //command

        //Then - I can verify it worked and the new balance is 100 more than it was before
        Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
    }
}
