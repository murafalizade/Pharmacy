using System;
using System.Collections.Generic;


namespace Pharmacy.Models
{
    public  class Type
    {
        public Type()
        {
            Medicines = new HashSet<Medicine>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
