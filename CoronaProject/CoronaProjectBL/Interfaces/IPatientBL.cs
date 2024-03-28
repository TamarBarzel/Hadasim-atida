using CoronaProjectDTO.DTO;

namespace CoronaProjectBL.Interfaces
{
    public interface IPatientBL
    {
        Task<PatientDTO> AddPatient(PatientDTO patientDTO);
        Task<PatientDTO> DeletePatient(int id);
        Task<List<PatientDTO>> GetAllPatients();
        Task<List<PatientDTO>> GetAllPatientsByCity(string cityName);
        Task<List<PatientDTO>> GetAllPatientsByInfectedCorona(bool infectedCorona);
        Task<List<PatientDTO>> GetAllPatientsByUnrecoveryCorona(bool infectedCorona);
        Task<PatientDTO> GetPatientById(int id);
        Task<PatientDTO> GetPatientByLastName(string lastName);
        Task<PatientDTO> GetPatientByPatientUnikId(int patientUnikId);
        Task<PatientDTO> UpdatePatient(int id, PatientDTO patientDTO);
    }
}