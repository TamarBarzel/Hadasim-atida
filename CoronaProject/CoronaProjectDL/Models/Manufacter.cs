using System;
using System.Collections.Generic;

namespace CoronaProjectDL.Models;

public partial class Manufacter
{
    public int ManufacterId { get; set; }

    public string ManufacterName { get; set; } = null!;

    public virtual ICollection<Vaccination> Vaccinations { get; set; } = new List<Vaccination>();
}
