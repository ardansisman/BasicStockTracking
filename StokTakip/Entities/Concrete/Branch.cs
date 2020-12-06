using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Entities.Concrete
{
    public class Branch
    {
        public Branch()
        {
            Deliveries = new HashSet<Delivery>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
