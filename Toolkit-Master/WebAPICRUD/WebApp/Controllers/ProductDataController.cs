using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductDataController : Controller
    {
        Uri _baseAddress;
        IConfiguration _configuration;
        HttpClient _client;
        public ProductDataController(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseAddress = new Uri(_configuration["ApiAddress"]);
            _client = new HttpClient();
            _client.BaseAddress = _baseAddress;
        }

        public IActionResult Index()
        {
            IEnumerable<ProductModel> model = new List<ProductModel>();
            var response = _client.GetAsync(_client.BaseAddress + "/product/getall").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                model = JsonSerializer.Deserialize<IEnumerable<ProductModel>>(data);
            }
            return View(model);
        }
        public IEnumerable<CategoryModel> GetCategories()
        {
            IEnumerable<CategoryModel> model = new List<CategoryModel>();
            var response = _client.GetAsync(_client.BaseAddress + "/category/getall").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                model = JsonSerializer.Deserialize<IEnumerable<CategoryModel>>(data);
            }
            return model;
        }

        public IActionResult Create()
        {
            ViewBag.Categories = GetCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                string strData = JsonSerializer.Serialize(model);
                StringContent content = new StringContent(strData, Encoding.UTF8, "application/json");
                var response = _client.PostAsync(_client.BaseAddress + "/product/add", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Categories = GetCategories();
            return View();
        }

        public IActionResult Edit(int id)
        {
            ProductModel model = new ProductModel();
            var response = _client.GetAsync(_client.BaseAddress + "/product/get/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                model = JsonSerializer.Deserialize<ProductModel>(data);
            }
            ViewBag.Categories = GetCategories();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                string strData = JsonSerializer.Serialize(model);
                StringContent content = new StringContent(strData, Encoding.UTF8, "application/json");
                var response = _client.PutAsync(_client.BaseAddress + "/product/update/" + model.ProductId, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Categories = GetCategories();
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var response = _client.DeleteAsync(_client.BaseAddress + "/product/delete/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
