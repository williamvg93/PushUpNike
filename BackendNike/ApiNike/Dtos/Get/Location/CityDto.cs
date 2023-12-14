using System;
using System.Collections.Generic;

namespace ApiNike.Dtos.Get.Location;

public class CityDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int FkIdDepartment { get; set; }
}
