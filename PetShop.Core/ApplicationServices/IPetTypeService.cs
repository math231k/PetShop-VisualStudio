using System;
using PetShop.Core.Entities;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationServices
{
    public interface IPetTypeService
    {
        public List<PetType> ReadPetTypes();
        public PetType GetPetTypeById(int id);
        public PetType DeletePetType(PetType pt);
        public PetType UpdatePetType(PetType pt);
        public PetType CreatePetType(PetType pt);
        public List<PetType> SearchForPetType(string querry);
    }
}
