using System;
using System.Collections.Generic;

namespace Inventory.Models
{
  public class InventoryItem
  {
    public int Id { get; set; }
    public string SKU { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int NumInStock { get; set; }
    public Double Price { get; set; }
    public DateTime Orderdate { get; set; } = DateTime.Now;

  }
}