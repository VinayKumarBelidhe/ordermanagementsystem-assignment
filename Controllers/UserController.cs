using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private OrderManagementSystemsEntities entity = new OrderManagementSystemsEntities();
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult GetUser()
        {
            return Ok(entity.Users);
        }
        [HttpGet]
        [Route("Get/{Userid:int}")]
        public IHttpActionResult Get(int Userid)
        {
            var abc = entity.Users.Where(e => e.Userid == Userid).Select(c => c);
            return Ok(abc);
        }
        [HttpPost]
        [Route("Post")]
        public IHttpActionResult PostUser(User userdata)
        {
            entity.Users.Add(userdata);
            return Created("", entity);

        }
        [HttpPut]
        [Route("update/{id:int}")]
        public IHttpActionResult Update(int id,[FromBody]User user)
        {
            var a = entity.Users.FirstOrDefault(x => x.Userid == id);
            return Ok(user);
        }
        [HttpDelete]
        [Route("delete/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid User id");

            var user = entity.Users.Where(x => x.Userid == id).FirstOrDefault();
            entity.Entry(user).State = System.Data.Entity.EntityState.Deleted;
            entity.SaveChanges();

            return Ok(user);

        }

    }
}
