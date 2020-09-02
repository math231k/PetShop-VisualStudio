using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;

namespace PetShop.Core.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}
