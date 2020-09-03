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
        static void Main(string[] args)
        {
            var service = new ServiceCollection();
            service.AddScoped<IPetRepository, PetRepository>();
            service.AddScoped<IPetService, PetService>();

            service.AddScoped<IOwnerRepository, OwnerRepository>();
            service.AddScoped<IOwnerService, OwnerService>();

            var serviceProvider = service.BuildServiceProvider();
            var petService = serviceProvider.GetRequiredService<IPetService>();
            var ownerService = serviceProvider.GetRequiredService<IOwnerService>();

            new Printer(petService, ownerService);
        }
    }
}
