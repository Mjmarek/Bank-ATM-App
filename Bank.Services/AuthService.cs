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
                Console.WriteLine("Hello, user!");
                return true;
            }

            Console.WriteLine("PIN not verified. Please try again.");
            Console.ReadLine();
            return false;
            //return to "please enter your pin"
        }
    }
}
