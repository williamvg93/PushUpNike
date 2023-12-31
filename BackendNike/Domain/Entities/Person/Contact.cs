﻿using System;
using System.Collections.Generic;

namespace Domain.Entities.Person;

public partial class Contact : BaseEntity
{
    public string Number { get; set; }

    public int FkIdContactType { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual Contacttype FkIdContactTypeNavigation { get; set; }
}
