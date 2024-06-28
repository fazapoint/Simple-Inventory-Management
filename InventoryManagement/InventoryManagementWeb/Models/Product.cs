using System;
using System.Collections.Generic;

namespace InventoryManagementWeb.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public int? StockLevel { get; set; }
}
