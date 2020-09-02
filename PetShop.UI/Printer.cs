using PetShop.Core.ApplicationServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace PetShop.UI
{
    /// <summary>
    /// The class responsible for handeling UI. Inititalizes a welcome message and loads a kind of ListView (petsList).
    /// </summary>
    class Printer
    {
        private IPetService _PetService { get; set; }
        private IOwnerService _OwnerService { get; set; }
        private List<Pet> petsList { get; set; }

        /// <summary>
        /// Constructer used for creating a new instance of this class
        /// It initializes the visual list and calls the navigate method afterwards
        /// </summary>
        /// <param name="petService">The implementation of the IPetService interface</param>
        public Printer(IPetService petService, IOwnerService ownerService)
        {
            _PetService = petService;
            _OwnerService = ownerService;
            FetchPets();
            Navigate();
        }
        /// <summary>
        /// Adds all Database elements to a list for quick access for the methods which needs a Pet object from the database
        /// It also prints a little welcome and all the elements in the database
        /// </summary>
        public void FetchPets()
        {
            Console.Clear();
            Console.WriteLine(" ____________________ ");
            Console.WriteLine("|                    |");
            Console.WriteLine("|    The Pet Shop    |");
            Console.WriteLine("|____________________|");
            Console.WriteLine("");
            Console.WriteLine("");
            foreach (Pet p in _PetService.GetPets())
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine();
            petsList = _PetService.GetPets();
            Navigate();
        }
        /// <summary>
        /// Handles all navigation inputs from the user by using a switch-case.
        /// </summary>
        public void Navigate()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Remove an animal from the database");
            Console.WriteLine("2. Create a new entry");
            Console.WriteLine("3. Update an entry");
            Console.WriteLine("4. Sort after price");
            Console.WriteLine("5. Get the five cheepest");
            Console.WriteLine("6. Search for a pet");
            Console.WriteLine("0. Exit the application");
            int outcome = 0;
            try
            {
                outcome = int.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Please enter something, press enter to try again...");
                Console.ReadLine();
                FetchPets();
                Navigate();
                
            }
            catch (FormatException)
            {
                Console.WriteLine("You must enter a number, press enter to try again...");
                Console.ReadLine();
                FetchPets();
                Navigate();
                
            }
            

            switch (outcome)
            {
                case 1:
                    RemovePet();
                    FetchPets();
                    Navigate();
                    break;
                case 2:
                    CreatePet();
                    FetchPets();
                    Navigate();
                    break;
                case 3:
                    UpdatePet();
                    FetchPets();
                    Navigate();
                    break;
                case 4:
                    SortAfterPrice();
                    FetchPets();
                    Navigate();
                    break;
                case 5:
                    GetFiveCheep();
                    break;
                case 6:
                    SearchForPet();
                    break;
                case 7:
                    PrintPetDetails();
                    FetchPets();
                    Navigate();
                    break;
                default:
                    System.Environment.Exit(1);
                    break;
            }
        }
        /// <summary>
        /// Removes a pet from the database
        /// </summary>
        /// <returns>The Pet that was removed</returns>
        public Pet RemovePet()
        {
            Console.WriteLine("What Pet do you wish to remove from the list?");
            int removalIndex = int.Parse(Console.ReadLine());
            foreach (Pet p in petsList)
            {
                if (p.Id == removalIndex)
                {
                    Console.WriteLine(p.Name + " Was Removed. Press Enter...");
                    Console.ReadLine();
                    return _PetService.RemovePet(p);
                }
            }
            Console.WriteLine("Pet not found, press enter to continue...");
            Console.ReadLine();
            return null;
        }
        /// <summary>
        /// Creates a pet and sends it to the database
        /// </summary>
        /// <returns>the pet that was created</returns>
        public Pet CreatePet()
        {
            return _PetService.CreatePet(GeneratePet());
        }
        /// <summary>
        /// Updates the data of a pet
        /// </summary>
        /// <returns>the pet that has been updated</returns>
        public Pet UpdatePet()
        {

            Console.WriteLine("Please Select an animal to update");
            int updateIndex = int.Parse(Console.ReadLine());
            Pet updatePet = GeneratePet();
            updatePet.Id = updateIndex;
            return _PetService.UpdateDetails(updatePet);
        }
        /// <summary>
        /// Sorts the list according to price in descending order
        /// </summary>
        public void SortAfterPrice()
        {
            _PetService.GetPriceSorted();
        }
        /// <summary>
        /// shows the 5 cheepest pets in the database
        /// </summary>
        public void GetFiveCheep()
        {
            Console.Clear();
            foreach(Pet p in _PetService.GetCheepestPets())
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("");
            Console.WriteLine("Press enter to see all animals");
            Console.ReadLine();
            FetchPets();
            Navigate();

        }
        /// <summary>
        /// Search for a pet by its name in the database
        /// </summary>
        public void SearchForPet()
        {
            Console.Clear();
            Console.WriteLine("Please Write the name of the animal");
            Console.WriteLine();
            string querry = Console.ReadLine();

            List<Pet> results = _PetService.SearchForPet(querry);

            if (results.Count > 0)
            {
                foreach (Pet p in results)
                {
                    Console.WriteLine(p.ToString());
                }
                Console.WriteLine();
                Console.WriteLine("Press Enter to return");
                Console.ReadLine();
                FetchPets();
            }
            else
            {
                Console.WriteLine("Querry returned 0 results");
                Console.WriteLine();
                Console.WriteLine("Press Enter to return...");
                Console.ReadLine();
                FetchPets();
            }
        }
        /// <summary>
        /// Method Creating a pet via user input
        /// </summary>
        /// <returns>The pet created based on the users input</returns>
        public Pet GeneratePet()
        {
            Console.WriteLine("Enter a name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Previous Owner");
            int prevOwner = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a BirthDate");
            DateTime birthdate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter what kind of animal this is");
            string type = Console.ReadLine();
            Console.WriteLine("Enter the colour of the animal");
            string colour = Console.ReadLine();
            Console.WriteLine("Enter what date it was sold");
            DateTime soldBy = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("What is the price");
            double price = double.Parse(Console.ReadLine());

            return new Pet
            {
                Name = name,
                BirthDate = birthdate,
                Color = colour,
                OwnerId = prevOwner,
                price = price,
                SoldDate = soldBy,
                Type = (Enum)Enum.Parse(typeof(Pet.Types), type.ToLower())
            };
        }

        public void PrintPetDetails()
        {

            Console.WriteLine("Please Select the pet you want the details of");
            int detailIndex = int.Parse(Console.ReadLine()) - 1;

            Pet result = petsList.ElementAt(detailIndex);

            Console.Clear();
            Console.WriteLine(" ____________________ ");
            Console.WriteLine("|                    |");
            Console.WriteLine("|     Pet Details    |");
            Console.WriteLine("|____________________|");
            Console.WriteLine("");
            Console.WriteLine("Index: " + result.Id);
            Console.WriteLine("Name: " + result.Name);
            Console.WriteLine("Species: " + result.Type);
            Console.WriteLine("Colour(s): " + result.Color);
            Console.WriteLine("Birthdate: " + result.BirthDate);
            Console.WriteLine("Selling date: " + result.SoldDate);
            Console.WriteLine("Price: " + result.price);
            Console.WriteLine();
            Console.WriteLine("1. Get owner details");
            Console.WriteLine("0. Go back...");
            int outcome = int.Parse(Console.ReadLine());

            switch (outcome)
            {
                case 1:
                    PrintPrevOwner(result);
                    break;
                default:
                    CreatePet();
                    FetchPets();
                    Navigate();
                    break;
            }
        }

        public void PrintPrevOwner(Pet p)
        {
            Owner owner = _OwnerService.getOwner(p);
            Console.Clear();
            Console.WriteLine(" ____________________ ");
            Console.WriteLine("|                    |");
            Console.WriteLine("|    Owner Details   |");
            Console.WriteLine("|____________________|");
            Console.WriteLine("");
            Console.WriteLine("Name: " + owner.FirstName + " " + owner.LastName);
            Console.WriteLine("addess: " + owner.address);
            Console.WriteLine("Email: " +owner.Email);
            Console.WriteLine("Phone: " + owner.PhoneNumber);
            Console.WriteLine("");
            Console.WriteLine("Press enter to return...");
            Console.ReadLine();
         }
    }        
}


