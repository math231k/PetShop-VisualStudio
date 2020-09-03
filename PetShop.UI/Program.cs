using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.ApplicationServices;
using PetShop.Core.ApplicationServices.Implementation;
using PetShop.Core.DomainServices;
using PetShop.Infrastructure.Data;
using System;

namespace PetShop.UI
{
    class Program
    {
        public static IServiceCollection services { get; set; }
        static void Main(string[] args)
        {
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            IPetRepository _PetRepository = new PetRepository();
            IPetService _PetService = new PetService(_PetRepository);
            IOwnerRepository _OwnerRepository = new OwnerRepository();
            IOwnerService _OwnerService = new OwnerService(_OwnerRepository);
            Printer printer = new Printer(_PetService, _OwnerService);
        }
    }
}
