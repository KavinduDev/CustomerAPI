using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.DataAccess
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=DESKTOP-72C1JKQ; Database=CustomerAPI; User Id=sa; Password=sa123";
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(new Customer[]
            {
                new Customer
                {
                    CustomerId = 1,
                    CustomerName = "Amal",
                    Phone = 0775896321,
                    Address = "No21,Galle Rd, Colombo",
                    Email = "amal@abc.com"
                },
                new Customer
                {
                    CustomerId = 2,
                    CustomerName = "Kamal",
                    Phone = 0775896321,
                    Address = "No35,Temple Rd, Nugegoda",
                    Email = "kamal@abc.com"
                },
                new Customer
                {
                    CustomerId = 3,
                    CustomerName = "Saman",
                    Phone = 0775896321,
                    Address = "No48,Galle Rd, Dehiwala",
                    Email = "saman@abc.com"
                }
            });
        }
    }
}
