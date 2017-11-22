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
            var inputPin = Console.ReadLine();

            var authService1 = new AuthService();
            authService1.VerifyCustomer(int.Parse(inputAccount), int.Parse(inputPin));
            //make sure account is verified before continuing
            //while unverified, keep looping for correct pin

            var accountService1 = new AccountService();
            var accountType = accountService1.GetAccountType(int.Parse(inputAccount));

            var accountService2 = new AccountService();
            var accountBalance = accountService2.GetAccountBalance(int.Parse(inputAccount));
            Console.Clear();

            Console.WriteLine($"You currently have ${accountBalance} in your {accountType} Account.\n" +
                "What type of transaction would you like to complete?\n" +
                "1: Deposit\n" +
                "2: Withdrawal");

            Console.ReadLine();



            //take input and use it to determine case for switch

            //switch ()
            //{
            //    case Deposit:
            //        deposit how much?
            //        deposit amount + balance = final balance
            //        display final balance;
            //        break;

            //    case Withdrawal:
            //        withdraw how much?
            //        balance - withdraw amount = final balance
            //        display final balance;
            //        break;

            //    default:
            //        Console.WriteLine("Thank you for visiting your bank. Have a nice day.");
            //        break;
            //}
            //Console.ReadLine();
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