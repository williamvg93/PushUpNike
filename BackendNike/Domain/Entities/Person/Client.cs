using System;
using System.Collections.Generic;
using Domain.Entities.BusinessMovements;
using Domain.Entities.Location;
using Domain.Entities.UserAuthenti;

namespace Domain.Entities.Person;

public partial class Client
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

    public virtual Address FkIdAddressNavigation { get; set; }

    public virtual Contact FkIdContactNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
