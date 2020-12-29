using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC01.Models.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        IQueryable<Product> FindByProdcts(string name); 
    }
}
