using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShot.WebAPI.Controllers.Implementation
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase, IOwnerController
    {
        private readonly IOwnerService _OwnerService;
        private List<Owner> owners;
        public OwnerController(IOwnerService ownerService)
        {
            this._OwnerService = ownerService;
            owners = _OwnerService.ReadOwners();
        }
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            if (id < 1 || id > owners.Count())
            {
                return BadRequest("Parametre was either to large or smaller than 0");
            }
            _OwnerService.DeleteOwner(owners.ElementAt(id));
            FetchOwners();
            return Accepted("The owner was deleted Succesfully");
        }
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            if (owners.Count == 0)
            {
                return NoContent();
            }
            return owners;
        }
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            if (id < 1 || id > owners.Count())
            {
                return BadRequest("Id either to big or smaller than 1");
            }
            //Create a GetSpecificOwner Method in your service
            return owners.ElementAt(id);
        }
        [HttpGet("{byname}")]
        public ActionResult<IEnumerable<Owner>> GetFiltered(string name)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner value)
        {
            if (String.IsNullOrEmpty(value.FirstName) && String.IsNullOrEmpty(value.PhoneNumber))
            {
                return BadRequest("An owner need a name and a phonenumber");
            }
            _OwnerService.CreateOwner(value);
            FetchOwners();
            return Created(value.ToString(), value);
        }
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner value)
        {
            if (String.IsNullOrEmpty(value.FirstName) && String.IsNullOrEmpty(value.PhoneNumber))
            {
                return BadRequest("An owner need a name and a phonenumber");
            }
            _OwnerService.UpdateOwner(value);
            FetchOwners();
            return Accepted();
        }

        private void FetchOwners()
        {
            owners = _OwnerService.ReadOwners();
        }
    }
}
