using StokTakip.Entities.Concrete;
using StokTakip.Entities.Context;
using StokTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Services
{
    public class DeliveryService : BaseService<Delivery>
    {
        private readonly StokContext _stokContext;
        public DeliveryService(StokContext stokContext) : base(stokContext)
        {
            _stokContext = stokContext;
        }
        public List<DeliveryListModel> GetStockList()
        {
            var result = _stokContext.Deliveries.Select(s => new DeliveryListModel()
            {
                Id = s.Id,
                InvoiceDate = s.InvoiceDate,
                BranchName = s.Branch.Name,
                BranchId = s.BranchId,
                Piece = s.Piece,
                ProductName = s.Product.Name,
                ProductId = s.ProductId
            });

            return result.ToList();
        }
    }
}
