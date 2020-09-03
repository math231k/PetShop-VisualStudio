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



    public Owner CreateOwner(Owner o)
    {
        return database.AddOwnerToDatabase(o);
    }

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

        public List<Owner> ReadOwners()
        {
            return FakeDB.Owners;
        }

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

