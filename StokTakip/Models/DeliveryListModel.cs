using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Models
{
    public class DeliveryListModel
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Piece { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
