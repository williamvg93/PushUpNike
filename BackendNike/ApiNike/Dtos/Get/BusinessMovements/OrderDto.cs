using System;
using System.Collections.Generic;
using Domain.Entities.Person;

namespace ApiNike.Dtos.Get.BusinessMovements;

public class OrderDto
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public int FkIdClient { get; set; }
    public int FkIdStatus { get; set; }
    public int FkIdPaymentType { get; set; }
}
