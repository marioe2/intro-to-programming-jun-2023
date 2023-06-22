using Banking.UnitTests.TestDoubles;

namespace Banking.UnitTests.BankAccount;

public class NewAccounts
{
    [Fact]
    public void NewAccountsHaveCorrectBalance()
    {
        //Given
/*        Account account = new Account(new DummyBonusCalculator());
*/        Account account = new Account(new IMock<ICanCalculateBonuses>().Object);


        //When
        decimal balance = account.GetBalance();

        //Then
        Assert.Equal(5000, balance);
    }


}
