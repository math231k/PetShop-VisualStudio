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
        private static int id = 1;
        private static FakeDB fakeDBInstance;
        private FakeDB()
        {
            initData();
        }

        public Pet AddPetToDatabase(Pet p)
        {
            p.Id = id++;
            Pets.Add(p);
            return p;
        }

        private static void initData()
        {
            Pets = new List<Pet>();
            
            Pets.Add(new Pet
            {
                Id = id++,
                Name = "Leika",
                Color = "White & Black",
                PreviousOwner = "CCCP",
                BirthDate = DateTime.Parse("jun 8, 1954"),
                SoldDate = DateTime.Parse("nov 3, 1957"),
                Type = Pet.Types.dog,
                price = 9000
            }
            );

            Pets.Add(new Pet
            {
                Id = id++,
                Name = "Vasha",
                Color = "White",
                PreviousOwner = "CCCP",
                BirthDate = DateTime.Parse("jun 8, 1954"),
                SoldDate = DateTime.Parse("nov 3, 1957"),
                Type = Pet.Types.dog,
                price = 1500
            }
            );

            Pets.Add(new Pet
            {
                Id = id++,
                Name = "Strelka",
                Color = "White",
                PreviousOwner = "CCCP",
                BirthDate = DateTime.Parse("jun 8, 1954"),
                SoldDate = DateTime.Parse("nov 3, 1957"),
                Type = Pet.Types.dog,
                price = 6000
            }
            );

            Pets.Add(new Pet
            {
                Id = id++,
                Name = "Belka",
                Color = "White",
                PreviousOwner = "CCCP",
                BirthDate = DateTime.Parse("jun 8, 1954"),
                SoldDate = DateTime.Parse("nov 3, 1957"),
                Type = Pet.Types.dog,
                price = 9000
            }
            );

            Pets.Add(new Pet
            {
                Id = id++,
                Name = "Veterok",
                Color = "White",
                PreviousOwner = "CCCP",
                BirthDate = DateTime.Parse("jun 8, 1954"),
                SoldDate = DateTime.Parse("nov 3, 1957"),
                Type = Pet.Types.dog,
                price = 5700
            }
            );

            Pets.Add(new Pet
            {
                Id = id++,
                Name = "Pushinka",
                Color = "White",
                PreviousOwner = "CCCP",
                BirthDate = DateTime.Parse("jun 8, 1954"),
                SoldDate = DateTime.Parse("nov 3, 1957"),
                Type = Pet.Types.dog,
                price = 12000
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
