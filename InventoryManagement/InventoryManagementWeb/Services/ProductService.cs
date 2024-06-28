using InventoryManagementWeb.Contracts;
using InventoryManagementWeb.Models;
using InventoryManagementWeb.ViewModels;
using System;

namespace InventoryManagementWeb.Services
{
    public class ProductService : IProduct
    {
        private readonly InventoryDbContext _inventoryDbContext;
        public ProductService(InventoryDbContext inventoryDbContext)
        {
            _inventoryDbContext = inventoryDbContext;
        }

        public Product Add(Product entity)
        {
            try
            {
                _inventoryDbContext.Products.Add(entity);
                _inventoryDbContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var deleteProduct = GetById(id);
                if (deleteProduct != null)
                {
                    _inventoryDbContext.Products.Remove(deleteProduct);
                    _inventoryDbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Category not found");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<Product> GetAll()
        {
            var results = _inventoryDbContext.Products.ToList();
            return results;
        }

        public Product GetById(int id)
        {
            var result = _inventoryDbContext.Products.Where(c => c.ProductId== id).FirstOrDefault();
            if (result == null)
            {
                throw new ArgumentException("Product not found");
            }
            return result;
        }

        public Product Update(Product entity)
        {
            try
            {
                var updateProduct = GetById(entity.ProductId);
                if (updateProduct != null)
                {
                    updateProduct.Name = entity.Name;
                    updateProduct.StockLevel = entity.StockLevel;
                    _inventoryDbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Product not found");
                }
                return updateProduct;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<Product> GetProductsByName(string productName)
        {
            var results = (from c in _inventoryDbContext.Products
                           where c.Name.Contains(productName)
                           select c).ToList();
            return results;
        }
    }
}
