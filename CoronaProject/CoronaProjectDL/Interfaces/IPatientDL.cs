using CoronaProjectDL.Models;

namespace CoronaProjectDL.Interfaces
{
    public interface IPatientDL
    {
        Task<Patient> AddPatient(Patient patient);
        Task<Patient> DeletePatient(int id);
        Task<List<Patient>> GetAllPatients();
        Task<List<Patient>> GetAllPatientsByCity(string cityName);
        Task<List<Patient>> GetAllPatientsByInfectedCorona(bool infectedCorona);
        Task<List<Patient>> GetAllPatientsByUnrecoveryCorona(bool infectedCorona);
        Task<Patient> GetPatientById(int id);
        Task<Patient> GetPatientByLastName(string lastName);
        Task<Patient> GetPatientByPatientUnikId(int patientUnikId);
        Task<Patient> UpdatePatient(int id, Patient patient);
    }
}