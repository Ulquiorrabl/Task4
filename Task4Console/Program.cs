using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4Console.ADO;
using Task4Console.Buisness.CSVParsing;
using Task4Console.Buisness.CSVDataModels;
using Task4Console.Buisness.ReportWatching;
using Task4Console.Buisness.TransactionAdding;
using System.Threading;
using System.Configuration;
using Task4Console.ADO.AddTransaction;


namespace Task4Console
{
    class Program
    {
        static void Main(string[] args)
        {
            TransactionView trv = new TransactionView();
            /*FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
            TransactionAddManager manager = new TransactionAddManager(fileSystemWatcher, trv);
            Console.ReadKey();*/

            using(PurchaseModelContainer context = new PurchaseModelContainer())
            {
                AppTransactionOperator apo = new AppTransactionOperator(context);
                FileSystemWatcher watcher = new FileSystemWatcher();
                TransactionAddManager manager = new TransactionAddManager(watcher, apo);
                TransactionAddManager manager2 = new TransactionAddManager(watcher, trv);
                Console.ReadKey();
            }



        }
    }
}
