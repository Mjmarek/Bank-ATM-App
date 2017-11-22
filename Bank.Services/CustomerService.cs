using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services
{
    public class CustomerService
    {
        public bool CreateCustomer(int id, string firstName, string lastName)
        {
            var entity =
                new Customer()
                {
                    CustomerID = id,
                    FirstName = firstName,
                    LastName = lastName
                };
            using (var ctx = new ATMEntities())
            {
                ctx.Customer.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
