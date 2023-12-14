using System;
using System.Collections.Generic;
using Domain.Entities.BusinessMovements;

namespace Domain.Entities.Inventory;

public partial class Product : BaseEntity
{
    public string Name { get; set; }

    public int FkIdProdCategory { get; set; }

    public int FkIdColor { get; set; }

    public int FkIdtGenderType { get; set; }

    public int FkIdOrderDetail { get; set; }

    public virtual Prodcolor FkIdColorNavigation { get; set; }

    public virtual Prodcategory FkIdProdCategoryNavigation { get; set; }

    public virtual Gendertype FkIdtGenderTypeNavigation { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();
}
