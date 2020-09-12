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

        public PetService(IPetRepository petSQLRepository)
        {
            _PetRepository = petSQLRepository;
        }
        /// <summary>
        /// Adds a new pet to the database
        /// </summary>
        /// <param name="p">The pet to be added</param>
        /// <returns>The added pet</returns>
        public List<Pet> GetPets()
        {
            return _PetRepository.ReadPets();
        }
        /// <summary>
        /// Removes a pet from the database
        /// </summary>
        /// <param name="p">The pet to be removed</param>
        /// <returns>The removed pet</returns>
        public Pet RemovePet(Pet p)
        {
            return _PetRepository.RemovePet(p);
        }
        /// <summary>
        /// Updates data related to a pet
        /// </summary>
        /// <param name="p">The replacement pet</param>
        /// <returns>The updated pet</returns>
        public Pet UpdateDetails(Pet p)
        {
            return _PetRepository.UpdatePet(p);
        }
        /// <summary>
        /// Retrives all pets from the database
        /// </summary>
        /// <returns>All pets from the database</returns>
        public Pet CreatePet(Pet p)
        {
            return _PetRepository.CreatePet(p);
        }
        /// <summary>
        /// Returns a List with all the pets of a given type
        /// </summary>
        /// <param name="type">The type searched for</param>
        /// <returns>List with all pets of type</returns>
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
        /// <summary>
        /// Retrieves the five cheapest pets in the database
        /// </summary>
        /// <returns>A list with five lowest priced pets sorted after price</returns>
        public List<Pet> GetCheepestPets()
        {
            List<Pet> fiveCheepest = new List<Pet>();
            for (int i = 0; i <= 4; i++)
            {
                fiveCheepest.Add(GetPriceSorted().ElementAt(i));
            }
            return fiveCheepest;
        }
        /// <summary>
        /// Sorts all pets in the database after price
        /// </summary>
        /// <returns>A list of pets sorted after price</returns>
        public List<Pet> GetPriceSorted()
        {
            List<Pet> sortedList = new List<Pet>();
            sortedList = _PetRepository.ReadPets();

            sortedList.Sort(delegate (Pet x, Pet y) {
                return x.price.CompareTo(y.price);
            });
            return sortedList;
            
        }
        /// <summary>
        /// Searches the database for a specific pet based on name
        /// </summary>
        /// <param name="querry">The name of the pet(s) you are searching for</param>
        /// <returns>A list of pets matching the querry</returns>
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
        /// <summary>
        /// Returns a pet based on the id
        /// </summary>
        /// <param name="id">the id of the pet you want to find</param>
        /// <returns>the pet found</returns>
        public Pet GetSpecificPet(int id)
        {
            return _PetRepository.GetSpecificPet(id);
        }
    }
}
