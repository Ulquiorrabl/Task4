using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Service.Buisness.CSVDataModels
{
    public class CSVTransaction
    {
        public DateTime Date { get; private set; }

        public string Client { get; private set; }

        public string Manager { get; private set; }

        public string Product { get; private set; }

        public double TotalCost { get; private set; }


        public CSVTransaction(DateTime date, string clientName, string productName,double totalCost, string managerName)
        {
            this.Date = date;
            this.Client = clientName;
            this.Product = productName;
            this.TotalCost = totalCost;
            this.Manager = managerName;
        }

        public override string ToString()
        {
            return Date.ToString() + Client + Product + TotalCost.ToString(); 
        }
    }
}
