using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainServices
{
    public interface IPetTypeRepository
    {
        public PetType CreatePetType(PetType pt);
        public List<PetType> ReadPetType();
        public PetType UpdatePetType(PetType pt);
        public PetType DeletePetType(PetType pt);
    }
}
