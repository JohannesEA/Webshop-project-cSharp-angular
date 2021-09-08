using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStoreAPI.DB;
using WebStoreAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebStoreAPI.Controllers
{
    [ApiController]
    [Route("api/products/")]
    public class ProductController : Controller
    {

        private readonly WebShopDB _db;

        public ProductController(WebShopDB db)
        {
            _db = db;
        }


        // GET: api/values
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
         
            return _db.Products;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workout = await _db.Products.SingleOrDefaultAsync(m => m.Id == id);

            if (workout == null)
            {
                return NotFound();
            }

            return Ok(workout);
        }


        //[HttpPost]
        //public void Post(Product product)
        //{

        //    _db.Products.Add(new Product()
        //        {
        //            Id = product.Id,
        //            Name = product.Name,
        //            Type = product.Type,
        //            Description = product.Description,
        //            Price = product.Price,
        //            Amount = product.Amount,
        //    });



        //    _db.SaveChanges();
        //    }

        [HttpPost]
        public async Task<IActionResult> PostWorkout([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Products.Add(product);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetProductById", new { id = product.Id }, product);
        }



        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product product)
        {
                if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }
            _db.Entry(product).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

    

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workout = await _db.Products.SingleOrDefaultAsync(m => m.Id == id);
            if (workout == null)
            {
                return NotFound();
            }

            _db.Products.Remove(workout);
            await _db.SaveChangesAsync();

            return Ok(workout);
        }


        private bool ProductExists(int id)
        {
            return _db.Products.Any(e => e.Id == id);
        }
    }
}
