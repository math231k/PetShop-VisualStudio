using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class PetRepository: IPetRepository
    {
        public FakeDB database = FakeDB.GetInstance();

        /// <summary>
        /// Adds a new pet to the database
        /// </summary>
        /// <param name="p">The pet to be added</param>
        /// <returns>The added pet</returns>
        public Pet CreatePet(Pet p)
        {
            database.AddPetToDatabase(p);
            return p;
        }

        /// <summary>
        /// Retrives all pets from the database
        /// </summary>
        /// <returns>All pets from the database</returns>
        public List<Pet> ReadPets()
        {
            return FakeDB.Pets;
        }

        /// <summary>
        /// Removes a pet from the database
        /// </summary>
        /// <param name="p">The pet to be removed</param>
        /// <returns>The removed pet</returns>
        public Pet RemovePet(Pet p)
        {
            foreach (Pet pet in FakeDB.Pets)
            {
                if (pet.Id == p.Id)
                {
                    FakeDB.Pets.Remove(pet);
                    return pet;
                }
            }
            return null;
        }

        /// <summary>
        /// Updates data related to a pet
        /// </summary>
        /// <param name="p">The replacement pet</param>
        /// <returns>The updated pet</returns>
        public Pet UpdatePet(Pet p)
        {
            foreach (Pet pet in FakeDB.Pets)
            {
                if (pet.Id == p.Id)
                {
                    pet.Name = p.Name;
                    pet.OwnerId = p.OwnerId;
                    pet.price = p.price;
                    pet.SoldDate = p.SoldDate;
                    pet.Type = p.Type;
                    pet.Color = p.Color;
                    pet.BirthDate = p.BirthDate;
                    return pet;
                }
            }
            return null;
        }

    }
}
