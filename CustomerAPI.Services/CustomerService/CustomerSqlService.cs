using CustomerAPI.DataAccess;
using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.Services.CustomersService
{
    public class CustomerSqlService : ICustomerRepository
    {
        private readonly CustomerDbContext _context = new CustomerDbContext();

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }
        public Customer GetCustomer(int id)
        {
            return _context.Customers.Find(id);
        }
        public Customer AddCustomer(Customer customer)
        {
            customer.CustomerId = 0;
            if (customer.CustomerId == 0)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
            return customer;
        }
        public void UpdateCustomer(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void DeleteCustomer(Customer customer)
        {
            _context.Remove(customer);
            _context.SaveChanges();
        }

    }
}
