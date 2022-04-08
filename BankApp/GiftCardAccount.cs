using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class GiftCardAccount : Account
    {
        public string owner;

        public GiftCardAccount(string name, decimal initialBalance) : base(name, initialBalance)
        { 
        }

        
    }
}
