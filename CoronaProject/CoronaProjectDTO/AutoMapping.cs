using AutoMapper;
using CoronaProjectDTO.DTO;
using CoronaProjectDL.Models;




namespace CoronaProjectDTO
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<Vaccination, VaccinationDTO>().ReverseMap();
            CreateMap<Manufacter, ManufacterDTO>().ReverseMap();
        }
    
    }
}
