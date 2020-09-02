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
        public Owner CreateOwner(Owner o)
        {
            throw new NotImplementedException();
        }

        public Owner DeleteOwner(Owner o)
        {
            throw new NotImplementedException();
        }

        public Owner getOwner(Pet p)
        {
            return _OwnerRepository.GetOwner(p);
        }

        public List<Owner> ReadOwners()
        {
            throw new NotImplementedException();
        }

        public Owner UpdateOwner(Owner o)
        {
            throw new NotImplementedException();
        }
    }
}
