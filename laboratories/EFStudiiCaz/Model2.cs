
using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace EFStudiiCaz
{
    class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .Map(m =>
                {
                    m.Properties(p => new { p.SKU, p.Description, p.Price });
                    m.ToTable("Product", "TestPerson");
                }).Map(m =>
                {
                    m.Properties(p => new { p.SKU, p.ImageURL });
                    m.ToTable("ProductWebInfo", "TestPerson");
                });
        }
        public virtual DbSet<Product> Products { get; set; }
    }

    public class Product
    {
        public int SKU { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
    }
}
