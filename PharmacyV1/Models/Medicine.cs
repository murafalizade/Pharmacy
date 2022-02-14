using System;
using System.Collections.Generic;


namespace Pharmacy.Models
{
    public  class Medicine
    {
        public Medicine()
        {
            MedDepoInfos = new HashSet<MedDepoInfo>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Description { get; set; }

        public virtual Type Type { get; set; }
        public virtual ICollection<MedDepoInfo> MedDepoInfos { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
