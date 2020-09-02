using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data
{ 
    public class OwnerRepository : IOwnerRepository
    {
        private FakeDB database = FakeDB.GetInstance();



        public Owner CreateOwner(Owner o)
    {
        throw new NotImplementedException();
    }

    public Owner DeleteOwner(Owner o)
    {
        throw new NotImplementedException();
    }

    public Owner GetOwner(Pet p)
    {
            foreach (Owner o in FakeDB.owners)
            {
                if(p.OwnerId == o.Id)
                {
                    return o;
                }
            }
            return null;
    }

    public Owner UpdateOwner(Owner o)
    {
        throw new NotImplementedException();
    }
}
}

