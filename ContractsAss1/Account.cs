using System;
using Conditions;

namespace ContractsAss1
{
    public class Account
    {
        public double Balance { get; set; }

        public Account()
        {
            Balance = 0.0;
        }


        public void Withdraw(double amount)
        {
            Condition.Requires(Balance - amount, "candidateBalance")
                .IsGreaterOrEqual(0, "Amount to large");

            Condition.Requires(amount, "amount")
                .IsGreaterThan(0, "You can't withdraw a negative amount - thats depositing you fool");

            Balance -= amount;
        }

        public void Deposit(double amount)
        {
            Condition.Requires(amount, "amount")
                .IsGreaterThan(0, "You can't deposit a negative amount - thats withdrawing you fool");
            Balance += amount;
        }
    }

    public class StupidException : Exception
    {
        public StupidException(string message) : base(message)
        {
        }
    }

    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message)
        {
        }
    }
}