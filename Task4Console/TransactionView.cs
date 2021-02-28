using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4Console.ADO.UnitOfWork;
using Task4Console.Buisness.CSVDataModels;

namespace Task4Console
{
    class TransactionView : IUnitOfWork<CSVTransaction>
    {
        public void Add(CSVTransaction obj)
        {
            Console.WriteLine(obj);
        }

        public void Remove(CSVTransaction obj)
        {
            throw new NotImplementedException();
        }

        public void Update(CSVTransaction obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
