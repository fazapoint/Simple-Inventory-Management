using InventoryManagementWeb.Models;
using InventoryManagementWeb.ViewModels;

namespace InventoryManagementWeb.Contracts
{
    public interface ITransaction : ICrud<Transaction>
    {
        IEnumerable<TransactionProductViewModel> GetProductTransactions();
        IEnumerable<TransactionProductViewModel> GetTransactionsByProductName(string transactionName);
        TransactionProductViewModel GetByIdJoin(int id);
    }
}
