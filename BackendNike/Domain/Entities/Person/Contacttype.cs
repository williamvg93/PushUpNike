using System;
using System.Collections.Generic;

namespace Domain.Entities.Person;

public partial class Contacttype : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();
}
