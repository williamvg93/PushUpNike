using System;
using System.Collections.Generic;

namespace ApiNike.Dtos.Get.Person;

public class ContactDto
{
    public int Id { get; set; }
    public string Number { get; set; }
    public int FkIdContactType { get; set; }

}
