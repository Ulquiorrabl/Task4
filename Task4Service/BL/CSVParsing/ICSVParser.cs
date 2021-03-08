using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4Service.Buisness.CSVDataModels;

namespace Task4Service.Buisness.CSVParsing
{
    public interface ICSVParser : IDisposable
    {
        string[] ReadLine();

        List<string[]> GetAllData();

        void Clear();


    }
}
