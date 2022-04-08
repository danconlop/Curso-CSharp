using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class CreditAccount : Account
    {
        public CreditAccount(string name, decimal initialBalance, int creditLimit) : base(name, initialBalance, -creditLimit)
        {
        }

        public void PerformMonthlyTransaction()
        {
            if (Balance < 0)
            {
                var interest = -Balance * 0.07m;
                Withdraw(interest, DateTime.Now, "Cargo de interes mensual");
            }
        }

        protected override Transaction CheckWithDrawalLimit(bool isOverCharged) => isOverCharged ? new Transaction(-20, DateTime.Now, "Cargo por sobregiro") : default;



        //public void MonthlyCalculation()
        //{
        //    decimal balance = 0;
        //    foreach (var transaction in TransactionList)
        //    {
        //        balance += transaction.Amount;
        //    }

        //    Console.WriteLine(CreditLimit - balance);
        //    if (CreditLimit - balance > 0)
        //    {
        //        Console.WriteLine($"Ha sobrepasado su limite de crédito, tiene una multa de ");
        //    }
        //}
    }
}
