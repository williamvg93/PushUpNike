using System;
using System.Collections.Generic;

namespace Domain.Entities.Inventory;

public partial class Prodcategory
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
