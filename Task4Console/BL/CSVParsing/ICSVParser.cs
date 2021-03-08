using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4Console.Buisness.CSVDataModels;

namespace Task4Console.Buisness.CSVParsing
{
    public interface ICSVParser : IDisposable
    {
        string[] ReadLine();

        List<string[]> GetAllData();

        void Clear();


    }
}
