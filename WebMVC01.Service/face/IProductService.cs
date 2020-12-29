using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC01.Models;
using WebMVC01.Models.Repository;

namespace WebMVC01.Service.face
{
    public interface IProductService
    {
        IProductRepository ProductRepository { get; }
        IEnumerable<Product> GetProducts(string name);
        IEnumerable<Product> GetProducts(int id);

    }
}
