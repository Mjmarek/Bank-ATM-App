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
                var query =
                    from a in ctx.Account
                    join c in ctx.Customer on a.CustomerID equals c.CustomerID
                    where a.AccountNumber == accountNum
                    select c.FirstName;
                return query.Single();
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
                var query =
                    from a in ctx.Account
                    where a.AccountNumber == accountNum
                    select a.Balance;
                return query.Single();
            }
        }

        public decimal AddAccountBalance(int accountNum, decimal accountAdd)
        {
            using (var ctx = new ATMEntities())
            {
                var query =
                    from a in ctx.Account
                    where a.AccountNumber == accountNum
                    select a;
                var account = query.Single();

                account.Balance = (account.Balance + accountAdd);

                ctx.SaveChanges();
                return account.Balance;
            }
        }

        public decimal SubtractAccountBalance(int accountNum, decimal accountSubtract)
        {
            using (var ctx = new ATMEntities())
            {
                var query =
                    from a in ctx.Account
                    where a.AccountNumber == accountNum
                    select a;
                var account = query.Single();

                account.Balance = (account.Balance - accountSubtract);

                ctx.SaveChanges();
                return account.Balance;
            }
        }
    }
}
