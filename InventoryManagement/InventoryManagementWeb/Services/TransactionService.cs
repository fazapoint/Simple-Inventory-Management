using InventoryManagementWeb.Contracts;
using InventoryManagementWeb.Models;
using InventoryManagementWeb.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementWeb.Services
{
    public class TransactionService : ITransaction
    {
        private readonly InventoryDbContext _inventoryDbContext;
        public TransactionService(InventoryDbContext inventoryDbContext)
        {
            _inventoryDbContext = inventoryDbContext;
        }

        public Transaction Add(Transaction entity)
        {
            try
            {
                var product = _inventoryDbContext.Products.FirstOrDefault(p => p.ProductId == entity.ProductId);

                _inventoryDbContext.Transactions.Add(entity);
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
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetAll()
        {
            var results = _inventoryDbContext.Transactions.ToList();
            return results;
        }

        public Transaction GetById(int id)
        {
            var result = _inventoryDbContext.Transactions.Where(c => c.TransactionId == id).FirstOrDefault();
            if (result == null)
            {
                throw new ArgumentException("Transaction not found");
            }
            return result;
        }

        public TransactionProductViewModel GetByIdJoin(int id)
        {
            var result = _inventoryDbContext.Transactions
                .Where(t => t.TransactionId == id)
                .Include(t => t.Product)
                .FirstOrDefault();

            if (result == null)
            {
                throw new ArgumentException("Transaction not found");
            }

            // Mapping to TransactionProductViewModel
            var viewModel = new TransactionProductViewModel
            {
                TransactionID = result.TransactionId,
                ProductID = result.ProductId,
                ProductName = result.Product.Name,
                TransactionType = result.TransactionType,
                Quantity = result.Quantity,
                Date = result.Date
            };

            return viewModel;
        }

        public IEnumerable<TransactionProductViewModel> GetProductTransactions()
        {
            var results = from t in _inventoryDbContext.Transactions
                          join p in _inventoryDbContext.Products
                          on t.ProductId equals p.ProductId
                          orderby t.TransactionId descending
                          select new TransactionProductViewModel
                          {
                              TransactionID = t.TransactionId,
                              ProductID = t.ProductId,
                              ProductName = p.Name,
                              TransactionType = t.TransactionType,
                              Quantity = t.Quantity,
                              Date = t.Date
                          };
            return results.ToList();
        }

        public Transaction Update(Transaction entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TransactionProductViewModel> ITransaction.GetTransactionsByProductName(string productName)
        {
            var results = from t in _inventoryDbContext.Transactions
                          join p in _inventoryDbContext.Products on t.ProductId equals p.ProductId
                          where p.Name.Contains(productName)
                          orderby t.Date descending
                          select new TransactionProductViewModel
                          {
                              TransactionID = t.TransactionId,
                              ProductID = t.ProductId,
                              TransactionType = t.TransactionType,
                              Quantity = t.Quantity,
                              Date = t.Date,
                              ProductName = p.Name
                          };

            return results.ToList();


        }
    }
}
