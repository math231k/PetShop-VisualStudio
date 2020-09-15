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
        public ActionResult<IEnumerable<Owner>> Get();
        public ActionResult<Owner> GetById(int id);
        public ActionResult<Owner> Post([FromBody] Owner value);
        public ActionResult<Owner> Put(int id, [FromBody] Owner value);
        public ActionResult<Owner> Delete(int id);
        public ActionResult<IEnumerable<Owner>> GetFiltered(string name);
    }
}
