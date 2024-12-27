namespace State
{
    public abstract class BankAccountState
    {
        public BankAccount BankAccount { get; protected set; } = null!;
        public decimal Balance { get; protected set; }
        public abstract void Deposit(decimal amount);
        public abstract void Withdraw(decimal amount);
    }

    public class GoldState : BankAccountState
    {
        public GoldState(decimal balance, BankAccount bankAccount)
        {
            Balance = balance;
            BankAccount = bankAccount;
        }

        public override void Deposit(decimal amount)
        {
            Console.WriteLine($"Depositing amount {amount} in {GetType()} ");
            Balance += amount + (amount/10);
            Console.WriteLine("Balance : " + Balance);
        }

        public override void Withdraw(decimal amount)
        {
            Console.WriteLine($"Withdrawing amount {amount} from {Balance} in {GetType()} ");
            Balance -= amount;
            Console.WriteLine("Balance : " + Balance);

            if (Balance < 100 && Balance >= 0)
            {
                BankAccount.BankAccountState = new RegularState(Balance, BankAccount);
                Console.WriteLine($"Moved to {BankAccount.BankAccountState.GetType()} ");
            }
            else if (Balance < 0)
            {
                BankAccount.BankAccountState = new OverDrawnState(Balance, BankAccount);
                Console.WriteLine($"Moved to {BankAccount.BankAccountState.GetType()} ");
            }
        }
    }

    public class RegularState : BankAccountState
    {
        public RegularState(decimal balance, BankAccount bankAccount)
        {
            Balance = balance;
            BankAccount = bankAccount;
        }

        public override void Deposit(decimal amount)
        {
            Console.WriteLine($"Depositing amount {amount} in {GetType()} ");
            Balance += amount;
            Console.WriteLine("Balance : " + Balance);
            if (Balance >= 1000)
            {
                BankAccount.BankAccountState = new GoldState(Balance, BankAccount);
                Console.WriteLine($"Moved to {BankAccount.BankAccountState.GetType()} ");
            }
        }

        public override void Withdraw(decimal amount)
        {
            Console.WriteLine($"Withdrawing amount {amount} from {Balance} in {GetType()} ");
            Balance -= amount;
            Console.WriteLine("Balance : " + Balance);
            if (Balance < 0)
            {
                BankAccount.BankAccountState = new OverDrawnState(Balance, BankAccount);
                Console.WriteLine($"Moved to {BankAccount.BankAccountState.GetType()} ");
            }
        }
    }

    public class OverDrawnState : BankAccountState
    {
        public OverDrawnState(decimal balance, BankAccount bankAccount)
        {
            Balance = balance;
            BankAccount = bankAccount;
        }

        public override void Deposit(decimal amount)
        {
            Console.WriteLine($"Depositing amount {amount} in {GetType()} ");
            Balance += amount;
            Console.WriteLine("Balance : " + Balance);
            if (Balance >= 0)
            {
                BankAccount.BankAccountState = new RegularState(Balance, BankAccount);
                Console.WriteLine($"Moved to {BankAccount.BankAccountState.GetType()} ");
            }
        }

        public override void Withdraw(decimal amount)
        {
            Console.WriteLine($"Cannot withdraw in {GetType()} since balance is {Balance}");
        }
    }

    public class BankAccount
    {
        public BankAccountState BankAccountState { get; set; }
        public decimal Balance { get { return BankAccountState.Balance; } }
        public BankAccount()
        {
            BankAccountState = new RegularState(200, this);
        }

        public void Deposit(decimal amount)
        {
            BankAccountState.Deposit(amount);
        }

        public void Withdraw(decimal amount)
        {
            BankAccountState.Withdraw(amount);
        }
    }
}
