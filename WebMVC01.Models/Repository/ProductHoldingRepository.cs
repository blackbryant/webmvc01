using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC01.Models.Repository
{
    public class ProductHoldingRepository : EntityRepository<ProductHolding>, IProductHoldingRepository
    {
        public IQueryable<ProductHolding> ProductsAdjustment()
        {
            IQueryable<ProductHolding> products = _model.ProductHoldings.Where(p => p.Quantity <= p.ReorderLevel);
            return products; 
        }
    }
}
