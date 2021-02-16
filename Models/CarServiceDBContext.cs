using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Octopai.Models
{

    public class CarServiceDBContext : DbContext
    {
        public CarServiceDBContext(DbContextOptions<CarServiceDBContext> options) : base(options) { }
        public DbSet<CarService> CarServices { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
