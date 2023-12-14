using System;
using System.Collections.Generic;

namespace Domain.Entities.Person;

public partial class Contacttype
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();
}
