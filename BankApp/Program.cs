using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var account = new Account("Gildardo", 1000, 0);
            //var giftcard = new GiftCardAccount("Soriana", 2000);

            var investment = new Investment("Daniel Contreras", 100, 500);

            Console.WriteLine($"se creó cuenta con número {investment.Number} con un saldo de {investment.Balance} por el usuario {investment.Owner}");


            investment.Deposit(200, DateTime.Now.AddDays(-4), "Ganancia venta #1");
            investment.Deposit(700, DateTime.Now.AddDays(-4), "Bono de ventas enero");
            investment.Withdraw(700, DateTime.Now, "retiro");
            //investment.Deposit(600, DateTime.Now.AddDays(-4), "Para los tacos");
            //investment.Deposit(200, DateTime.Now.AddDays(-4), "Para los tacos");
            //credit.Withdraw(500, DateTime.Now.AddDays(-2), "Para la gasolina");
            //giftcard.Withdraw(2000, DateTime.Now.AddDays(0), "Pago de colegiatura");

            //var t = giftcard.GetAccountHistory();
            //Console.WriteLine(t);
            //credit.PerformMonthlyTransaction();
            Console.WriteLine($"\nSaldo actual: {investment.Balance}");
            Console.WriteLine($"Movimientos del mes \n{investment.GetAccountHistory()}");
            investment.PerformMonthlyCheck();
            Console.WriteLine($"Nuevo saldo: {investment.Balance}");

        }
    }
}
