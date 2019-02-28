using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2_FixAnAppDotNetCode.Models
{
  public class Product
  {
    private int id;
    private string name, description, details;
    private int stock;
    private double price;

    public Product(int id, int stock, double price, string name, string description)
    {
      this.id = id;
      this.stock = stock;
      this.price = price;
      this.name = name;
      this.description = description;
    }

    public int Id
    {
      get { return id; }
      set { id = value; }
    }

    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    public string Description
    {
      get { return description; }
      set { description = value; }
    }

    public string Details
    {
      get { return details; }
      set { details = value; }
    }

    public int Stock
    {
      get { return stock; }
      set { stock = value; }
    }

    public double Price
    {
      get { return price; }
      set { price = value; }
    }
  }
}
