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
    public class PetTypeController : ControllerBase, IPetTypeController
    {
        public ActionResult<PetType> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult<IEnumerable<PetType>> Get()
        {
            throw new NotImplementedException();
        }

        public ActionResult<PetType> GetById(int x)
        {
            throw new NotImplementedException();
        }

        public ActionResult<IEnumerable<PetType>> GetFiltered(string name)
        {
            throw new NotImplementedException();
        }

        public ActionResult<PetType> Post([FromBody] PetType value)
        {
            throw new NotImplementedException();
        }

        public ActionResult<PetType> Put(int id, [FromBody] PetType value)
        {
            throw new NotImplementedException();
        }
    }
}
