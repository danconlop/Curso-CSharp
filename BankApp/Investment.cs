using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Investment : Account
    {

        public Investment(string name, decimal initialBalance, int monthlyAmount) : base(name, initialBalance, monthlyAmount)
        {
            
        }


        public void PerformMonthlyCheck()
        {
            if (Balance > 500)
            {
                var interest = Balance * 0.05m;
                Deposit(interest, DateTime.Now, "Abono de interés generado");
                Console.WriteLine($"Se ha generado interés a favor, por un monto de: {interest}");
            } else
            {
                Console.WriteLine("Su inversión no generó intereses");
            }
        }

        protected override Transaction CheckWithDrawalLimit(bool isOverCharged) {
            if (isOverCharged)
            {
                Console.WriteLine("No es posible realizar retiros, no tiene saldo suficiente");
            }
            return default;
        }
    }
}
