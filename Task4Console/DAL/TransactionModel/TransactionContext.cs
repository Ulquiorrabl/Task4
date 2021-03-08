using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Console.ADO.TransactionModel
{
    class TransactionContext : DbContext
    {
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

        public TransactionContext(string connectionString) :
    base(connectionString)
        {
            base.Database.CreateIfNotExists();
        }
    }
}
