using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4Console.Buisness.CSVDataModels;

namespace Task4Console.Buisness.DataFactories
{
    public class TransactionFactory
    {
        public CSVTransaction CreateNew(string[] transactionParameters, string managerName)
        {
            DateTime date = DateTime.Parse(transactionParameters[0]);
            double coast = double.Parse(transactionParameters[3]);
            return new CSVTransaction(date, transactionParameters[1], transactionParameters[2], coast, managerName);
        }
    }
}
