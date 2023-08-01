using AutoMapper;
using DomainLayer.Interfaces;
using DomainLayer.Models;
using RepositoryLayer;
using RepositoryLayer.Repositories;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{



    public class ProductService : IProductService
    {
        MyDbContext context = new MyDbContext();

        private Mapper mapper;

        public IUnitOfWork _unitOfWork;
        public ProductService()
        {

            context = new MyDbContext();



            _unitOfWork = new UnitOfWork(context);

            var config = new MapperConfiguration(cfg =>   // AutoMapper Configuration
            {
                cfg.CreateMap<Product, ProductDTO>();

            });
            mapper = new Mapper(config);



        }


        IEnumerable<ProductDTO> IProductService.GetProduct()
        {


            // Mapping Product to ProductDTO using AutoMapper

            var products = mapper.Map<List<ProductDTO>>(_unitOfWork.ProductRepo.GetAll());
            return products;


        }
    }











    // without DTO and Automapper
    //public class ProductService : IProductService
    //{
    //    MyDbContext context = new MyDbContext();

    //    public IUnitOfWork _unitOfWork;
    //    public ProductService()
    //    {
    //        _unitOfWork = new UnitOfWork(context);
    //    }


    //    IEnumerable<Product> IProductService.GetProduct()
    //    {

    //        var product = _unitOfWork.ProductRepo.GetAll();

    //        return product;
    //    }
    //}
}
