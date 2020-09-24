using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PetShop.Infrastructure.MSSQL.Data
{
    public class PetShopAppContext : DbContext
    {
        public PetShopAppContext(DbContextOptions<PetShopAppContext> opt)
            : base(opt){ }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PetType> PetTypes{ get; set;}

        
    }
}
