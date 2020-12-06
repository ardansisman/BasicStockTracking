using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Entities.Concrete
{
    public class Product
    {
        public Product()
        {
            Deliveries = new HashSet<Delivery>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
