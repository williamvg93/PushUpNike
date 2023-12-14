using System;
using System.Collections.Generic;

namespace Domain.Entities.Location;

public partial class Country : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
