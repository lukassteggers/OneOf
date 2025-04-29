using OneOfExample.Exceptions;
using OneOf;
using OneOf.Types;

namespace OneOfExample.Classes;

public class BankAccount
{
    public Guid Id { get; init; }
    public int Pin { get; private set; }
    public string Name { get; private set; }
    public double Balance {get; private set;}

    public BankAccount(string name, int pin, double balance)
    {
        Id = new Guid();
        Pin = pin;
        Name = name;
        Balance = balance;
    }

    public BankAccount(string name, int pin) : this(name, pin, 0.0)
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

    public OneOf<Success, ZeroAmountException> Deposit(OneOf<double, int, string> amount)
    {
        // Match for returns
        double convertedAmount = amount.Match(
            amountAsDouble => Balance + amountAsDouble,
            amountAsInt => Balance + (double) amountAsInt,
            amountAsString => Balance + Convert.ToDouble(amountAsString)
        );

        if (convertedAmount == 0)
        {
            return new ZeroAmountException("Amount cannot be zero");
        }
        
        // returning OneOf.Types-Structs (Yes, No, Success
        return new Success();
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

    public OneOf<Success, PaymentFailureException> Withdrawal(OneOf<double, int, string> amount)
    {
        //Switch-Method (not returning any value)
        amount.Switch(
            amountAsDouble => Balance += amountAsDouble,
            amountAsInt => Balance += (double) amountAsInt,
            amountAsString =>
            {
                var convertedAmount = Convert.ToDouble(amountAsString);
                if (convertedAmount == null)
                {
                    return new
                }
            });
    }
}