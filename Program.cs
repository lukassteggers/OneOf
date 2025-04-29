using OneOfExample.Classes;

var businessAccount = new BankAccount("business", 1234, 100000.00);

var result1 = businessAccount.Deposit("1,00");

OneOf.Types.Yes newBalance = result1.Match(balance => balance,
    zeroAmountException => throw zeroAmountException
);

Console.WriteLine($"Balance updated: {newBalance}");
