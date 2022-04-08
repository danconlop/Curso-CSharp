using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class Account
    {
        public string Owner { get; set; }
        public string Number { get; set; }
        public decimal Balance {
            get{
                decimal balance = 0;
                foreach(var transaction in TransactionList)
                {
                    balance += transaction.Amount;
                }
                return balance;
            }
        }
        public List<Transaction> TransactionList = new List<Transaction>();

        private readonly int _minimumBalance;
        private static int accountNumberSeed = 123456789;

        //public Account() { }
        public Account(string name, decimal initialBalance) : this(name, initialBalance, 0) { }
        public Account(string name, decimal inicialBalance, int minimumBalance)
        {
            Owner = name;
            _minimumBalance = minimumBalance;

            Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            if (inicialBalance > 0)
                Deposit(inicialBalance, DateTime.Now, "Balance inicial");
        }

        public void Deposit(decimal amount, DateTime date, string description)
        {
            if (amount <= 0)
                Console.WriteLine("El deposito debe ser mayor a cero");

            var deposit = new Transaction(amount, date, description);
            TransactionList.Add(deposit);
        }

        public void Withdraw(decimal amount, DateTime date, string description)
        {
            if(amount <= 0)
                Console.WriteLine("El monto de retiro debe ser mayor a cero");

            var transaction = CheckWithDrawalLimit(Balance - amount < _minimumBalance);
            var withdrawal = new Transaction(-amount, date, description);
            
            if(transaction != null)
                TransactionList.Add(transaction);



        }

        protected virtual Transaction CheckWithDrawalLimit(bool isOverCharged)
        {
            if (isOverCharged)
            {
                throw new InvalidOperationException("No tienes fondos suficientes.");
            } else
            {
                return default;
            }
        }

        public string GetAccountHistory()
        {
            decimal balance = 0;
            var report = new StringBuilder();
            report.AppendLine("Date\t\tAmount\tBalance\tDescription\t");
            foreach (var transaction in TransactionList)
            {
                balance += transaction.Amount;
                report.AppendLine($"{transaction.Date.ToShortDateString()}\t{transaction.Amount}\t{balance}\t{transaction.Description}");
            }

            return report.ToString();
        }
    }
}
