using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        private OrderManagementSystemsEntities1 entity = new OrderManagementSystemsEntities1();

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult GetProduct()
        {
            return Ok(entity.Products);
        }
        [HttpGet]
        [Route("Get/{Productid :int}")]
        public IHttpActionResult Get(int Productid)
        {
            var xyz = entity.Products.Where(a => a.ProductId==Productid).Select(z => z);
            return Ok(xyz);
        }

      [HttpPost]
      [Route("Post")]
      public IHttpActionResult PostProduct(Product productdata)
        {
            entity.Products.Add(productdata);
            return Created("", entity);
        }
        [HttpPut]
        [Route("update/{id:int}")]
        public IHttpActionResult Update(int id,[FromBody]Product product)
        {
            var a = entity.Products.FirstOrDefault(x => x.ProductId == id);
            return Ok(product);

        }
       [HttpDelete]
       [Route("delete/{id:int}")]
       public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Product id");

            var product = entity.Products.Where(x => x.ProductId == id).FirstOrDefault();
            entity.Entry(product).State = System.Data.Entity.EntityState.Deleted;
            entity.SaveChanges();
            return Ok(product);

        }

    }
}
