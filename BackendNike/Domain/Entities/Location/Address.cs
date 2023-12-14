using System;
using System.Collections.Generic;
using Domain.Entities.Person;

namespace Domain.Entities.Location;

public partial class Address : BaseEntity
{
    public string Description { get; set; }

    public string Complement { get; set; }

    public int FkIdAddressType { get; set; }

    public int IkIdCity { get; set; }

    public virtual Client Client { get; set; }

    public virtual Addresstype FkIdAddressTypeNavigation { get; set; }

    public virtual City IkIdCityNavigation { get; set; }
}
