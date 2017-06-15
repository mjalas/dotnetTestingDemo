using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting
{
    public class NotEnoughFunds : Exception
    {        
        public NotEnoughFunds(string message) : base(message) { }
    }

    public class NegativeAmount : Exception
    {
        public NegativeAmount(string message) : base(message) { }
    }

    public class Account
    {
        public double Balance { get; set; }

        public Account()
        {
            Balance = 0.0;
        }

        public Account(double initialAmount)
        {
            Balance = initialAmount;
        }

        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new NegativeAmount($"Given amount: {amount}");
            }
            Balance += amount;
        }

        public double Withdraw(double amount)
        {
            if (amount > Balance)
            {
                throw new NotEnoughFunds($"Balance is only {Balance}$");
            }
            Balance -= amount;
            return amount;
        }
    }
}
