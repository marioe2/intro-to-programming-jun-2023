namespace Banking.UnitTests.BankAccount;

public class MakingWithdraws
{
    [Fact]
    public void MakingAWithdrawlDeacreasesTheBalance()
    {
        //Given
        //If i have an account and i want to withdraw 100
        Account account = new Account();
        decimal openingBalance = account.GetBalance(); //query
        decimal amountToWithdraw = 100M;

        //When - I do the withdraw
        account.Withdraw(amountToWithdraw); //command

        //Then - I can verify it worked and the new balance is 100 less than it was before
        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
    }

    [Fact]
    public void CanTakeFullBalance()
    {
        var account = new Account();
        var openingBalance = account.GetBalance();

        account.Withdraw(openingBalance);

        Assert.Equal(0, account.GetBalance());
    }
}
