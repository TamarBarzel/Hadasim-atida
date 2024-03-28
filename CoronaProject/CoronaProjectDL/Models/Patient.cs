using System;
using System.Collections.Generic;

namespace CoronaProjectDL.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string CityName { get; set; } = null!;

    public string Street { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public int Phone { get; set; }

    public int Mobile { get; set; }

    public bool? InfectedCorona { get; set; }

    public DateOnly? InfectedDate { get; set; }

    public DateOnly? RecoveryDate { get; set; }

    public int PatientUnikId { get; set; }
}
