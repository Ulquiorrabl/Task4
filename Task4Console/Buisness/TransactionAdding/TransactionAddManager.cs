﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Task4Console.Buisness.CSVDataModels;
using Task4Console.Buisness.CSVParsing;
using Task4Console.Buisness.ReportWatching;
using Task4Console.Buisness.DataFactories;

namespace Task4Console.Buisness.TransactionAdding
{
    public class TransactionAddManager
    {
        private CSVParser _parser;

        private TransactionFactory _transactionFactory;

        private ReportWatcher _reportWatcher;

        private ADO.UnitOfWork.IUnitOfWork<CSVTransaction> _unitOfWork;

        private List<CSVTransaction> _data;

        public TransactionAddManager(CSVParser parser = null, TransactionFactory transactionFactory = null,
            ReportWatcher reportWatcher = null)
        {
            this._parser = parser;
            this._transactionFactory = transactionFactory;
            this._reportWatcher = reportWatcher;
        }

        public TransactionAddManager(FileSystemWatcher fileSystemWatcher, ADO.UnitOfWork.IUnitOfWork<CSVTransaction> unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._transactionFactory = new TransactionFactory();
            this._reportWatcher = new ReportWatcher(fileSystemWatcher);
            this._data = new List<CSVTransaction>();
            this._reportWatcher.ReportFileAdded += new EventHandler<string>(OnTransactionFileCreated);
            this._reportWatcher.StartWatch();
            Console.WriteLine("WatchStarted");
        }

        private void OnTransactionFileCreated(object obj, string filePath)
        {
            Task.Factory.StartNew(() => CreateParsingTask(filePath));
        }

        private void CreateParsingTask(string filePath)
        {
            while (true)
            {
                try
                {
                    ParseTransaction(filePath);
                    break;
                }
                catch
                {

                }
                System.Threading.Thread.Sleep(3000);
            }
        }

        private void ParseTransaction(string filePath)
        {
            using(StreamReader reader = new StreamReader(filePath))
            {
                _parser = new CSVParser(reader);
                foreach(var data in _parser.GetAllData())
                {
                    this._data.Add(_transactionFactory.CreateNew(data));
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
