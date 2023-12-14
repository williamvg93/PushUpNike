using System;
using System.Collections.Generic;
using Domain.Entities.Person;

namespace Domain.Entities.UserAuthenti;

public partial class User : BaseEntity
{
    public string Name { get; set; }

    public string Password { get; set; }

    public DateTime CreationDate { get; set; }

    public int FkIdRol { get; set; }

    public int? FkIdClient { get; set; }

    public virtual Client FkIdClientNavigation { get; set; }

    public virtual Userrol FkIdRolNavigation { get; set; }

    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();
}
