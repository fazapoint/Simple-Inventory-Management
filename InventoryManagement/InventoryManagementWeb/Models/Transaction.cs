using System;
using System.Collections.Generic;

namespace InventoryManagementWeb.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int? ProductId { get; set; }

    public bool? TransactionType { get; set; }

    public int? Quantity { get; set; }

    public DateTime? Date { get; set; }
}
