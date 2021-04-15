using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication13.Models;


namespace WebApplication13.Controllers
{
    [RoutePrefix("api/Order")]
    public class OrderController : ApiController
    {
        private OrderManagementSystemsEntities2 entity = new OrderManagementSystemsEntities2();

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult GetOrder()
        {
            return Ok(entity.Users);
        }
        [HttpGet]
        [Route("Get/Userid:int")]
        public IHttpActionResult Get(int Userid)
        {
            var abc = entity.Orders.Where(e => e.UserId == Userid).Select(c => c);
            return Ok(abc);

        }

    }
}
