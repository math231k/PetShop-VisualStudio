using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace PetShop.Core.Entities
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Enum Type { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public int OwnerId { get; set; }
        public double price { get; set; }

        public enum Types
        {
            dog,
            cat,
            fish,
            hamster,
            bird,
            snake,
            tarantula
        }

        override
            public string ToString()
        {
            return Id + "   " + Name + ",   " + Type + ",  price: " + price+ " RUB";
        }
    }
}
