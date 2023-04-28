using ePizzaHub.Services.Interfaces;
using ePizzaHub.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace ePizzaHub.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ICatalogService _catalogService;
        IMemoryCache _cache;
        public HomeController(ILogger<HomeController> logger, ICatalogService catalogService, IMemoryCache cache)
        {
            _logger = logger;
            _catalogService = catalogService;
            _cache = cache;
        }

        public IActionResult Index()
        {
            //var items = _catalogService.GetItems();
            //cache
            string key = "catalog";
            var items = _cache.GetOrCreate(key, entry =>
            {
                entry.AbsoluteExpiration = DateTime.Now.AddHours(12);
                entry.SlidingExpiration = TimeSpan.FromMinutes(15);
                return _catalogService.GetItems();
            });

            try
            {
                int x = 0, y = 3;
                int z = y / x;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return View(items);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}