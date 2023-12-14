using System;
using System.Collections.Generic;

namespace Domain.Entities.BusinessMovements;

public partial class Orderstatus
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
