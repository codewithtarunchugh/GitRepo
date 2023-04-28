using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        AppDbContext _db;
        public ProductController(AppDbContext db)
        {
            _db = db;
        }

        //GET: api/product/getall
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _db.Products.ToList();
        }

        //GET: api/product/get
        [HttpGet]
        public IActionResult Get()
        {
            var data = _db.Products.ToList();
            return Ok(data); //200OK, data
        }

        //GET: api/product/getproducts
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var data = _db.Products.ToList();
            return Ok(data); //200OK, data+datatype
        }

        //GET: api/product/get/{id}
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _db.Products.Find(id);
        }

        //POST: api/product/add
        [HttpPost]
        public IActionResult Add(Product model)
        {
            try
            {
                _db.Products.Add(model);
                _db.SaveChanges();
                return CreatedAtAction("Add", model); //201, add, data
                //return StatusCode(StatusCodes.Status201Created, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //PUT: api/product/update/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product model)
        {
            try
            {
                if (id != model.ProductId)
                    //return BadRequest();
                    return StatusCode(StatusCodes.Status400BadRequest);

                _db.Products.Update(model);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //PUT: api/product/delete/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Product model = _db.Products.Find(id);
                if (model != null)
                {
                    _db.Products.Remove(model);
                    _db.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
