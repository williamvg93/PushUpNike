using System;
using System.Collections.Generic;
using Domain.Entities.BusinessMovements;
using Domain.Entities.Location;
using Domain.Entities.UserAuthenti;

namespace ApiNike.Dtos.Get.Person;

public class ClientDto
{
    public int Id { get; set; }
    public string Code { get; set; }

    public string Name { get; set; }

    public string LastName { get; set; }

    public short Age { get; set; }

    public string Email { get; set; }

    public DateTime CreationDate { get; set; }

    public int FkIdContact { get; set; }

    public int FkIdAddress { get; set; }

}
