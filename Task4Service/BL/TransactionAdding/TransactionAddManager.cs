using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Task4Service.Buisness.CSVDataModels;
using Task4Service.Buisness.CSVParsing;
using Task4Service.Buisness.ReportWatching;
using Task4Service.Buisness.DataFactories;

namespace Task4Service.Buisness.TransactionAdding
{
    public class TransactionAddManager
    {
        private CSVParser _parser;

        private TransactionFactory _transactionFactory;

        public ReportWatcher ReportWatcher;

        private ADO.UnitOfWork.IUnitOfWork<CSVTransaction> _unitOfWork;

        private List<CSVTransaction> _data;

        public TransactionAddManager(CSVParser parser = null, TransactionFactory transactionFactory = null,
            ReportWatcher reportWatcher = null)
        {
            this._parser = parser;
            this._transactionFactory = transactionFactory;
            this.ReportWatcher = reportWatcher;
        }

        public TransactionAddManager(FileSystemWatcher fileSystemWatcher, ADO.UnitOfWork.IUnitOfWork<CSVTransaction> unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._transactionFactory = new TransactionFactory();
            this.ReportWatcher = new ReportWatcher(fileSystemWatcher);
            this._data = new List<CSVTransaction>();
            this.ReportWatcher.ReportFileAdded += new ReportWatcher.ReportFileAddedHandler(OnTransactionFileCreated);
            this.ReportWatcher.StartWatch();
        }

        private void OnTransactionFileCreated(string filePath, string fileName)
        {
            Task.Factory.StartNew(() => CreateParsingTask(filePath, fileName));
        }

        private void CreateParsingTask(string filePath, string fileName)
        {
            while (true)
            {
                try
                {
                    ParseTransaction(filePath, fileName);
                    break;
                }
                catch(Exception e)
                {
                    throw e;
                }
                System.Threading.Thread.Sleep(3000);
            }
        }

        private void ParseTransaction(string filePath, string fileName)
        {
            string managerName = fileName.Split('_')[0];
            using(StreamReader reader = new StreamReader(filePath))
            {
                _parser = new CSVParser(reader);
                foreach(var data in _parser.GetAllData())
                {
                    this._data.Add(_transactionFactory.CreateNew(data, managerName));
                }
                _parser.Dispose();
            }
            AppendData();
        }

        private void AppendData()
        {
            foreach (CSVTransaction transaction in _data)
            {
                _unitOfWork.Add(transaction);
            }
            _data.Clear();
        }

    }
}
