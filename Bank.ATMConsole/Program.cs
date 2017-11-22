using Bank.Models;
using Bank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.ATMConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your bank.\n" +
                "Please enter your account number.");
            var inputAccount = Console.ReadLine();

            var accountService = new AccountService();
            var firstName = accountService.GetAccountName(int.Parse(inputAccount));
            
            Console.WriteLine($"Thank you, {firstName}.\n" +
                "Please enter the PIN associated with this account.");
            Console.ReadLine();
        }
        
        
        
        //static void Main(string[] args)
        //{
        //    var newCustomer = new CustomerService();
        //    Console.WriteLine("Welcome to your bank.\n" +
        //        "Please enter your first name.");
        //    var inputFirst = Console.ReadLine();
        //    Console.WriteLine("Please enter your last name.");
        //    var inputLast = Console.ReadLine();

        //    Random rnd = new Random();
        //    int id = rnd.Next(1, 101);

        //    newCustomer.CreateCustomer(id, inputFirst, inputLast);
        //}              
    }
}