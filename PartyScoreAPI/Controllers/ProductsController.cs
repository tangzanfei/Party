using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using PartyScoreAPI.Models;
using PartyScoreAPI.Repository;

namespace PartyScoreAPI.Controllers
{
    public class ProductsController : ApiController
    {
        static ProductsRepository repository = new ProductsRepository();
        public IEnumerable<Product> GetAllProducts()
        {
            return repository.Products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = repository.FindProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        // POST: api/User
        [HttpPost]
        public void PostProduct([FromBody]Product value)
        {
            if (value != null)
            {
                repository.AddProduct(value);
            }

        }

        public class model
        {
            public string code;
            public string wifiMac;
        }

        [Route("products/CheckIn")]
        [HttpPost]
        public bool CheckIn([FromBody]model m)
        {
            return repository.CheckIn(m.code, m.wifiMac);
        }
        //public JsonResult<ResultData> GetData()
        //{
        //    return null;
        //}
    }
}
