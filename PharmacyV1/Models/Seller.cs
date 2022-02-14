using System;
using System.Collections.Generic;

namespace Pharmacy.Models
{
    public  class Seller
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public  List<Order> Orders { get; set; }
    }
}
