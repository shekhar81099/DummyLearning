using System;

namespace DI
{
    public class OppsTest
    {
        public OppsTest()
        {

            // Creating an Account instance (abstracted via interface)
            IAccount account = new SavingsAccount(5000);

            // Creating payment methods using the account
            IPayment card = new CardPayment(account);
            IPayment upi = new UPIPayment(account);

            // Showing balances before and after operations
            account.GetBalance().Print("Initial Account Balance");

            card.creditAmount(100);
            card.GetAccountBalance().Print("Card Balance after Credit");

            upi.creditAmount(100);
            upi.GetAccountBalance().Print("UPI Balance after Credit");
        }
    }

    // Interface for payment operations
    public interface IPayment
    {
        void creditAmount(int amt);
        void DebitAmount(int amt);
        int GetAccountBalance();
    }

    // CardPayment class implementing IPayment interface
    public class CardPayment : IPayment
    {
        private readonly IAccount _account;

        public CardPayment(IAccount account)
        {
            "Card payment initialized.".Print();
            _account = account;
        }

        public void creditAmount(int amt) => _account.Credit(amt);
        public void DebitAmount(int amt) => _account.Debit(amt);
        public int GetAccountBalance() => _account.GetBalance();
    }

    // UPIPayment class implementing IPayment interface
    public class UPIPayment : IPayment
    {
        private readonly IAccount _account;

        public UPIPayment(IAccount account)
        {
            "UPI payment initialized.".Print();
            _account = account;
        }

        public void creditAmount(int amt) => _account.Credit(amt);
        public void DebitAmount(int amt) => _account.Debit(amt);
        public int GetAccountBalance() => _account.GetBalance();
    }

    // Interface defining account-related operations
    public interface IAccount
    {
        void Credit(int amt);
        void Debit(int amt);
        int GetBalance();
        int GetBalance1();
    }
    public class SavingsAccount : Account
    {
        public SavingsAccount(int initialBalance) : base(initialBalance)
        {
            "Savings account created.".Print();
        }

        // You can add additional methods or override base methods if needed
    }
    public class CurrentAccount : Account
    {
        public CurrentAccount(int initialBalance) : base(initialBalance)
        {
            "Savings account created.".Print();
        }
        public override int GetBalance1() => 1000;

        // You can add additional methods or override base methods if needed
    }
    // Concrete Account class implementing IAccount
    public abstract class Account : IAccount
    {
        private int _balance;

        public Account(int initialBalance)
        {
            _balance = initialBalance;
            "Account created with initial balance.".Print();
        }

        public void Credit(int amt) => _balance += amt;
        public void Debit(int amt) => _balance -= amt;
        public int GetBalance() => _balance;
        public virtual int GetBalance1() => 0;

    }

    public static class P11
    {
        
    }
}
