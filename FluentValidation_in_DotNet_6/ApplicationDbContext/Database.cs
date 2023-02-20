using FluentValidation_in_DotNet_6.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FluentValidation_in_DotNet_6.ApplicationDbContext
{
    public class Database : DbContext
    {
        public Database(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customer { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Customer>()
                .Property(s => s.Status)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
