using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainServices
{
    public interface IOwnerRepository
    {
        public List<Owner> ReadOwners();
        public Owner DeleteOwner(Owner o);
        public Owner UpdateOwner(Owner o);
        public Owner CreateOwner(Owner o);
    }
}
