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

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        public ActionResult<Owner> Delete(int id, [FromBody] Owner value)
        {
            Owner owner = _ownerService.DeleteOwner(value);
            if (owner == null)
            {
                return BadRequest("Pet not found");
            }
            return _ownerService.DeleteOwner(value);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.ReadOwners();
        }
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            return _ownerService.GetSpecificOwner(id);
        }
        [HttpGet("byname")]
        public ActionResult<IEnumerable<Owner>> GetFiltered(string querry)
        {
            return _ownerService.SearchForOwner(querry);
        }
        [HttpDelete("{id}")]
        public ActionResult<Owner> Post([FromBody] Owner value)
        {
            return _ownerService.CreateOwner(value);
        }
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner value)
        {
            return _ownerService.UpdateOwner(value);
        }
    }
}
