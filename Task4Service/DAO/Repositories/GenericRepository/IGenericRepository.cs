using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Service.ADO.Repositories.GenericRepository
{
    interface IGenericRepository<Entity> where Entity : class
    {
        void Add(Entity entity);

        void Remove(Entity entity);

        void Save();
    }
}
