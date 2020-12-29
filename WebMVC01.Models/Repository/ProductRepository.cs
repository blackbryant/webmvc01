using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC01.Models.Repository
{
    public class ProductRepository : EntityRepository<Product>, IProductRepository
    {
        public IQueryable<Product> FindByProdcts(string name)
        {
            IQueryable<Product> products = _model.Products.Where(p => p.ProductName.Contains(name));
            return products; 
        }
    }
}
