using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Task4Service.ADO.Repositories.GenericRepository.GenericRepositoryImplementation
{
    class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        public DbContext Context { get; set; }

        private DbSet<Entity> EntitySet { get; set; }

        public GenericRepository(DbContext context)
        {
            this.Context = context;
            this.EntitySet = context.Set<Entity>();
        }

        public void Add(Entity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            EntitySet.Add(entity);
        }

        public void Remove(Entity entity)
        {
            EntitySet.Remove(entity);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
