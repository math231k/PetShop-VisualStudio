using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PetShop.Core.ApplicationServices;
using PetShop.Core.Entities;
using PetShop.Infrastructure.MSSQL.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShot.WebAPI.Controllers.Implementation
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase, IPetController
    {
        private readonly IPetService _petService;
        private readonly PetShopAppContext _ctx;
        private List<Pet> PetsReferance = new List<Pet>();

        public PetsController(IPetService petService)
        {
            _petService = petService;
            PetsReferance = _petService.GetPets();
        }

        
        /// <summary>
        /// GET: api/<PetsController>
        /// </summary>
        /// <returns>An ActionResult<IEnumerable<Pet>></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            if (PetsReferance.Count == 0)
            {
                return NoContent();
            }
            return Ok(_petService.GetPets());
        }

        // GET api/<PetsController>/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest("Error 400, id cannot be less than 1");
            }
            else if (_petService.GetSpecificPet(id) == null)
            {
                return NotFound("Error 404, pet not found");
            }
            return Ok(_petService.GetSpecificPet(id));
        }

        // POST api/<PetsController>
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet value)
        {
            if (string.IsNullOrEmpty(value.Name))
            {
                return BadRequest("Name is required for a pet");
            }
            Pet p = _petService.CreatePet(value);
            Fetch();
            return StatusCode(201, p);
        }

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet value)
        {
            if (id < 0)
            {
                return NotFound("Error 404, pet not found");
            }
            else if (String.IsNullOrEmpty(value.Name))
            {
                return BadRequest("Error 400, Pet needs a name before you update");
            }
            _petService.UpdateDetails(value);
            Fetch();
            return Accepted();
        }

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            if (id<1)
            {
                return NotFound("Error 404, pet not found");
            }
            _petService.RemovePet(PetsReferance.ElementAt(id - 1));
            Fetch();
            return Accepted();
        }
        // GET api/<PetsController>/byname?name=a
        [HttpGet("byname")]
        public ActionResult<IEnumerable<Pet>> GetFiltered(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return BadRequest("Please enter a name to search for");
            }
            else if (_petService.SearchForPet(name).Count == 0)
            {
                return NoContent();
            }
            return Ok(_petService.SearchForPet(name));
        }

        private void Fetch()
        {
            PetsReferance = _petService.GetPets();
        }
    }
}
