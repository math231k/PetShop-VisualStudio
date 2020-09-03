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
    class Printer:IPrinter
    {
        public static Pet selectedPet = null;
        private IPetService _PetService { get; set; }
        private IOwnerService _OwnerService { get; set; }
        private List<Pet> petsList { get; set; }
        private List<Owner> OwnerList { get; set; }

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
            OwnerList = _OwnerService.ReadOwners();
            Navigate();
        }

        /// <summary>
        /// Handles all navigation inputs from the user by using a switch-case.
        /// </summary>
        public void Navigate()
        {
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("1. Get animal details");
            Console.WriteLine("2. Remove an animal from the database");
            Console.WriteLine("3. Create a new entry");
            Console.WriteLine("4. Sort after price");
            Console.WriteLine("5. Get the five cheepest animals");
            Console.WriteLine("6. Search for a pet");
            Console.WriteLine("7. Exit the application");
            
            switch (HandleUserNumberInput())
            {
                case 1:
                    PrintPetDetails();
                    FetchPets();
                    Navigate();
                    break;
                case 2:
                    RemovePet();
                    FetchPets();
                    Navigate();
                    break;
                case 3:
                    CreatePet();
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
                    System.Environment.Exit(1);
                    break;
                case 0:
                    FetchPets();
                    Navigate();
                    break;
                default:
                    Console.WriteLine("Please only use the numbers listed above, press enter to try again...");
                    Console.ReadLine();
                    Console.Clear();
                    FetchPets();
                    Navigate();
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
            Pet updatePet = GeneratePet();
            updatePet.OwnerId = selectedPet.OwnerId;
            updatePet.Id = selectedPet.Id;
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
            
            int ownerId = 0;
            string name = "";
            DateTime birthdate = DateTime.UtcNow;
            string type = "default";
            string colour = "";
            DateTime soldBy = DateTime.UtcNow;
            double price = 0;

            try
            {
                Console.WriteLine("\nEnter a name");
                name = Console.ReadLine();
                Console.WriteLine("\nDo you wish to add a previous owner? (y/n)");
                string response = Console.ReadLine();
                if (response.ToLower().Equals("y") && response!=null)
                {
                    Owner prevOwnerId = GenerateOwner();
                    ownerId = prevOwnerId.Id;
                }
                Console.WriteLine("\nEnter a BirthDate\nFormat: 'jan 1, 1999' or 'MM-dd-yyyy'\n");
                birthdate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("\nEnter what kind of animal this is\nEither dog, cat, hamster, fish, bird, snake or tarantula\n");
                type = Console.ReadLine();
                Console.WriteLine("\nEnter the colour of the animal\n");
                colour = Console.ReadLine();
                Console.WriteLine("\nEnter what date it was sold\nFormat: 'jan 1, 1999' or 'MM-dd-yyyy'\n");
                soldBy = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("\nWhat is the price\n");
                price = double.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException)
            {

                Console.WriteLine("Nothing entered at date or price, try again");
                Console.ReadLine();
                FetchPets();
                Navigate();
            }
            catch (FormatException)
            {
                Console.WriteLine("You've used the wrong format for either date or price, try again");
                Console.ReadLine();
                FetchPets();
                Navigate();
            }
            catch (OverflowException)
            {
                Console.WriteLine("The price is too high, i mean come on, no pet is worth that much...");
                Console.ReadLine();
                FetchPets();
                Navigate();
            }
            try
            {
                return new Pet
                {
                    Name = name,
                    BirthDate = birthdate,
                    Color = colour,
                    OwnerId = ownerId,
                    price = price,
                    SoldDate = soldBy,
                    Type = (Enum)Enum.Parse(typeof(Pet.Types), type.ToLower())
                };
            }
            catch(Exception)
            {
                Console.WriteLine("Pet type did not comply with the rules, try again");
                return null;
            }
        }

        /// <summary>
        /// Method Creating a previous owner for the pet via user input
        /// </summary>
        /// <returns>The owner created</returns>
        public Owner GenerateOwner()
        {
            Console.WriteLine("Please enter previous owners first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please enter previous owners Last name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Please enter previous owners address");
            string address = Console.ReadLine();
            Console.WriteLine("Please enter previous owners e-mail address");
            string email = Console.ReadLine();
            Console.WriteLine("Please enter previous owners telephone number");
            string phoneNumber = Console.ReadLine();

            return _OwnerService.CreateOwner(new Owner
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                Email = email,
                PhoneNumber = phoneNumber
            });
        }

        /// <summary>
        /// Prints all the data avalible for the animal
        /// </summary>
        public void PrintPetDetails()
        {
            Pet result;
            if (selectedPet == null)
            {
                Console.WriteLine("Please Select the pet you want the details of");
                int detailIndex = HandleUserNumberInput() - 1;
                result = petsList.ElementAt(detailIndex);
                selectedPet = result;
            }
            else
            {
                result = selectedPet;
            }
            

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
            Console.WriteLine("1. Update details");
            Console.WriteLine("2. Get owner details");
            Console.WriteLine("3. Add a previous owner");
            Console.WriteLine("4. Go back...");

            switch (HandleUserNumberInput())
            {
                case 1:
                    UpdatePet();
                    PrintPetDetails();
                    break;
                case 2:
                    if (result.OwnerId>0) {
                        PrintPrevOwner(result);
                    }
                    else
                    {
                        Console.WriteLine("A previous owner has not been assigned to this pet");
                        Console.ReadLine();
                        PrintPetDetails();
                    }
                    break;
                case 3:
                    if (selectedPet.OwnerId <= 0) {
                        selectedPet.OwnerId = GenerateOwner().Id;
                        PrintPetDetails();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("This pet already has a previous owner. \nPlease remove the previous owner in the owner details menu.\nPress enter to return");
                        Console.ReadLine();
                        PrintPetDetails();
                    }
                    break;
                case 0:
                    PrintPetDetails();
                    break;
                case 4:
                    selectedPet = null;
                    FetchPets();
                    Navigate();
                    break;
                default:
                    Console.WriteLine("Please only use the numbers listed above, press enter to try again...");
                    Console.ReadLine();
                    PrintPetDetails();
                    break;
            }
        }

        /// <summary>
        /// Prints all avalible data from the previous owner
        /// </summary>
        /// <param name="p">The previous owner just created</param>
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
            Console.WriteLine("addess: " + owner.Address);
            Console.WriteLine("Email: " +owner.Email);
            Console.WriteLine("Phone: " + owner.PhoneNumber);
            Console.WriteLine("");
            Console.WriteLine("1. Update previous owner details");
            Console.WriteLine("2. Remove previous owner");
            Console.WriteLine("3. Return to pet details");

            switch (HandleUserNumberInput())
            {
                case 1:
                    UpdateOwner();
                    PrintPrevOwner(selectedPet);
                    break;
                case 2:
                    RemoveOwner(OwnerList.ElementAt(selectedPet.OwnerId-1));
                    PrintPetDetails();
                    break;
                case 3:
                    PrintPetDetails();
                    break;
                case 0:
                    PrintPrevOwner(selectedPet);
                    break;
                default:
                    Console.WriteLine("Please only use the numbers listed above, press enter to try again...");
                    Console.ReadLine();
                    PrintPrevOwner(selectedPet);
                    break;
            }
        }

        /// <summary>
        /// Removes the selected owner from the database and sets pet ownerid to 0 for 'no reference'
        /// </summary>
        /// <param name="o">The owner you want to delete</param>
        /// <returns>The deleted owner</returns>
        public Owner RemoveOwner(Owner o)
        {
            selectedPet.OwnerId = 0;
            return _OwnerService.DeleteOwner(o);
        }

        /// <summary>
        /// Updates the data of the owner currently selected
        /// </summary>
        /// <returns>The updated owner</returns>
        public Owner UpdateOwner()
        {
            Owner updateOwner = GenerateOwner();
            updateOwner.Id = selectedPet.OwnerId;
            return _OwnerService.UpdateOwner(updateOwner);
        }

        /// <summary>
        /// Handles most exception that may result from user input
        /// </summary>
        /// <returns>The chosen integer or 0 based on the input</returns>
        public int HandleUserNumberInput()
        {
            int outcome = 0;
            try
            {
                outcome = int.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Please enter something, press enter to try again...");
                Console.ReadLine();
                return outcome;

            }
            catch (FormatException)
            {
                Console.WriteLine("You must enter a number, press enter to try again...");
                Console.ReadLine();
                return outcome;

            }
            catch (OverflowException)
            {
                Console.WriteLine("Please only use the numbers listed above, press enter to try again...");
                Console.ReadLine();
                return outcome;
            }
            return outcome;
        }
    }        
}


