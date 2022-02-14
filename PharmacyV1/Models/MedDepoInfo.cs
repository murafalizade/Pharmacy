using System;
using System.Collections.Generic;


namespace Pharmacy.Models
{
    public  class MedDepoInfo
    {
        public int Id { get; set; }
        public int MedicineId { get; set; }
        public int DepoId { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public DateTime ExpDate { get; set; }

        public virtual Depo Depo { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
