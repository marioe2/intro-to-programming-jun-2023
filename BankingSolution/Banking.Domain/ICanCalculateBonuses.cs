namespace Banking.Domain;

public interface ICanCalculateBonuses
{
    public decimal CalculateBonusForDepositOn(decimal balance, decimal amountToDeposit)
    {
        return 0;
    }
}