using System;
using System.Collections.Generic;

namespace Domain.Entities.Inventory;

public partial class Prodcolor : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
