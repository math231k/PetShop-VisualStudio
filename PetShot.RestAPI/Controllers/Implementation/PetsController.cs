using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PetShop.Core.ApplicationServices;
using PetShop.Core.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShot.WebAPI.Controllers.Implementation
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase, IPetController
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET: api/<PetsController>
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetPets();
        }

        // GET api/<PetsController>/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest("error 400, parametre ''id'' cannot be less than 1");
            }
            else if (_petService.GetSpecificPet(id) == null)
            {
                return NotFound("Error 404, pet not found");
            }
            return _petService.GetSpecificPet(id);
        }

        // POST api/<PetsController>
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet value)
        {
            if (string.IsNullOrEmpty(value.Name))
            {
                return BadRequest("Name is required for a pet");
            }
            return _petService.CreatePet(value);
        }

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet value)
        {
            if (id < 0 || id != value.Id)
            {
                return BadRequest("Error 400 Parameter ''id'' didnt match pet id");
            }
            else if (_petService.UpdateDetails(value)==null)
            {
                return NotFound("Error 404, pet not found");
            }
            _petService.UpdateDetails(value);
            return NoContent();
        }

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id, [FromBody] Pet value)
        {
            Pet DeletedPet = _petService.RemovePet(value);
            if(DeletedPet == null)
            {
                return BadRequest("error 404, Pet not found");
            }
            return _petService.RemovePet(value);
        }
        //GET api/<PetsController>/PetName?name=L
        [HttpGet("PetName")]
        public ActionResult<IEnumerable<Pet>> GetFiltered(string name)
        {
            if(name == null)
            {
                return BadRequest("error 400, parameter ''Name'' cannot be empty");
            }
           return _petService.SearchForPet(name);
        }
    }
}
