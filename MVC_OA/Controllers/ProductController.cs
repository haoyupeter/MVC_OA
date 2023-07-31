using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer;
using ServiceLayer.Interfaces;
using MVC_OA.Models;

namespace MVC_OA.Controllers
{
    public class ProductController : Controller
    {
        public IProductService ProductService;

        public ProductController()
        {
            ProductService = new ProductService();
        }

        public ActionResult Index()
        {
            List<ProductVM> products = new List<ProductVM>();
            var productList = ProductService.GetProduct();

            foreach (var product in productList)
            {
                ProductVM productVM = new ProductVM();
                productVM.ID = product.ID;
                productVM.ProductName = product.ProductName;
                productVM.Category = product.Category;
                products.Add(productVM);
            }
            return View(products);

            
        }
    }
}