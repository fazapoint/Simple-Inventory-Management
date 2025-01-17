﻿using InventoryManagementWeb.Models;

namespace InventoryManagementWeb.ViewModels
{
    public class TransactionProductViewModel
    {
        public int TransactionID { get; set; }
        public int? ProductID { get; set; }
        public string? ProductName { get; set; }
        public bool? TransactionType { get; set; }
        public int? Quantity { get; set; }
        public DateTime? Date { get; set; }
        public List<Product>? Products { get; set; }

        public Transaction Transaction { get; set; }
    }
}
