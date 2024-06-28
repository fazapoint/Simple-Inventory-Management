using InventoryManagementWeb.Contracts;
using InventoryManagementWeb.Models;
using InventoryManagementWeb.Services;
using InventoryManagementWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementWeb.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransaction _transaction;
        private readonly IProduct _product;
        public TransactionsController(ITransaction transaction, IProduct product)
        {
            _transaction = transaction;
            _product = product;
        }


        public IActionResult Index()
        {
            var models = _transaction.GetProductTransactions();
            return View(models);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            var transaction = _transaction.GetById(id);
            return View(transaction);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            var viewModel = new TransactionProductViewModel
            {
                Products = _product.GetAll().ToList()
            };
            return View(viewModel);
        }

        // POST: ProductsController/Create
        [HttpPost]
        public ActionResult Create(Transaction transaction)
        {
            try
            {
                var result = _transaction.Add(transaction);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Failed to create transaction: {ex.Message}";
                return View(transaction);
            }
        }
    }
}
