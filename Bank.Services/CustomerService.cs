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
                new Customers()
                {
                    CustomerID = id,
                    FirstName = firstName,
                    LastName = lastName
                };
            using (var ctx = new ATMEntities())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
