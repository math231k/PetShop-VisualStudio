using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShot.WebAPI.Controllers
{
    interface IOwnerController
    {
        public IEnumerable<Owner> Get();
        public Owner Get(int x);
        public ActionResult<Owner> Post([FromBody] Owner value);
        public ActionResult<Owner> Put(int id, [FromBody] Owner value);
        public void Delete(int id, [FromBody] Owner value);
        public IEnumerable<Pet> GetFiltered();
    }
}
