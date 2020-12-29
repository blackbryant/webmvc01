using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC01.Models;
using WebMVC01.Models.Repository;
using WebMVC01.Service.face;

namespace WebMVC01.Service
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IProductRepository ProductRepository
        {
               get { return _productRepository; }
        }

        public IEnumerable<Product> GetProducts(string name)
        {
            var products = _productRepository.FindByProdcts(name);
            return products; 
        }

        public IEnumerable<Product> GetProducts(int id)
        {
            var rProduct = _productRepository.FindById(id);
            List<Product> products = new List<Product>(); 

            if (rProduct == null)
            {
                return null; 
            }
            else
            {
                products.Add(rProduct); 
            }


            return products;
        }
    }
}
