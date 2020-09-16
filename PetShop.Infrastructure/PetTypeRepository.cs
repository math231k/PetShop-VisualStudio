using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.DomainServices;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Data
{
    public class PetTypeRepository : IPetTypeRepository
    {
        FakeDB Database = FakeDB.GetInstance();
        public PetType CreatePetType(PetType pt)
        {
            return Database.AddPetTypeToDatabase(pt);
        }

        public PetType DeletePetType(PetType pt)
        {
            foreach (PetType pett in FakeDB.PetTypes)
            {
                if (pett.Id == pt.Id)
                {
                    FakeDB.PetTypes.Remove(pett);
                    return pt;
                }
            }
            return null;
        }

        public List<PetType> ReadPetType()
        {
            return FakeDB.PetTypes;
        }

        public PetType UpdatePetType(PetType pt)
        {
            foreach (PetType pett in FakeDB.PetTypes)
            {
                if (pett.Id == pt.Id)
                {
                    pett.TypeName = pt.TypeName;
                }
            }
            return null;
        }
    }
}
