using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer;
using ServiceLayer.Interfaces;
using MVC_OA.Models;
using AutoMapper;
using ServiceLayer.Models;

namespace MVC_OA.Controllers
{
    public class ProductController : Controller
    {
        public IProductService ProductService;
        private Mapper mapper;


        public ProductController()
        {
            ProductService = new ProductService();

            //using automapper 
            var config = new MapperConfiguration(cfg =>
            {
                // Configuring Map
                cfg.CreateMap<ProductDTO, ProductVM>();
                // Any Other Mapping Configuration ....
            });
            // Create an Instance of Mapper and return that Instance
            mapper = new Mapper(config);
        }

        public ActionResult Index()
        {
            var products = mapper.Map<List<ProductVM>>(ProductService.GetProduct());

            return View(products);


            //whitout Automapper and DTO
            //List<ProductVM> products = new List<ProductVM>();
            //var productList = ProductService.GetProduct();

            //foreach (var product in productList)
            //{
            //    ProductVM productVM = new ProductVM();
            //    productVM.ID = product.ID;
            //    productVM.ProductName = product.ProductName;
            //    productVM.Category = product.Category;
            //    products.Add(productVM);
            //}
            //return View(products);


        }
    }
}