using System;
using System.Collections.Generic;
using Domain.Entities.Person;

namespace Domain.Entities.BusinessMovements;

public partial class Order : BaseEntity
{
    public DateTime CreationDate { get; set; }

    public int FkIdClient { get; set; }

    public int FkIdStatus { get; set; }

    public int FkIdPaymentType { get; set; }

    public virtual Client FkIdClientNavigation { get; set; }

    public virtual Paymenttype FkIdPaymentTypeNavigation { get; set; }

    public virtual Orderstatus FkIdStatusNavigation { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();
}
