using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Task4Console.ADO.UnitOfWork;
using Task4Console.ADO;
using Task4Console.ADO.Repositories.GenericRepository.GenericRepositoryImplementation;
using Task4Console.Buisness.CSVDataModels;

namespace Task4Console.ADO.AddTransaction
{
    class AppTransactionOperator : IUnitOfWork<CSVTransaction>
    {
        private GenericRepository<Manager> managerRepository;

        private GenericRepository<Product> productRepostitory;

        private GenericRepository<Transaction> transactionRepository;

        private GenericRepository<User> userRepository;


        public AppTransactionOperator(DbContext context)
        {
            Console.WriteLine("InitStarted");
            managerRepository = new GenericRepository<Manager>(context);
            productRepostitory = new GenericRepository<Product>(context);
            transactionRepository = new GenericRepository<Transaction>(context);
            userRepository = new GenericRepository<User>(context);
            Console.WriteLine("InitEnded");
        }

        public void Add(CSVTransaction obj)
        {
            Console.WriteLine("Add started");
            User user = new User { Name = obj.Client };
            Product product = new Product { Name = obj.Product, Coast = obj.TotalCoast};
            Manager manager = new Manager { Name = "Manager" };
            userRepository.Add(user);
            productRepostitory.Add(product);
            managerRepository.Add(manager);
            transactionRepository.Add(new Transaction { Date = obj.Date, User = user, Product = product, 
                Manager = manager, Coast = obj.TotalCoast});
            this.Save();
            Console.WriteLine("Saved");
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
            Console.WriteLine("Saved");
        }
    }
}
