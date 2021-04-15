using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FizzBuzz.Models; 
namespace FizzBuzz.Data
{
    public class NumberContext : DbContext
    {
        public NumberContext(DbContextOptions options) : base(options) { }

        public DbSet<Address> Address { get; set; }
    }
}
