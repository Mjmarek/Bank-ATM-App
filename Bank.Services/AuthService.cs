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
        public bool VerifyCustomer(int accountNum, int pinNum)
        {
            using (var ctx = new ATMEntities())
            {
                var query =
                from a in ctx.Account
                where a.AccountNumber == accountNum
                select a;

                var account = query.Single();

                return pinNum == account.PIN;
            }
        }
    }
}
