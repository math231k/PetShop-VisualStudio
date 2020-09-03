using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.Data
{ 
    public class OwnerRepository : IOwnerRepository
    {
        private FakeDB database = FakeDB.GetInstance();

        /// <summary>
        /// Adds an owner to the database
        /// </summary>
        /// <param name="o">the previous owner to be added</param>
        /// <returns>the previous owner that was added</returns>
        public Owner CreateOwner(Owner o)
    {
        return database.AddOwnerToDatabase(o);
    }

        /// <summary>
        /// Removes an owner from the database
        /// </summary>
        /// <param name="o">the previous owner to be removed</param>
        /// <returns>the previous owner that was deleted</returns>
        public Owner DeleteOwner(Owner o)
    {
            foreach (Owner owner in FakeDB.Owners)
            {
                if (owner.Id == o.Id)
                {
                    FakeDB.Owners.Remove(owner);
                    return o;
                }
            }
            return null;
        }

        /// <summary>
        /// Retrives a single previous owner from the database based on the Pets ownerId
        /// </summary>
        /// <param name="p">The pet used to find the previous owner</param>
        /// <returns>The previous owner connected to the pet</returns>
        public Owner GetOwner(Pet p)
    {
            foreach (Owner o in FakeDB.Owners)
            {
                if(p.OwnerId == o.Id)
                {
                    return o;
                }
            }
            return null;
    }

        /// <summary>
        /// Returns all previous owners from the database
        /// </summary>
        /// <returns></returns>
        public List<Owner> ReadOwners()
        {
            return FakeDB.Owners;
        }

        /// <summary>
        /// Updates a previous owner
        /// </summary>
        /// <param name="o">The owner to replace the previous</param>
        /// <returns>The updated previous owner</returns>
        public Owner UpdateOwner(Owner o)
    {
        foreach(Owner owner in FakeDB.Owners)
            {
                if (owner.Id == o.Id)
                {
                    owner.FirstName = o.FirstName;
                    owner.LastName = o.LastName;
                    owner.Address = o.Address;
                    owner.Email = o.Email;
                    owner.PhoneNumber = o.PhoneNumber;

                    return owner;
                }
            }
            return null;
    }
}
}

