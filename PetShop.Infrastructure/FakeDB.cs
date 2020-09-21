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
        public static List<PetType> PetTypes { get; set; }

        private static int petId = 1;
        private static int ownerId = 1;
        private static int PetTypeId = 1;
        private static FakeDB fakeDBInstance;
        private FakeDB()
        {
            //initData();
        }

        /// <summary>
        /// Adds a pet to the pets list and also gives the parameter p an id
        /// </summary>
        /// <param name="p">The pet to be added to the list</param>
        /// <returns>the pet that was added</returns>
        public Pet AddPetToDatabase(Pet p)
        {
            p.Id = petId++;
            Pets.Add(p);
            return p;
        }

        /// <summary>
        /// Adds a previous owner to the owners list and also gives the parameter o an id
        /// </summary>
        /// <param name="p">The previous owner to be added to the list</param>
        /// <returns>the previous owner that was added</returns>
        public Owner AddOwnerToDatabase(Owner o)
        {
            o.Id = ownerId++;
            Owners.Add(o);
            return o;
        }

        public PetType AddPetTypeToDatabase(PetType pt)
        {
            pt.Id = PetTypeId++;
            PetTypes.Add(pt);
            return pt;
        }

        /// <summary>
        /// Initializes the data on the two lists pets and owners
        /// </summary>
        public static void initData()
        {
            Pets = new List<Pet>();
            Owners = new List<Owner>();
            PetTypes = new List<PetType>();
            Pets.Add(new Pet
            {
                Id = petId++,
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
                Id = petId++,
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
                Id = petId++,
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
                Id = petId++,
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
                Id = petId++,
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
                Id = petId++,
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

            PetTypes.Add(new PetType
            {
                Id = PetTypeId++,
                TypeName = "dog"
            });

            PetTypes.Add(new PetType
            {
                Id = PetTypeId++,
                TypeName = "cat"
            });

            PetTypes.Add(new PetType
            {
                Id = PetTypeId++,
                TypeName = "hamster"
            });

            PetTypes.Add(new PetType
            {
                Id = PetTypeId++,
                TypeName = "bird"
            });
        }

        /// <summary>
        /// retrieves an instance of this class
        /// </summary>
        /// <returns>fakeDBInstance</returns>
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
