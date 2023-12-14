using System;
using System.Collections.Generic;
using Domain.Entities.BusinessMovements;

namespace ApiNike.Dtos.Get.Inventory;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int FkIdProdCategory { get; set; }

    public int FkIdColor { get; set; }

    public int FkIdtGenderType { get; set; }

    public int FkIdOrderDetail { get; set; }
}
