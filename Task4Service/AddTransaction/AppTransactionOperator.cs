using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Task4Service.ADO.UnitOfWork;
using Task4Service.ADO.Repositories.GenericRepository.GenericRepositoryImplementation;
using Task4Service.Buisness.CSVDataModels;
using Task4Service.ADO.TransactionModel;

namespace Task4Service.ADO.AddTransaction
{
    class AppTransactionOperator : IUnitOfWork<CSVTransaction>
    {
        private GenericRepository<Manager> managerRepository;

        private GenericRepository<Product> productRepository;

        private GenericRepository<Transaction> transactionRepository;

        private GenericRepository<User> userRepository;


        public AppTransactionOperator(DbContext context)
        {
            context.Database.CreateIfNotExists();
            managerRepository = new GenericRepository<Manager>(context);
            productRepository = new GenericRepository<Product>(context);
            transactionRepository = new GenericRepository<Transaction>(context);
            userRepository = new GenericRepository<User>(context);
            
        }

        public void Add(CSVTransaction obj)
        {
            var user = userRepository.Context.Set<User>()
                .Where(usr => usr.UserName == obj.Client)
                .FirstOrDefault();
            if (user == null)
            {
                user = new User { UserName = obj.Client };
                userRepository.Add(user);
            }


            var manager = managerRepository.Context.Set<Manager>()
                .Where(mngr => mngr.ManagerName == obj.Manager)
                .FirstOrDefault();
            if (manager == null)
            {
                manager = new Manager { ManagerName = obj.Manager };
                managerRepository.Add(manager);
            }


            var product = productRepository.Context.Set<Product>()
                .Where(prod => prod.ProductName == obj.Product)
                .FirstOrDefault();
            if (product == null)
            {
                product = new Product { ProductName = obj.Product, Cost = obj.TotalCost };
                productRepository.Add(product);
            }

            transactionRepository.Add(new Transaction
            {
                Date = obj.Date,
                User = user,
                Product = product,
                Manager = manager,
                Coast = obj.TotalCost
            });

            this.Save();
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
            productRepository.Save();
            managerRepository.Save();
            userRepository.Save();
            transactionRepository.Save();
        }
    }
}
