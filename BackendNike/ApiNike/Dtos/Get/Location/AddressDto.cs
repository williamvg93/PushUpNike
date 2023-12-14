using System;
using System.Collections.Generic;
using Domain.Entities.Person;

namespace ApiNike.Dtos.Get.Location;

public class AddressDto
{
    public int Id { get; set; }
    public string Description { get; set; }

    public string Complement { get; set; }

    public int FkIdAddressType { get; set; }

    public int IkIdCity { get; set; }

}
