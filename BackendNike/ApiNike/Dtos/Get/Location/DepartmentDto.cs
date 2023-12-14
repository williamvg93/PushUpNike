using System;
using System.Collections.Generic;

namespace ApiNike.Dtos.Get.Location;

public class DepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int FkIdCountry { get; set; }

}
