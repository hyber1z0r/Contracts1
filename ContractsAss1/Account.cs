using System;
using Conditions;
using System.Diagnostics.Contracts;

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
            // Condition solution
            Condition.Requires(Balance - amount, "candidateBalance")
                .IsGreaterOrEqual(0, "Amount to large");

            Condition.Requires(amount, "amount")
                .IsLessOrEqual(0, "You can't withdraw a negative amount - thats depositing you fool");

            // Contracts solution
//          if (amount <= 0)
//              throw new StupidException("You can't withdraw a negative amount - thats depositing you fool");
//
//          if (Balance - amount < 0)
//              throw new InsufficientFundsException("Amount to large");
//
//          Contract.Requires<StupidException>(amount > 0);
//          Contract.Requires<InsufficientFundsException>(Balance - amount >= 0);
//          Contract.EnsuresOnThrow<StupidException>(Contract.OldValue(Balance) == Balance);
//          Contract.EnsuresOnThrow<InsufficientFundsException>(Contract.OldValue(Balance) == Balance);
            Balance -= amount;
        }

        public void Deposit(double amount)
        {
            // Condition solution
            Condition.Requires(amount, "amount")
                .IsGreaterThan(0, "You can't deposit a negative amount - thats withdrawing you fool");

            // Contract solution
//          if (amount <= 0)
//              throw new StupidException("You can't withdraw a negative amount - thats depositing you fool");
//          Contract.Requires<StupidException>(amount > 0);
//          Contract.EnsuresOnThrow<StupidException>(Contract.OldValue(Balance) == Balance);

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