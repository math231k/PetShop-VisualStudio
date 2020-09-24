using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Infrastructure.MSSQL.Data
{
    public class PetSQLRepository : IPetRepository
    {
        readonly PetShopAppContext _ctx;
        public PetSQLRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }
        /// <summary>
        /// Adds a pet to the database
        /// </summary>
        /// <param name="p">The pet you want to add to the database</param>
        /// <returns>The pet that was created</returns>
        public Pet CreatePet(Pet p)
        {
            var petCreated = _ctx.Pets.Add(p);
            _ctx.SaveChanges();
            return petCreated.Entity;
        }

        /// <summary>
        /// Read a specific pet by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Pet GetSpecificPet(int id)
        {
            return _ctx.Pets.FirstOrDefault(p => p.Id == id);
        }
        /// <summary>
        /// Reads all pets in the database
        /// </summary>
        /// <returns>all pets in the database as a List<Pet></returns>
        public List<Pet> ReadPets()
        {
            return _ctx.Pets.ToList();
        }
        /// <summary>
        /// Removes a pet from the database
        /// </summary>
        /// <param name="p">the pet you want to remove</param>
        /// <returns>the removed pet</returns>
        public Pet RemovePet(Pet p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the data of a pet in the database
        /// </summary>
        /// <param name="p">The pet you want to update</param>
        /// <returns>The pet updated</returns>
        public Pet UpdatePet(Pet p)
        {
            var updatedPet = _ctx.Pets.Update(p);
            _ctx.SaveChanges();
            return updatedPet.Entity;
        }
    }
}
