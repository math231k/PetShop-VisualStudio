using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PetShop.Infrastructure.MSSQL.Data
{
    public class PetShopAppContext: DbContext
    {
        public DbSet<Pet> pets { get; set; }
        public DbSet<Owner> owners { get; set; }

        public PetShopAppContext(DbContextOptions<PetShopAppContext> opt): base(opt) 
        { 

        }

    }
}
