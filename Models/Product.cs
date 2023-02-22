using System;
using System.Collections.Generic;

namespace Product_ExceptionalHandl.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;

    public string ProductCategory { get; set; } = null!;

    public double ProductPrice { get; set; }
}
