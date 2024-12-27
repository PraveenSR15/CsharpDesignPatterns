using State;

BankAccount bankAccount = new();

bankAccount.Withdraw(205);
Console.WriteLine();

bankAccount.Withdraw(5);
Console.WriteLine();

bankAccount.Deposit(5);
Console.WriteLine();

bankAccount.Deposit(1000);
Console.WriteLine();

bankAccount.Withdraw(1000);
Console.WriteLine();

bankAccount.Withdraw(1000);
Console.WriteLine();

bankAccount.Withdraw(1);
Console.WriteLine();

bankAccount.Deposit(3000);
Console.WriteLine();

bankAccount.Deposit(100);
Console.WriteLine();

bankAccount.Deposit(100);
Console.WriteLine();

bankAccount.Withdraw(1210);

Console.ReadKey();