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
            CustomerService newCustomer = new CustomerService();
            Console.WriteLine("Welcome to your bank.\n" +
                "Please enter your first name.");
            string inputFirst = Console.ReadLine();
            Console.WriteLine("Please enter your last name.");
            string inputLast = Console.ReadLine();

            Random rnd = new Random();
            int id = rnd.Next(1, 101);

            newCustomer.CreateCustomer(id, inputFirst, inputLast);

            //newCustomer.CreateCustomer("Monica", "Marek");            
            //CustomerService.CreateCustomer(NameFromConsole);
        }        

        //public ActionResult Index()
        //{
        //    var CustomerID = Guid.Parse(NewCustomer.Identity.GetCustomerID());
        //    var svc = new NewCustomer(CustomerID);
        //    var model = svc.GetCustomers();

        //    return svc;
        //}

            //string FirstName = "Monica";
            //string LastName = "Marek";

            //var svc = new model.Customer(FirstName, LastName);
            //return;
                                
            //public CustomerService CreateCustomer()
            //{
            //    //var userId = GetCustomerID();
            //    var svc = new CustomerService(CustomerID);
            //    return svc;
            //}
                       
            //public Action Index()
            //{
            //    var model = new Customers[0];
            //    return Index();
            //}
        
    }
}