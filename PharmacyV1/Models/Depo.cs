using System;
using System.Collections.Generic;

namespace Pharmacy.Models
{
    public  class Depo
    {
        public Depo()
        {
            MedDepoInfos = new HashSet<MedDepoInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<MedDepoInfo> MedDepoInfos { get; set; }
    }
}
