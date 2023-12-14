using System;
using System.Collections.Generic;

namespace Domain.Entities.Location;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int FkIdDepartment { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Department FkIdDepartmentNavigation { get; set; }
}
