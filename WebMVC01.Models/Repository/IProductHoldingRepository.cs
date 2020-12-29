using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC01.Models.Repository
{
    interface IProductHoldingRepository : IRepository<ProductHolding>
    {

         IQueryable<ProductHolding> ProductsAdjustment();
        
    }
}
