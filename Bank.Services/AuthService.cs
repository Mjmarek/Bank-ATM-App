using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services
{
    public class AuthService
    {
        private ATMEntities db = new ATMEntities();
        public bool VerifyCustomer(int accountNum, int pinNum)
        {
            var query =
                from a in db.Account
                where a.AccountNumber == accountNum && a.PIN == pinNum
                select a;
            
            foreach (var acc in query)
            {
                return true;
            }

            return false;            
        }
    }
}
