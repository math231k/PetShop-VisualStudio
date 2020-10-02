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

        public void initData()
        {
            Pets.Add(new Pet
            {
                Name = "Leika",
                Color = "White & Black",
                OwnerId = 1,
                BirthDate = DateTime.Parse("jun 8, 1954"),
                SoldDate = DateTime.Parse("nov 3, 1957"),
                TypeId = 1,
                price = 9000
            }
            );

            Pets.Add(new Pet
            {
                Name = "Vasha",
                Color = "White",
                OwnerId = 2,
                BirthDate = DateTime.Parse("jun 8, 1954"),
                SoldDate = DateTime.Parse("nov 3, 1957"),
                TypeId = 2,
                price = 1500
            }
            );

            Pets.Add(new Pet
            {
                Name = "Strelka",
                Color = "White",
                OwnerId = 1,
                BirthDate = DateTime.Parse("jun 8, 1954"),
                SoldDate = DateTime.Parse("nov 3, 1957"),
                TypeId = 1,
                price = 6000
            }
            );

            Pets.Add(new Pet
            {
                Name = "Belka",
                Color = "White",
                OwnerId = 2,
                BirthDate = DateTime.Parse("jun 8, 1954"),
                SoldDate = DateTime.Parse("nov 3, 1957"),
                TypeId = 2,
                price = 9000
            }
            );

            Pets.Add(new Pet
            {
                Name = "Veterok",
                Color = "White",
                OwnerId = 1,
                BirthDate = DateTime.Parse("jun 8, 1954"),
                SoldDate = DateTime.Parse("nov 3, 1957"),
                TypeId = 1,
                price = 5700
            }
            );

            Pets.Add(new Pet
            {
                Name = "Pushinka",
                Color = "White",
                OwnerId = 2,
                BirthDate = DateTime.Parse("jun 8, 1954"),
                SoldDate = DateTime.Parse("nov 3, 1957"),
                TypeId = 2,
                price = 12000
            });

            Owners.Add(new Owner
            {
                FirstName = "Yuri",
                LastName = "Gagarin",
                Address = "Vostok 1",
                Email = "Gagarin@ruMail.su",
                PhoneNumber = "56 32 11 67"

            }
            );

            Owners.Add(new Owner
            {
                FirstName = "Nikita",
                LastName = "Krustyev",
                Address = "Kremlin 18",
                Email = "Krustyev@ruMail.su",
                PhoneNumber = "26 34 71 62"

            }
            );

            PetTypes.Add(new PetType
            {
                TypeName = "dog"
            });

            PetTypes.Add(new PetType
            {
                TypeName = "cat"
            });

            PetTypes.Add(new PetType
            {
                TypeName = "hamster"
            });

            PetTypes.Add(new PetType
            {
                TypeName = "bird"
            });

            SaveChanges();
        }
    }
}
