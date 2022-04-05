using State;
using System;
/*
 It allows an object to alter its behaviour when its internal state changes.
The intetn of this pattern is to allow an object to alter its behaviour when its internal state changes.the bject willappear to change  its class

Context- defines the interface that is of interest to clients.it maintains an instance of a ConcraeteState subclasses that defines the current state.

 */
namespace State
{/// <summary>
/// State
/// </summary>
    public abstract class BankAccountState// state class will be resposible for transitioning between states.
    {
        public BankAccount BankAccount { get; protected set; } = null!;
        public decimal Balance { get; protected set; }
        public abstract void Deposite(decimal amount);
        public abstract void Withdrow(decimal amount);

    }
    //Context
    public class BankAccount
    {
        public BankAccountState BankAccountState { get; set; }
        public decimal Balance { get { return BankAccountState.Balance; } }

        public BankAccount()
        {
            BankAccountState = new RegularState(200, this);
        }
        public void Deposite(decimal amount) => BankAccountState.Deposite(amount);
        public void Withdrow(decimal amount) => BankAccountState.Withdrow(amount);
    }

}
public class GoldState : BankAccountState
{
    public GoldState(decimal balance, BankAccount bankAccount)
    { Balance = balance; BankAccount = bankAccount; }

    public override void Deposite(decimal amount)
    {
        Console.WriteLine($"in {GetType()} depositing {amount} + 10%  bonuls {amount / 10}");
        Balance += amount + (amount / 10);
    }

    public override void Withdrow(decimal amount)
    {
        Console.WriteLine($"in {GetType()} withdrowing {amount} from {Balance}");
        Balance -= amount;
        if(Balance > 1000 && Balance >= 0)
        {
            BankAccount.BankAccountState = new RegularState(Balance,BankAccount);
        }
        else if(Balance < 0)
        {
            BankAccount.BankAccountState = new OverDrawnState(Balance, BankAccount);

        }
    }
}

/// <summary>
/// ConcteateState
/// </summary>
public class RegularState : BankAccountState
{
    public RegularState(decimal balance, BankAccount bankAccount)
    { Balance = balance; BankAccount = bankAccount; }

    public override void Deposite(decimal amount)
    {
        Console.WriteLine($"in {GetType()} depositing {amount}");
        Balance += amount;
        if(Balance > 1000)
        {
            BankAccount.BankAccountState = new GoldState(Balance,BankAccount);
        }

    }

    public override void Withdrow(decimal amount)
    {

        Console.WriteLine($"in {GetType()} withdrowing {amount} from {Balance}");
        Balance -= amount;
        if (Balance < 0)
        {
            BankAccount.BankAccountState = new OverDrawnState(Balance, BankAccount);
        }
    }
}
public class OverDrawnState : BankAccountState
{
    public OverDrawnState(decimal balance, BankAccount bankAccount)
    { Balance = balance; BankAccount = bankAccount; }

    public override void Deposite(decimal amount)
    {
        Console.WriteLine($"in {GetType()} depositing {amount}");
        Balance += amount;
        {
            if (Balance >= 0)
            {
                BankAccount.BankAccountState = new RegularState(Balance, BankAccount);
            }
        }
    }

    public override void Withdrow(decimal amount)
    {
        Console.WriteLine($"in {GetType()} cannot withdrow , balance {Balance}");
    }

}
