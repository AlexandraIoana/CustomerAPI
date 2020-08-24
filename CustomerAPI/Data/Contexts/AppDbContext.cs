using CustomerAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Setup Users table
            builder.Entity<Customer>().ToTable("Customers");
            builder.Entity<Customer>().HasKey(c => c.ID);
            builder.Entity<Customer>().Property(c => c.ID).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Customer>().Property(c => c.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Customer>().Property(c => c.Surname).IsRequired().HasMaxLength(30);
            builder.Entity<Customer>().HasMany(c => c.Accounts).WithOne(a => a.Customer).HasForeignKey(a => a.CustomerID);
            builder.Entity<Customer>().HasData
                (
                    new Customer { ID = 1, Name = "Mickey", Surname = "Mouse" },
                    new Customer { ID = 2, Name = "Homer", Surname = "Simpson" },
                    new Customer { ID = 3, Name = "Roger", Surname = "Rabbit" },
                    new Customer { ID = 4, Name = "Scooby", Surname = "Doo" },
                    new Customer { ID = 5, Name = "Mike", Surname = "Wasowski" },
                    new Customer { ID = 6, Name = "Jack", Surname = "Skellington" }
                );

            // Setup Accounts table
            builder.Entity<Account>().ToTable("Accounts");
            builder.Entity<Account>().HasKey(a => a.ID);
            builder.Entity<Account>().Property(a => a.ID).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Account>().Property(a => a.Balance).IsRequired();
            builder.Entity<Account>().HasMany(a => a.Transactions).WithOne(t => t.Account).HasForeignKey(t => t.AccountID);
            builder.Entity<Account>().HasData
                (
                    new Account { ID = 1, Balance = 21.2M, CustomerID = 1 },
                    new Account { ID = 2, Balance = 0, CustomerID = 2 },
                    new Account { ID = 3, Balance = 25.7M, CustomerID = 1 },
                    new Account { ID = 4, Balance = 53.1M, CustomerID = 3 },
                    new Account { ID = 5, Balance = 34M, CustomerID = 4 },
                    new Account { ID = 6, Balance = 0, CustomerID = 5 },
                    new Account { ID = 7, Balance = 11.6M, CustomerID = 4 },
                    new Account { ID = 8, Balance = 51.2M, CustomerID = 6 }
                );

            // Setup Transactions table
            builder.Entity<Transaction>().ToTable("Transactions");
            builder.Entity<Transaction>().HasKey(t => t.ID);
            builder.Entity<Transaction>().Property(t => t.ID).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Transaction>().Property(t => t.Amount);
            builder.Entity<Transaction>().HasData
                (
                    new Transaction { ID = 1, Amount = 22.2M, AccountID = 1 },
                    new Transaction { ID = 2, Amount = 22.4M, AccountID = 3 },
                    new Transaction { ID = 3, Amount = 53.1M, AccountID = 4 },
                    new Transaction { ID = 4, Amount = 3.3M, AccountID = 3 },
                    new Transaction { ID = 5, Amount = -1, AccountID = 1 },
                    new Transaction { ID = 6, Amount = 15.4M, AccountID = 5 },
                    new Transaction { ID = 7, Amount = 20M, AccountID = 6 },
                    new Transaction { ID = 8, Amount = 18.6M, AccountID = 5 },
                    new Transaction { ID = 9, Amount = 11.6M, AccountID = 7 },
                    new Transaction { ID = 11, Amount = -20M, AccountID = 6 },
                    new Transaction { ID = 12, Amount = 51.2M, AccountID = 8 }
                );

        }
    
    }
}
