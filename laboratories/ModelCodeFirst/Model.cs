using System;
using System.Collections.Generic;
using System.Text;

namespace ModelCodeFirst
{
    using Microsoft.EntityFrameworkCore;
    public class ModelContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

    }

    public class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
    public class Order
    {
        public int OrderId { get; set; }
        public int Value { get; set; }

        public System.DateTime Date { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
