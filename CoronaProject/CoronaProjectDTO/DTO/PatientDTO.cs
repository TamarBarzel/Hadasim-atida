using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaProjectDTO.DTO
{
    public class PatientDTO
    {
        public int PatientId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string CityName { get; set; } = null!;

        public string Street { get; set; } = null!;

        public DateOnly BirthDate { get; set; }

        public int Phone { get; set; }

        public int Mobile { get; set; }

        public bool? InfectedCorona { get; set; } = false;

        public DateOnly? InfectedDate { get; set; } = null!;

        public DateOnly? RecoveryDate { get; set; } = null!;

        public int PatientUnikId { get; set; }



    }
}
