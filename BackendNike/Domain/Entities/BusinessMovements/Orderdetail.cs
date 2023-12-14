using System;
using System.Collections.Generic;
using Domain.Entities.Inventory;

namespace Domain.Entities.BusinessMovements;

public partial class Orderdetail
{
    public int Id { get; set; }

    public int FkIdOrder { get; set; }

    public int FkIdProduct { get; set; }

    public virtual Order FkIdOrderNavigation { get; set; }

    public virtual Product FkIdProductNavigation { get; set; }
}
