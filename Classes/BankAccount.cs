using OneOfExample.Exceptions;
using OneOf;
namespace OneOfExample.Classes;

public class BankAccount
{
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public double Balance {get; private set;}

    public BankAccount(string name, double balance)
    {
        Id = new Guid();
        Name = name;
        Balance = balance;
    }

    public BankAccount(string name) : this(name, 0.0)
    {
    }

    public OneOf<double, ZeroAmountException> Deposit(double amount)
    {
        if (amount == 0)
        {
            return new ZeroAmountException("Amount cannot be zero");
        }
        
        Balance += amount;
        
        return Balance;
    }

    public OneOf<double, ZeroAmountException> Deposit(OneOf<double, int, string> amount)
    {
        double convertedAmount = amount.Match(
            amountAsDouble => amountAsDouble,
            amountAsInt => (double) amountAsInt,
            amountAsString => Convert.ToDouble(amountAsString)
        );

        if (convertedAmount == 0)
        {
            return new ZeroAmountException("Amount cannot be zero");
        }
        return Balance + convertedAmount;
    }
    
    public OneOf<double, ZeroAmountException, PaymentFailureException> Withdraw(double amount)
    {
        if (Balance < amount)
        {
            return new PaymentFailureException("Not enough balance on account.");
        }

        if (amount == 0.0)
        {
            return new ZeroAmountException("Amount is zero.");
        }
        
        Balance -= amount;
        return Balance;
    }
}