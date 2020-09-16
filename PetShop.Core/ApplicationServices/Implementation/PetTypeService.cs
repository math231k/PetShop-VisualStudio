using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationServices.Implementation
{
    public class PetTypeService : IPetTypeService
    {
        private IPetTypeRepository _petTypeRepository;
        public PetTypeService(IPetTypeRepository petTypeRepository)
        {
            _petTypeRepository = petTypeRepository;
        }
        public PetType CreatePetType(PetType pt)
        {
            return _petTypeRepository.CreatePetType(pt);
        }

        public PetType DeletePetType(PetType pt)
        {
            return _petTypeRepository.DeletePetType(pt);
        }

        public PetType GetPetTypeById(int id)
        {
            foreach (PetType pett in _petTypeRepository.ReadPetType())
            {
                if (pett.Id == id)
                {
                    return pett;
                }
            }
            return null;
        }

        public List<PetType> ReadPetTypes()
        {
            return _petTypeRepository.ReadPetType();
        }

        public List<PetType> SearchForPetType(string querry)
        {
            List<PetType> results = new List<PetType>();
            foreach (PetType pett in _petTypeRepository.ReadPetType())
            {
                if (pett.TypeName.Contains(querry))
                {
                    results.Add(pett);
                }
            }
            return results;
        }

        public PetType UpdatePetType(PetType pt)
        {
            return _petTypeRepository.UpdatePetType(pt);
        }
    }
}
