using InventoryManagementWeb.Contracts;
using InventoryManagementWeb.Models;
using InventoryManagementWeb.ViewModels;

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
                if (product == null)
                {
                    throw new Exception("Product not found");
                }

                if (entity.TransactionType == false && product.StockLevel == 0)
                {
                    throw new Exception("Cannot create a sale transaction for a product with zero stock level");
                }

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

        public IEnumerable<TransactionProductViewModel> GetProductTransactions()
        {
            var results = from t in _inventoryDbContext.Transactions
                          join p in _inventoryDbContext.Products
                          on t.ProductId equals p.ProductId
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

        public IEnumerable<Transaction> GetTransactionsByName(string transactionName)
        {
            throw new NotImplementedException();
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
