using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Console.ADO.UnitOfWork
{
    public interface IUnitOfWork<Type> where Type : class
    {
        void Add(Type obj);

        void Remove(Type obj);

        void Update(Type obj);

        void Save();
    }
}
