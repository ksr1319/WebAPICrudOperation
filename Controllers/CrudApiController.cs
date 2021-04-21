using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrudOperationsUsingWebAPI.Models;

namespace CrudOperationsUsingWebAPI.Controllers
{
    [RoutePrefix("api/CrudApi")]
    public class CrudApiController : ApiController
    {

        satheeshdbEntities satheeshdbEntities = new satheeshdbEntities();
        [HttpGet]
        public IEnumerable<customer> GetCustomers()
        {
            return satheeshdbEntities.customers.ToList();
        }
        [HttpGet]
        public customer GetCustomerById(int id)
        {
            return satheeshdbEntities.customers.FirstOrDefault(x=>x.customerno==id);
        }
        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Post([FromBody] customer customer)
        {
            using (satheeshdbEntities satheeshdbEntities = new satheeshdbEntities())
            {
                satheeshdbEntities.customers.Add(customer);
                satheeshdbEntities.SaveChanges();
                return Ok(customer);
            }

        }
        [HttpDelete]
       
        public IHttpActionResult Delete(int id)
        {
            using (satheeshdbEntities satheeshdbEntities = new satheeshdbEntities())
            {
                satheeshdbEntities.customers.Remove( satheeshdbEntities.customers.FirstOrDefault(x => x.customerno == id));
                satheeshdbEntities.SaveChanges();
                return Ok();
            }

        }
        public IHttpActionResult Put(int id, [FromBody] customer customer)
        {

            using (satheeshdbEntities satheeshdbEntities = new satheeshdbEntities())
            {
               var entity= satheeshdbEntities.customers.FirstOrDefault(x => x.customerno == id);

                entity.customeradress = customer.customeradress;
                entity.name = customer.name;
                satheeshdbEntities.SaveChanges();
                return Ok(customer);
            }
        }



    }
}

