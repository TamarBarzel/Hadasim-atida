using System;
using System.Collections.Generic;

namespace CoronaProjectDL.Models;

public partial class Vaccination
{
    public int VaccinationId { get; set; }

    public int ManufacterId { get; set; }

    public DateOnly VaccinationDate { get; set; }

    public int PatientUnikId { get; set; }

    public virtual Manufacter Manufacter { get; set; } = null!;
}
