using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using API_5322.Models;
using API_5322.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_5322.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            SampleData();
        }
        // GET: api/Product
        [HttpGet]
        public IActionResult Get()
        {
            var products = _productRepository.GetProducts();
            return new OkObjectResult(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var product = _productRepository.GetProductById(id);
            return new OkObjectResult(product);

        }

        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            using (var scope = new TransactionScope())
            {
                _productRepository.InsertProduct(product);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
            }

        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (product != null)
            {
                using (var scope = new TransactionScope())
                {
                    _productRepository.UpdateProduct(product);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productRepository.DeleteProduct(id);
            return new OkResult();
        }

        private void SampleData()
        {
            if (_productRepository.GetProducts().Count() == 0)
            {
                var products = _productRepository;

                Product p1 = new Product();
                p1.Name = "Samsung Galaxy S10+";
                p1.Category = "Electronics";
                p1.Description = "G975 8GB/128GB Dual sim Exynos 9820";
                p1.Price = 6967300;
                p1.DateAdded = DateTime.Now;
                p1.Quantity = 10;
                products.InsertProduct(p1);

                Product p2 = new Product();
                p2.Name = "Samsung Galaxy A10S";
                p2.Category = "Electronics";
                p2.Description = "SM A107F/DS";
                p2.Price = 1495800;
                p2.DateAdded = DateTime.Now;
                p2.Quantity = 3;
                products.InsertProduct(p2);

                Product p3 = new Product();
                p3.Name = "Samsung Galaxy A30S";
                p3.Category = "Electronics";
                p3.Description = "3GB/32GB";
                p3.Price = 1910800;
                p3.DateAdded = DateTime.Now;
                p3.Quantity = 7;
                products.InsertProduct(p3);

                Product p4 = new Product();
                p4.Name = "Magicar";
                p4.Category = "Auto";
                p4.Description = "Car alarms";
                p4.Price = 1756800;
                p4.DateAdded = DateTime.Now;
                p4.Quantity = 11;
                products.InsertProduct(p4);

                Product p5 = new Product();
                p5.Name = "Magicar M908F";
                p5.Category = "Auto";
                p5.Description = "Car alarms";
                p5.Price = 1805800;
                p5.DateAdded = DateTime.Now;
                p5.Quantity = 3;
                products.InsertProduct(p5);

                Product p6 = new Product();
                p6.Name = "HocoB35D";
                p6.Category = "Electronics";
                p6.Description = "Portable power bank";
                p6.Price = 95800;
                p6.DateAdded = DateTime.Now;
                p6.Quantity = 17;
                products.InsertProduct(p6);

                Product p7 = new Product();
                p7.Name = "Samsung Galaxy A20S";
                p7.Category = "Electronics";
                p7.Description = "SM A20D/DS";
                p7.Price = 1606800;
                p7.DateAdded = DateTime.Now;
                p7.Quantity = 9;
                products.InsertProduct(p7);

                Product p8 = new Product();
                p8.Name = "electrolux";
                p8.Category = "Household appliances";
                p8.Description = "EHU-3810D/3815D";
                p8.Price = 1109800;
                p8.DateAdded = DateTime.Now;
                p8.Quantity = 3;
                products.InsertProduct(p8);

                Product p9 = new Product();
                p9.Name = "Freon galaxy";
                p9.Category = "Household appliances";
                p9.Description = "R134A";
                p9.Price = 1220800;
                p9.DateAdded = DateTime.Now;
                p9.Quantity = 8;
                products.InsertProduct(p9);

                Product p10 = new Product();
                p10.Name = "Haier";
                p10.Category = "Household appliances";
                p10.Description = "L1P15-F21S";
                p10.Price = 4825800;
                p10.DateAdded = DateTime.Now;
                p10.Quantity = 13;
                products.InsertProduct(p10);

                Product p11 = new Product();
                p11.Name = "Trouser";
                p11.Category = "Clothes and shoes";
                p11.Description = "117017";
                p11.Price = 116000;
                p11.DateAdded = DateTime.Now;
                p11.Quantity = 4;
                products.InsertProduct(p11);

                Product p12 = new Product();
                p12.Name = "Polo 111";
                p12.Category = "Clothes and shoes";
                p12.Description = "Polo";
                p12.Price = 95800;
                p12.DateAdded = DateTime.Now;
                p12.Quantity = 6;
                products.InsertProduct(p12);

                Product p13 = new Product();
                p13.Name = "Acer";
                p13.Category = "Computers";
                p13.Description = "Intel i3 4GB/1TB ";
                p13.Price = 3618800;
                p13.DateAdded = DateTime.Now;
                p13.Quantity = 3;
                products.InsertProduct(p13);

                Product p14 = new Product();
                p14.Name = "HP 250";
                p14.Category = "Computers";
                p14.Description = "250GB 1WY33EA";
                p14.Price = 2238800;
                p14.DateAdded = DateTime.Now;
                p14.Quantity = 5;
                products.InsertProduct(p14);

                Product p15 = new Product();
                p15.Name = "Lenova legion";
                p15.Category = "Computers";
                p15.Description = "Y540-17IRH 81Q4002VRK";
                p15.Price = 12062800;
                p15.DateAdded = DateTime.Now;
                p15.Quantity = 4;
                products.InsertProduct(p15);

                Product p16 = new Product();
                p16.Name = "HP ProBook";
                p16.Category = "Computers";
                p16.Description = "450G5";
                p16.Price = 6369800;
                p16.DateAdded = DateTime.Now;
                p16.Quantity = 2;
                products.InsertProduct(p16);

                Product p17 = new Product();
                p17.Name = "HP ProOne";
                p17.Category = "Computers";
                p17.Description = "monoblock  440 G4";
                p17.Price = 9553800;
                p17.DateAdded = DateTime.Now;
                p17.Quantity = 1;
                products.InsertProduct(p17);

                Product p18 = new Product();
                p18.Name = "Lenovo IdeaCentre";
                p18.Category = "Computers";
                p18.Description = "520-24ICB";
                p18.Price = 5983000;
                p18.DateAdded = DateTime.Now;
                p18.Quantity = 2;
                products.InsertProduct(p18);

                Product p19 = new Product();
                p19.Name = "Samsung Galaxy A70";
                p19.Category = "Electronics";
                p19.Description = "SM G907F/DS";
                p19.Price = 3495800;
                p19.DateAdded = DateTime.Now;
                p19.Quantity = 20;
                products.InsertProduct(p19);

                Product p20 = new Product();
                p20.Name = "Samsung Galaxy A501";
                p20.Category = "Electronics";
                p20.Description = "SM G6107F/DS";
                p20.Price = 2495800;
                p20.DateAdded = DateTime.Now;
                p20.Quantity = 5;
                products.InsertProduct(p20);
            }
        }

    }
}
