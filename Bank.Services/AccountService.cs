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

        public string GetAccountName(int accountNum)
        {
            using (var ctx = new ATMEntities())
            {
                var innerJoinQuery =
                    from a in ctx.Account
                    join c in ctx.Customer on a.CustomerID equals c.CustomerID
                    where a.AccountNumber == accountNum
                    select c.FirstName;
                return innerJoinQuery.Single();
            }
        }

        public string GetAccountType(int accountNum)
        {
            using (var ctx = new ATMEntities())
            {
                var query =
                    from a in ctx.Account
                    where a.AccountNumber == accountNum
                    select a.AccountType;
                return query.Single();
            }
        }

        public decimal GetAccountBalance(int accountNum)
        {
            using (var ctx = new ATMEntities())
            {
                var query1 =
                    from a in ctx.Account
                    where a.AccountNumber == accountNum
                    select a.Balance;
                return query1.Single();
            }
        }
    }
}
