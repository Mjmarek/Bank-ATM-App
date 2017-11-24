using Bank.Models;
using Bank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank.ATMConsole
{
    public class Program
    {
        public static string FirstName { get; set; }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your bank.\n" +
                "Please enter your account number.");
            var inputAccount = Console.ReadLine();

            var accountService = new AccountService();
            FirstName = accountService.GetAccountName(int.Parse(inputAccount));
            
            Console.WriteLine($"Thank you, {FirstName}.\n" +
                "Please enter the PIN associated with this account.");
                       
            bool verifyPin = false;
            do
            {
                var inputPin = Console.ReadLine();
                var authService = new AuthService();

                if (authService.VerifyCustomer(int.Parse(inputAccount), int.Parse(inputPin)))
                {
                    verifyPin = true;
                }

                else
                {
                    Console.WriteLine("PIN not verified. Please try again.");
                }
            }
            while (verifyPin == false);
                        
            var accountType = accountService.GetAccountType(int.Parse(inputAccount));
            Console.WriteLine($"You have accessed your {accountType} Account.");

            bool customerIsBanking = true;
            while (customerIsBanking)
            {
                Console.WriteLine("What type of transaction would you like to complete?\n" +
                    "1: Deposit\n" +
                    "2: Withdrawal\n" +
                    "3: Check Balance");
                var customerInput = int.Parse(Console.ReadLine());
                var accountOptions = (CustomerAccountOptions)customerInput;

                switch (accountOptions)
                {
                    case CustomerAccountOptions.Deposit:
                        Console.WriteLine("How much would you like to deposit into your account?");
                        var accountAdd = decimal.Parse(Console.ReadLine());
                        var accountAddBalance = accountService.GetAccountBalance(int.Parse(inputAccount));
                        Console.WriteLine($"You have {accountAddBalance} in your {accountType} Account.\n" +
                            "Would you like to complete another transaction?");
                        break;

                    case CustomerAccountOptions.Withdrawal:
                        Console.WriteLine("How much would you like to withdraw from your account?");
                        var accountSubtract = decimal.Parse(Console.ReadLine());
                        var accountSubtractBalance = accountService.GetAccountBalance(int.Parse(inputAccount));
                        Console.WriteLine($"You have {accountSubtractBalance} in your {accountType} Account.\n" +
                            "Would you like to complete another transaction?");
                        break;

                    case CustomerAccountOptions.CheckBalance:
                        var accountBalance = accountService.GetAccountBalance(int.Parse(inputAccount));
                        Console.WriteLine($"You have {accountBalance} in your {accountType} Account.");
                        if (!AnotherTransaction()) customerIsBanking = false;
                        break;

                    default:
                        Console.WriteLine("Please select from the options provided.");
                        break;
                }
            }
        }

        private static bool AnotherTransaction()
        {
            Console.WriteLine("Would you like to complete another transaction?\n" +
                           "1: Yes\n" +
                           "2: No");
            var continueTransaction = int.Parse(Console.ReadLine());
            if (continueTransaction == 1)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Thank you, {FirstName}. Have a nice day.");
                return false;
            };
        }
    }
}