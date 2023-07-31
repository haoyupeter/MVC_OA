using DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly MyDbContext context;
        public IProductRepo ProductRepo { get; }
        public ICustomerRepo CustomerRepo { get; }

        public UnitOfWork(MyDbContext dbContext)
        {
            context = dbContext;
            ProductRepo = new ProductRepo(context);
            CustomerRepo = new CustomerRepo(context);

        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }

    }
}
