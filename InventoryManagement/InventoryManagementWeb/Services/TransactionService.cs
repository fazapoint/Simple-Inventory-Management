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

        public Transaction Update(Transaction entity)
        {
            throw new NotImplementedException();
        }


    }
}
