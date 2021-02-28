using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Console.Buisness.CSVDataModels
{
    public class CSVTransaction
    {
        public DateTime Date { get; private set; }

        public string Client { get; private set; }

        public string Product { get; private set; }

        public double TotalCoast { get; private set; }

        public CSVTransaction(DateTime date, string clientName, string productName,double totalCoast)
        {
            this.Date = date;
            this.Client = clientName;
            this.Product = productName;
            this.TotalCoast = totalCoast;
        }

        public override string ToString()
        {
            return Date.ToString() + Client + Product + TotalCoast.ToString(); 
        }
    }
}
