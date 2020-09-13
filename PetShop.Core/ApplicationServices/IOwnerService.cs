using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationServices
{
    public interface IOwnerService
    {

        public List<Owner> ReadOwners();
        public Owner DeleteOwner(Owner o);
        public Owner UpdateOwner(Owner o);
        public Owner CreateOwner(Owner o);
        public Owner GetSpecificOwner(int id);
        public Owner getOwner(Pet p);
        public List<Owner> SearchForOwner(string querry);
    }
}
