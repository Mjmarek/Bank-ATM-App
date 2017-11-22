using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services
{
    public class AccountService
    {
        public bool CreateAccount(int accountId, int accountNum,
            string accountType, decimal balance, int pin, int id)
        {
            var entity =
                new Account()
                {
                    AccountID = accountId,
                    AccountNumber = accountNum,
                    AccountType = accountType,
                    Balance = balance,
                    PIN = pin,
                    CustomerID = id,
                };
            using (var ctx = new ATMEntities())
            {
                ctx.Account.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
