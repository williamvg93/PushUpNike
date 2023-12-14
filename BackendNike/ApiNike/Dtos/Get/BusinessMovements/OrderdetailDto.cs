using System;
using System.Collections.Generic;
using Domain.Entities.Inventory;

namespace ApiNike.Dtos.Get.BusinessMovements;

public class OrderdetailDto
{
    public int Id { get; set; }
    public int FkIdOrder { get; set; }
    public int FkIdProduct { get; set; }
}
