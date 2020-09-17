using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;

namespace PetShot.WebAPI.Controllers.Implementation
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase, IOwnerController
    {
        private readonly IOwnerService _OwnerService;
        private List<Owner> OwnerReferance;
        public OwnerController(IOwnerService ownerService)
        {
            _OwnerService = ownerService;
            OwnerReferance = _OwnerService.ReadOwners();
        }
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            if (id < 1)
            {
                return NotFound("Error 404, Owner not found");
            }
            Owner o = _OwnerService.DeleteOwner(OwnerReferance.ElementAt(id - 1));
            Fetch();
            return Accepted(o);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            if (OwnerReferance.Count == 0)
            {
                return NoContent();
            }
            return Ok(_OwnerService.ReadOwners());
        }
        [HttpGet("{id}")]
        public ActionResult<Owner> GetById(int id)
        {
            if (_OwnerService.GetOwnerById(id) == null)
            {
                return NotFound("Error 404, Owner not found");
            }
            else if (id < 1)
            {
                return BadRequest("Error 400, id cannot be less than 1");
            }
            return Ok(_OwnerService.GetOwnerById(id));
        }
        [HttpGet("byname")]
        public ActionResult<IEnumerable<Owner>> GetFiltered(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return BadRequest("Error 400, Please enter a name to search for");
            }
            else if (_OwnerService.SearchForOwner(name).Count == 0)
            {
                return NoContent();
            }
            return Ok(_OwnerService.SearchForOwner(name));
        }
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner value)
        {
            if (String.IsNullOrEmpty(value.FirstName) && String.IsNullOrEmpty(value.PhoneNumber))
            {
                return BadRequest("Error 400, An owner needs a name and a phonenumber");
            }
            return StatusCode(201, _OwnerService.CreateOwner(value));
        }
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner value)
        {
            if (String.IsNullOrEmpty(value.FirstName) && String.IsNullOrEmpty(value.PhoneNumber))
            {
                return BadRequest("Error 400, An owner needs a name and a phonenumber");
            }
            value.Id = id;
            return Accepted(_OwnerService.UpdateOwner(value));
        }

        private void Fetch()
        {
            OwnerReferance = _OwnerService.ReadOwners();
        }
    }
}
