using CoronaProjectDL.Models;

namespace CoronaProjectDL.Interfaces
{
    public interface IVaccinationDL
    {
        Task<Vaccination> AddVaccination(Vaccination vaccination, int patientUnikId);
        Task<Vaccination> DeleteVaccination(int vaccinationId);
        Task<List<Vaccination>> DeleteAllVaccinationsByPatientUniqId(int patientUnikId);
        Task<List<Vaccination>> GetAllVaccinations();
        Task<List<Vaccination>> GetAllVaccinationsByPatientUniqId(int patientUnikId);
        Task<Vaccination> GetVaccinationById(int id);
        Task<Vaccination> UpdateVaccination(int id, Vaccination vaccination);
    }
}