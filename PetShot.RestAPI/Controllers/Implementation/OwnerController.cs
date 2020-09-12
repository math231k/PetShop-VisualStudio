using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationServices;
using PetShop.Core.Entities;

namespace PetShot.WebAPI.Controllers.Implementation
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase, IOwnerController
    {
        private readonly IOwnerService _ownerService;
        public ActionResult<Owner> Delete(int id, [FromBody] Owner value)
        {
            Owner owner = _ownerService.DeleteOwner(value);
            if (owner == null)
            {
                return BadRequest("Pet not found");
            }
            return _ownerService.DeleteOwner(value);
        }

        public IEnumerable<Owner> Get()
        {
            return _ownerService.ReadOwners();
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
            return _ownerService.CreateOwner(value);
        }

        public ActionResult<Owner> Put(int id, [FromBody] Owner value)
        {
            return _ownerService.UpdateOwner(value);
        }
    }
}
