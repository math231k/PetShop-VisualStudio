using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainServices
{
    public interface IPetRepository
    {
        public List<Pet> ReadPets();
        public Pet RemovePet(Pet p);
        public Pet CreatePet(Pet p);
        public Pet UpdatePet(Pet p);

    }
}
