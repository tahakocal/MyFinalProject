using System;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product(){CategoryId = 1,ProductId = 1,ProductName = "Bardak",UnitPrice = 15,UnitInStock = 15},
                new Product(){CategoryId = 2,ProductId = 2,ProductName = "Kamera",UnitPrice = 500,UnitInStock = 3},
                new Product(){CategoryId = 3,ProductId = 3,ProductName = "Telefon",UnitPrice = 1500,UnitInStock = 2},
                new Product(){CategoryId = 4,ProductId = 4,ProductName = "Klavye",UnitPrice = 150,UnitInStock = 65},
                new Product(){CategoryId = 5,ProductId = 5,ProductName = "Fare",UnitPrice = 85,UnitInStock = 1}
            };
        }
        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul 
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
        }

        public void Delete(Product product)
        {
            //LINQ
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}
