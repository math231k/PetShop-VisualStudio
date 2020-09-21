using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationServices
{
    public interface IPetService
    {
        /// <summary>
        /// Method Which returns all elements within the database database
        /// </summary>
        /// <returns>A List<Pet> build from data locatet in my fake database</returns>
        public List<Pet> GetPets();
        /// <summary>
        /// Removed an element within the fake database
        /// </summary>
        /// <param name="p">The element you want to delete</param>
        /// <returns>The pet that was deleted</returns>
        public Pet RemovePet(Pet p);
        /// <summary>
        /// Updates the data stored in a pet
        /// </summary>
        /// <param name="p">An updated version of the pet object</param>
        /// <returns>The pet that was updated</returns>
        public Pet UpdateDetails(Pet p);
        /// <summary>
        /// Created a new entry in the database
        /// </summary>
        /// <param name="p">The pet you want stored in the database</param>
        /// <returns>the pet that was created</returns>
        public Pet CreatePet(Pet p);
        /// <summary>
        /// Gets all pets of a certain species
        /// </summary>
        /// <param name="type">The species of pet you would like to see</param>
        /// <returns>A list<Pet> of all elements beloning to a certain species</returns>
        public List<Pet> GetAllTypes(int typeId);
        /// <summary>
        /// Return the five cheepest pets stored in the database
        /// </summary>
        /// <returns>A List<Pet> of the five cheepest pets</returns>
        public List<Pet> GetCheepestPets();
        /// <summary>
        /// Sorts the list of pets according to price ascending
        /// </summary>
        /// <returns>List<Pet> sorted by price</returns>
        public List<Pet> GetPriceSorted();
        /// <summary>
        /// Returns a list of pets based on a search querry made by the user
        /// </summary>
        /// <param name="querry">The name that is searched for</param>
        /// <returns>a List<Pet> where the names match the querry</returns>
        public List<Pet> SearchForPet(String querry);
        /// <summary>
        /// Returns a pet based on the id
        /// </summary>
        /// <param name="id">the id of the pet you want to find</param>
        /// <returns>the pet found</returns>
        public Pet GetSpecificPet(int id);
    }
}
