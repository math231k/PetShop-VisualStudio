using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class FakeDB
    {
        public static List<Pet> Pets { get; set; }
        public static List<Owner> Owners { get; set; }
        private static int petId = 1;
        private static int ownerId = 1;
        private static FakeDB fakeDBInstance;
        private FakeDB()
        {
            initData();
        }

        public Pet AddPetToDatabase(Pet p)
        {
            p.Id = petId++;
            Pets.Add(p);
            return p;
        }
        public Owner AddOwnerToDatabase(Owner o)
        {
            o.Id = ownerId++;
            Owners.Add(o);
            return o;
        }

        private static void initData()
        {
            Pets = new List<Pet>();
            Owners = new List<Owner>();
            Pets.Add(new Pet
            {
                Id = petId++,
                Name = "Leika",
                Color = "White & Black",
                OwnerId = 1,
                BirthDate = DateTime.Parse("jun 8, 1954"),
                SoldDate = DateTime.Parse("nov 3, 1957"),
                Type = Pet.Types.dog,
                price = 9000
            }
            );

            Pets.Add(new Pet
            {
                Id = petId++,
                Name = "Vasha",
                Color = "White",
                OwnerId = 2,
                BirthDate = DateTime.Parse("jun 8, 1954"),
                SoldDate = DateTime.Parse("nov 3, 1957"),
                Type = Pet.Types.dog,
                price = 1500
            }
            );

            Pets.Add(new Pet
            {
                Id = petId++,
                Name = "Strelka",
                Color = "White",
                OwnerId = 1,
                BirthDate = DateTime.Parse("jun 8, 1954"),
                SoldDate = DateTime.Parse("nov 3, 1957"),
                Type = Pet.Types.dog,
                price = 6000
            }
            );

            Pets.Add(new Pet
            {
                Id = petId++,
                Name = "Belka",
                Color = "White",
                OwnerId = 2,
                BirthDate = DateTime.Parse("jun 8, 1954"),
                SoldDate = DateTime.Parse("nov 3, 1957"),
                Type = Pet.Types.dog,
                price = 9000
            }
            );

            Pets.Add(new Pet
            {
                Id = petId++,
                Name = "Veterok",
                Color = "White",
                OwnerId = 1,
                BirthDate = DateTime.Parse("jun 8, 1954"),
                SoldDate = DateTime.Parse("nov 3, 1957"),
                Type = Pet.Types.dog,
                price = 5700
            }
            );

            Pets.Add(new Pet
            {
                Id = petId++,
                Name = "Pushinka",
                Color = "White",
                OwnerId = 2,
                BirthDate = DateTime.Parse("jun 8, 1954"),
                SoldDate = DateTime.Parse("nov 3, 1957"),
                Type = Pet.Types.dog,
                price = 12000
            });

            Owners.Add(new Owner
            {
                Id = ownerId++,
                FirstName = "Yuri",
                LastName = "Gagarin",
                Address = "Vostok 1",
                Email = "Gagarin@ruMail.su",
                PhoneNumber = "56 32 11 67"
                
            }
            );

            Owners.Add(new Owner
            {
                Id = ownerId++,
                FirstName = "Nikita",
                LastName = "Krustyev",
                Address = "Kremlin 18",
                Email = "Krustyev@ruMail.su",
                PhoneNumber = "26 34 71 62"

            }
            );
        }

        public static FakeDB GetInstance()
        {
            if (fakeDBInstance == null)
            {
                fakeDBInstance = new FakeDB();
                return fakeDBInstance;
            }
            return fakeDBInstance;
        }
    }
}
