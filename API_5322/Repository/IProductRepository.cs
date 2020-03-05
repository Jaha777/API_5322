using API_5322.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_5322.Repository
{
    public interface IProductRepository
    {
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int ProductId);
        Product GetProductById(int Id);
        IEnumerable<Product> GetProducts();


    }
}
