using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Task4Console.Buisness.CSVDataModels;

namespace Task4Console.Buisness.CSVParsing
{
    public class CSVParser : ICSVParser, IDisposable
    {
        private List<string[]> _data;

        private StreamReader _reader;

        private bool isDisposed = false;

        public CSVParser(StreamReader reader)
        {
            _data = new List<string[]>();
            this._reader = reader;
        }

        public List<string[]> GetAllData()
        {
            while (!_reader.EndOfStream)
            {
                _data.Add(GetNextRow());
            }
            return _data;
        }

        public string[] ReadLine()
        {
            return GetNextRow();
        }

        public void Clear()
        {
            this._data.Clear();
        }

        private string[] GetNextRow()
        {
            string row = _reader.ReadLine();
            var values = row.Split(';');
            return values;
           
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed)
            {
                return;
            }
            if (disposing)
            {
                _reader.Dispose();
            }
            isDisposed = true;
        }
    }
}
