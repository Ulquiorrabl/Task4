using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Console.ADO.TransactionModel
{
    class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime Date { get; set; }
        public double Coast { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
