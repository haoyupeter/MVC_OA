using DomainLayer.Interfaces;
using DomainLayer.Models;
using RepositoryLayer;
using RepositoryLayer.Repositories;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ProductService : IProductService
    {
        MyDbContext context = new MyDbContext();

        public IUnitOfWork _unitOfWork;
        public ProductService()
        {
            _unitOfWork = new UnitOfWork(context);
        }


        IEnumerable<Product> IProductService.GetProduct()
        {
           
            var product = _unitOfWork.ProductRepo.GetAll();

            return product;
        }
    }
}
