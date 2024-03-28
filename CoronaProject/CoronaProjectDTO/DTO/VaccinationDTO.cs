using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaProjectDTO.DTO
{
    public class VaccinationDTO
    {
        public int VaccinationId { get; set; }

        public int ManufacterId { get; set; }

        public int PatientUnikId { get; set; }

        public DateOnly VaccinationDate { get; set; }

        //public ManufacterDTO Manufacter { get; set; } = null!;
    }
}
