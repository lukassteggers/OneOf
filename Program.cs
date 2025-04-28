using OneOfExample.Classes;

var businessAccount = new BankAccount("business", 100000.00);

var result1 = businessAccount.Deposit("1,00");

double newBalance = result1.Match(balance => balance,
    zeroAmountException => throw zeroAmountException
);

Console.WriteLine($"Balance: {newBalance}");
