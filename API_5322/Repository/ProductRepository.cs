using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_5322.DBContexts;
using API_5322.Models;
using Microsoft.EntityFrameworkCore;

namespace API_5322.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _dbContext;
        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteProduct(int ProductId)
        {
            _dbContext.Entry(GetProductById(ProductId)).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }

        public Product GetProductById(int Id)
        {
            return _dbContext.Products.SingleOrDefault(p => p.Id == Id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products;
        }

        public void InsertProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
