﻿using System;
using System.Collections.Generic;

namespace Domain.Entities.Location;

public partial class Department : BaseEntity
{
    public string Name { get; set; }

    public int FkIdCountry { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country FkIdCountryNavigation { get; set; }
}
