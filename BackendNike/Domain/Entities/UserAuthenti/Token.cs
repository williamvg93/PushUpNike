using System;
using System.Collections.Generic;

namespace Domain.Entities.UserAuthenti;

public partial class Token : BaseEntity
{
    public string Code { get; set; }

    public DateTime CreationDate { get; set; }

    public int FkIdUser { get; set; }

    public virtual User FkIdUserNavigation { get; set; }
}
