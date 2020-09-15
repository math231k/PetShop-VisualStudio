using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShot.WebAPI.Controllers
{
    public interface IPetTypeController
    {
        public ActionResult<IEnumerable<PetType>> Get();
        public ActionResult<PetType> GetById(int x);
        public ActionResult<PetType> Post([FromBody] PetType value);
        public ActionResult<PetType> Put(int id, [FromBody] PetType value);
        public ActionResult<PetType> Delete(int id);
        public ActionResult<IEnumerable<PetType>> GetFiltered(string name);
    }
}
