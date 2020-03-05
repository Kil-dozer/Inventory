using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inventory.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class InventoryController : ControllerBase
  {

    public DatabaseContext db { get; set; } = new DatabaseContext();
    [HttpGet]
    public List<InventoryItem> GetAllItems()
    {
      // query for all the menu items
      // sort them by name
      var allItems = db.InventoryItems.OrderBy(m => m.Name);
      // the sorted items  
      return allItems.ToList();
    }

    [HttpGet("{id}")]
    public InventoryItem GetSingle(int id)
    {
      var item = db.InventoryItems.FirstOrDefault(i => i.Id == id);
      //   Random HesdeadJim = new Random();
      //   int result = HesdeadJim.Next(1, 100);
      //   if (result <= 10)
      //   {
      //     pet.IsDead = true;
      //   }
      return item;

    }
    [HttpGet("OOS")]
    public ActionResult IsOutOfStock()
    {
      var itemOOS = db.InventoryItems.Where(n => n.NumInStock == 0);
      if (itemOOS == null)
      {
        return NotFound();
      }
      return Ok(itemOOS);
    }

    [HttpPost]
    public InventoryItem NewThing(InventoryItem item)
    {
      db.InventoryItems.Add(item);
      db.SaveChanges();
      return item;
    }

    // [HttpPost("multiple")]
    // public List<InventoryItem> AddManyItems(List<InventoryItem> item)
    // {
    //   db.InventoryItems.AddRange(item);
    //   db.SaveChanges();
    //   return item;
    // }

    [HttpPut("{id}/update")]
    public InventoryItem Update(int id, InventoryItem newData)
    {
      newData.Id = id;
      db.Entry(newData).State = EntityState.Modified;
      db.SaveChanges();
      return newData;
    }


    [HttpGet("Sku/{sku}")]
    public ActionResult FindSKU(string sku)
    {
      var item = db.InventoryItems.Where(s => s.SKU == sku);
      if (item == null)
      {
        return NotFound();
      }
      return Ok(item);

    }

    [HttpDelete("{id}")]
    public ActionResult DeleteOne(int id)
    {
      var item = db.InventoryItems.FirstOrDefault(f => f.Id == id);
      if (item == null)
      {
        return NotFound();
      }
      db.InventoryItems.Remove(item);
      db.SaveChanges();
      return Ok();
    }

  }







}