using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Core.ApplicationServices.Implementation
{
    public class PetService : IPetService
    {
        public IPetRepository _PetRepository { get; set; }

        public PetService(IPetRepository petRepository)
        {
            _PetRepository = petRepository;
        }
        public List<Pet> GetPets()
        {
            return _PetRepository.ReadPets();
        }

        public Pet RemovePet(Pet p)
        {
            return _PetRepository.RemovePet(p);
        }

        public Pet UpdateDetails(Pet p)
        {
            return _PetRepository.UpdatePet(p);
        }

        public Pet CreatePet(Pet p)
        {
            return _PetRepository.CreatePet(p);
        }

        public List<Pet> GetAllTypes(Enum type)
        {
            List<Pet> typePets = new List<Pet>();
            foreach(Pet p in _PetRepository.ReadPets())
            {
                if (p.Type == type)
                {
                    typePets.Add(p);
                }
            }
            return typePets;
        }

        public List<Pet> GetCheepestPets()
        {
            List<Pet> fiveCheepest = new List<Pet>();
            for (int i = 0; i <= 4; i++)
            {
                fiveCheepest.Add(GetPriceSorted().ElementAt(i));
            }
            return fiveCheepest;
        }

        public List<Pet> GetPriceSorted()
        {
            List<Pet> sortedList = new List<Pet>();
            sortedList = _PetRepository.ReadPets();

            sortedList.Sort(delegate (Pet x, Pet y) {
                return x.price.CompareTo(y.price);
            });
            return sortedList;
            
        }
        public List<Pet> SearchForPet(String querry)
        {
            List<Pet> results = new List<Pet>();
            foreach (Pet p in _PetRepository.ReadPets())
            {
                if (p.Name.Contains(querry))
                {
                    results.Add(p);
                }
            }
            return results;
        }
    }
}
