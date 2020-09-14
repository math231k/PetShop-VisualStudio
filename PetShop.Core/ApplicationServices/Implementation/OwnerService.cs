using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationServices.Implementation
{
    
    public class OwnerService : IOwnerService
    {
        public IOwnerRepository _OwnerRepository { get; set; }

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _OwnerRepository = ownerRepository;
        }

        /// <summary>
        /// Adds an owner to the database
        /// </summary>
        /// <param name="o">the previous owner to be added</param>
        /// <returns>the previous owner that was added</returns>
        public Owner CreateOwner(Owner o)
        {
            return _OwnerRepository.CreateOwner(o);
        }

        /// <summary>
        /// Removes an owner from the database
        /// </summary>
        /// <param name="o">the previous owner to be removed</param>
        /// <returns>the previous owner that was deleted</returns>
        public Owner DeleteOwner(Owner o)
        {
            return _OwnerRepository.DeleteOwner(o);
        }

        /// <summary>
        /// Retrives a single previous owner from the database based on the Pets ownerId
        /// </summary>
        /// <param name="p">The pet used to find the previous owner</param>
        /// <returns>The previous owner connected to the pet</returns>
        public Owner getOwner(Pet p)
        {
                return _OwnerRepository.GetOwner(p);
        }

        /// <summary>
        /// Returns all previous owners from the database
        /// </summary>
        /// <returns></returns>
        public List<Owner> ReadOwners()
        {
            return _OwnerRepository.ReadOwners();
        }

        /// <summary>
        /// Updates a previous owner
        /// </summary>
        /// <param name="o">The owner to replace the previous</param>
        /// <returns>The updated previous owner</returns>
        public Owner UpdateOwner(Owner o)
        {
            return _OwnerRepository.UpdateOwner(o);
        }

        public List<Owner> SearchForOwner(string querry)
        {
            List<Owner> filteredOwnerList = new List<Owner>();
            foreach (Owner o in _OwnerRepository.ReadOwners())
            {
                if (o.FirstName.Contains(querry.ToLower()))
                {
                    filteredOwnerList.Add(o);
                }
            }
            return filteredOwnerList;
        }

        public Owner GetSpecificOwner(int id)
        
        {
            foreach (Owner o in _OwnerRepository.ReadOwners())
            {
                if (o.Id == id)
                {
                    return o;
                }
            }
            return null;
        }
    }
}
