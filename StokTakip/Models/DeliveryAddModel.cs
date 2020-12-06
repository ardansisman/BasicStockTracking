using StokTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Models
{
    public class DeliveryAddModel
    {
        public List<Product> ProductList { get; set; }
        public List<Branch> BranchList { get; set; }
        public Delivery Delivery { get; set; }
    }
}
