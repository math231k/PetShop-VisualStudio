using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShot.WebAPI.Controllers
{
    interface IPetController
    {
        public ActionResult<IEnumerable<Pet>> Get();
        public ActionResult<Pet> Get(int x);
        public ActionResult<Pet> Post([FromBody] Pet value);
        public ActionResult<Pet> Put(int id, [FromBody] Pet value);
        public ActionResult<Pet> Delete(int id, [FromBody] Pet value);
        public ActionResult<IEnumerable<Pet>> GetFiltered(string name);


    }
}
