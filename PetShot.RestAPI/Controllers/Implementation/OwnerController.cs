using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Entities;

namespace PetShot.WebAPI.Controllers.Implementation
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase, IOwnerController
    {
        public void Delete(int id, [FromBody] Owner value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Owner> Get()
        {
            throw new NotImplementedException();
        }

        public Owner Get(int x)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> GetFiltered()
        {
            throw new NotImplementedException();
        }

        public ActionResult<Owner> Post([FromBody] Owner value)
        {
            throw new NotImplementedException();
        }

        public ActionResult<Owner> Put(int id, [FromBody] Owner value)
        {
            throw new NotImplementedException();
        }
    }
}
