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
    public class PetTypeController : ControllerBase, IPetTypeController
    {
        private readonly IPetTypeService _petTypeService;
        private List<PetType> PetTypesReferance = new List<PetType>();
        public PetTypeController(IPetTypeService petTypeService)
        {
            _petTypeService = petTypeService;
            PetTypesReferance = _petTypeService.ReadPetTypes();
        }
        [HttpGet]
        public ActionResult<IEnumerable<PetType>> Get()
        {
            if (PetTypesReferance.Count == 0)
            {
                return NoContent();
            }
            return Ok(_petTypeService.ReadPetTypes());
        }

        // GET api/<PetsController>/5
        [HttpGet("{id}")]
        public ActionResult<PetType> GetById(int id)
        {
            if (id < 1)
            {
                return BadRequest("Error 400, id cannot be less than 1");
            }
            else if (_petTypeService.GetPetTypeById(id) == null)
            {
                return NotFound("Error 404, pet not found");
            }
            return Ok(_petTypeService.GetPetTypeById(id));
        }

        // POST api/<PetsController>
        [HttpPost]
        public ActionResult<PetType> Post([FromBody] PetType value)
        {
            if (string.IsNullOrEmpty(value.TypeName))
            {
                return BadRequest("Name is required for a pet");
            }
            PetType p = _petTypeService.CreatePetType(value);
            Fetch();
            return StatusCode(201, p);
        }

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public ActionResult<PetType> Put(int id, [FromBody] PetType value)
        {
            if (id < 0)
            {
                return NotFound("Error 404, pet not found");
            }
            else if (String.IsNullOrEmpty(value.TypeName))
            {
                return BadRequest("Error 400, Pet needs a name before you update");
            }
            _petTypeService.UpdatePetType(value);
            Fetch();
            return Accepted();
        }

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public ActionResult<PetType> Delete(int id)
        {
            if (id < 1)
            {
                return NotFound("Error 404, pet not found");
            }
            _petTypeService.DeletePetType(PetTypesReferance.ElementAt(id - 1));
            Fetch();
            return Accepted();
        }
        // GET api/<PetsController>/byname?name=a
        [HttpGet("byname")]
        public ActionResult<IEnumerable<PetType>> GetFiltered(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return BadRequest("Please enter a name to search for");
            }
            else if (_petTypeService.SearchForPetType(name).Count == 0)
            {
                return NoContent();
            }
            return Ok(_petTypeService.SearchForPetType(name));
        }

        private void Fetch()
        {
            PetTypesReferance = _petTypeService.ReadPetTypes();
        }
    }
}
