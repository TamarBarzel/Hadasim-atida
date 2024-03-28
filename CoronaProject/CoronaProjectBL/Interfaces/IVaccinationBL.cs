using CoronaProjectDTO.DTO;

namespace CoronaProjectBL.Interfaces
{
    public interface IVaccinationBL
    {
        Task<VaccinationDTO> AddVaccination(VaccinationDTO vaccinationDTO, int patientUnikId);
        Task<VaccinationDTO> DeleteVaccination(int vaccinationId);
        Task<List<VaccinationDTO>> DeleteAllVaccinationsByPatientUniqId(int patientUnikId);
        Task<List<VaccinationDTO>> GetAllVaccinations();
        Task<List<VaccinationDTO>> GetAllVaccinationsByPatientUniqId(int patientUnikId);
        Task<VaccinationDTO> GetVaccinationById(int id);
        Task<VaccinationDTO> UpdateVaccination(int id, VaccinationDTO vaccinationDTO);
    }
}