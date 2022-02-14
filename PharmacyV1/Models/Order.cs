using System;
using System.Collections.Generic;


namespace Pharmacy.Models
{
    public  class Order
    {
        public int Id { get; set; }
        public int MedicineId { get; set; }
        public int Count { get; set; }
        public double TotalPrice { get; set; }
        public int SellerId { get; set; }
        public string OrderId { get; set; }

        public virtual Medicine Medicine { get; set; }
        public virtual Seller Seller { get; set; }
    }
}
