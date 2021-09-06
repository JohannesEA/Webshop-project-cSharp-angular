using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStoreAPI.DB;
using WebStoreAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebStoreAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ValuesController : Controller
    {

        private readonly WebShopDB _db;

        public ValuesController(WebShopDB db)
        {
            _db = db;
        }


        // GET: api/values
        [HttpGet("products")]
        public List<Product> GetProducts()
        {
            List<Product> products = _db.Products.ToList();

            return products;
        }

        // GET api/values/5
        [HttpGet("storage/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost("storage")]
        public void Post([FromBody] string  value)
        {
        }

        [HttpPost("product")]
        public void PostNewProduct(Product product)
        {

            _db.Products.Add(new Product()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Type = product.Type,
                    Description = product.Description,
                    Price = product.Price,
                    Amount = product.Amount,
            });

            _db.SaveChanges();
            }


        

        // PUT api/values/5
        [HttpPut("storage/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("storage/{id}")]
        public void Delete(int id)
        {
        }
    }
}
