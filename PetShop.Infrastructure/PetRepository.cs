using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class PetRepository: IPetRepository
    {
        public FakeDB fakeDB = FakeDB.GetInstance();

        public Pet CreatePet(Pet p)
        {
            fakeDB.AddPetToDatabase(p);
            return p;
        }

        public List<Pet> ReadPets()
        {
            return FakeDB.Pets;
        }

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
