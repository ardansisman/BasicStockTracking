using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Entities.Concrete
{
    public class Delivery
    {
        [Key]
        public int Id { get; set; }
        public int BranchId { get; set; }
        public int ProductId { get; set; }
        public int Piece { get; set; }
        public DateTime InvoiceDate { get; set; }
        public virtual Branch   Branch { get; set; }
       public virtual Product Product { get; set; }
    }
}
