using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        AppDbContext _db;
        public ProductController(AppDbContext db) //constructor
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //method based syntax
            var products = _db.Products.ToList();
            //var products = _db.Products.Where(p => p.ProductId > 0).Select(p => p).ToList();

            //query based syntax
            //var products = (from p in _db.Products
            //                    //where p.ProductId > 0
            //                select p).ToList();

            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _db.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Product obj = new Product
                    {
                        Name = model.Name,
                        Description = model.Description,
                        UnitPrice = model.UnitPrice,
                        CategoryId = model.CategoryId
                    };

                    _db.Products.Add(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Categories = _db.Categories.ToList();
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        //public IActionResult Edit(int id)
        //{
        //    //Product product = _db.Products.Find(id);
        //    usp_getproductResult product = _db.Procedures.usp_getproductAsync(id).Result.FirstOrDefault();

        //    ProductModel productModel = new ProductModel
        //    {
        //        ProductId = product.ProductId,
        //        Name = product.Name,
        //        Description = product.Description,
        //        UnitPrice = product.UnitPrice,
        //        CategoryId = product.CategoryId
        //    };
        //    ViewBag.Categories = _db.Categories.ToList();
        //    return View(productModel);
        //}

        public async Task<IActionResult> Edit(int id)
        {
            //Product product = _db.Products.Find(id);
            var products = await _db.Procedures.usp_getproductAsync(id);
            if (products != null && products.Count > 0)
            {
                usp_getproductResult product = products.FirstOrDefault();

                ProductModel productModel = new ProductModel
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Description = product.Description,
                    UnitPrice = product.UnitPrice,
                    CategoryId = product.CategoryId
                };
                ViewBag.Categories = _db.Categories.ToList();
                return View(productModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(ProductModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Product obj = new Product
                    {
                        ProductId = model.ProductId,
                        Name = model.Name,
                        Description = model.Description,
                        UnitPrice = model.UnitPrice,
                        CategoryId = model.CategoryId
                    };

                    _db.Products.Update(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Categories = _db.Categories.ToList();
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            Product? product = _db.Products.Find(id);
            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
