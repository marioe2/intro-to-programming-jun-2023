using Banking.Domain;

Console.WriteLine("Welcome to the bank!");
var account = new Account(new StandardBonusCalculator());

Console.WriteLine($"Your Current Balance is {account.GetBalance():c}");

Console.Write("Enter a W to make a withdrawl, Enter a D for a deposit, or Q to quit: ");

var entry = Console.ReadLine();

if (entry != null)
{

    if (entry.Trim().ToLower() == "w")
    {
        Console.Write("Amount of Withdrawl: ");
        var amount = decimal.Parse(Console.ReadLine());
        account.Withdraw(amount);
    }


    if (entry.Trim().ToLower() == "d")
    {
        Console.Write("Amount of Deposit: ");
        var amount = decimal.Parse(Console.ReadLine());
        account.Deposit(amount);
    }

    Console.WriteLine($"Good job. Your New Balance is {account.GetBalance():c}");

}