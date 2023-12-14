using System;
using System.Collections.Generic;

namespace Domain.Entities.UserAuthenti;

public partial class Userrol : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
