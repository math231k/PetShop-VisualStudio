﻿using PetShop.Core.ApplicationServices;
using PetShop.Core.ApplicationServices.Implementation;
using PetShop.Core.DomainServices;
using PetShop.Infrastructure.Data;
using System;

namespace PetShop.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IPetRepository _PetRepository = new PetRepository();
            IPetService _PetService = new PetService(_PetRepository);
            IOwnerRepository _OwnerRepository = new OwnerRepository();
            IOwnerService _OwnerService = new OwnerService(_OwnerRepository);
            Printer printer = new Printer(_PetService, _OwnerService);
        }
    }
}