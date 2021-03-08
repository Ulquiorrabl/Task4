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

        private GenericRepository<Product> productRepostitory;

        private GenericRepository<Transaction> transactionRepository;

        private GenericRepository<User> userRepository;


        public AppTransactionOperator(DbContext context)
        {
            context.Database.CreateIfNotExists();
            managerRepository = new GenericRepository<Manager>(context);
            productRepostitory = new GenericRepository<Product>(context);
            transactionRepository = new GenericRepository<Transaction>(context);
            userRepository = new GenericRepository<User>(context);
            
        }

        public void Add(CSVTransaction obj)
        {

            User user = new User { UserName = obj.Client };
            Product product = new Product { ProductName = obj.Product, Cost = obj.TotalCost };
            Manager manager = new Manager { ManagerName = obj.Manager };
            userRepository.Add(user);
            productRepostitory.Add(product);
            managerRepository.Add(manager);
            transactionRepository.Add(new Transaction { Date = obj.Date, User = user, Product = product, 
                Manager = manager, Coast = obj.TotalCost});
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
            productRepostitory.Save();
            managerRepository.Save();
            userRepository.Save();
            transactionRepository.Save();
        }
    }
}
