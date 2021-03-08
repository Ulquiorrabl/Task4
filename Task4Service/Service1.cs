using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Task4Service.ADO;
using Task4Service.ADO.AddTransaction;
using Task4Service.Buisness.TransactionAdding;
using Task4Service.ADO.TransactionModel;
using System.Configuration;

namespace Task4Service
{
    public partial class Service1 : ServiceBase
    {
        AppTransactionOperator apo;
        FileSystemWatcher watcher;
        TransactionAddManager manager;
        TransactionContext context;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            context = new TransactionContext(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            apo = new AppTransactionOperator(context);
            watcher = new FileSystemWatcher();
            manager = new TransactionAddManager(watcher, apo);
            manager.ReportWatcher.StartWatch();
        }

        protected override void OnStop()
        {
            manager.ReportWatcher.StopWatch();
            context.Dispose();
        }
    }
}
