using DAL.Entities;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        AppDbContext _db;
        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        //GET: api/category/getall
        [HttpGet]
        public IEnumerable<Category> GetAll()
        {
            return _db.Categories.ToList();
        }
    }
}
