using CoronaProjectDL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaProjectDL.Interfaces;


namespace CoronaProjectDL

{
    public class PatientDL : IPatientDL
    {
        CoronaProjectContext _CoronaProjectContext = new CoronaProjectContext();



        public async Task<List<Patient>> GetAllPatients()
        {
            List<Patient> patientsList = await _CoronaProjectContext.Patients.ToListAsync();
            return patientsList;
        }
        public async Task<List<Patient>> GetAllPatientsByCity(string cityName)
        {
            List<Patient> patientsListByCity = await _CoronaProjectContext.Patients.Where(item => item.CityName == cityName).ToListAsync();
            return patientsListByCity;
        }
        public async Task<List<Patient>> GetAllPatientsByInfectedCorona(bool infectedCorona)
        {
            List<Patient> patientsListByInfectedCorona = await _CoronaProjectContext.Patients.Where(item => item.InfectedCorona == infectedCorona).ToListAsync();
            return patientsListByInfectedCorona;
        }
        public async Task<List<Patient>> GetAllPatientsByUnrecoveryCorona(bool infectedCorona)
        {
            DateOnly currentDay = DateOnly.FromDateTime(DateTime.Now);
            List<Patient> patientsByUnrecoveryCorona = await _CoronaProjectContext.Patients.Where(item => item.InfectedCorona == true && (item.RecoveryDate==null || item.RecoveryDate > currentDay)).ToListAsync();
   
         return patientsByUnrecoveryCorona;
        }
        public async Task<Patient> AddPatient(Patient patient)
        {
            try
            {
                Patient existingPatient = await GetPatientByPatientUnikId(patient.PatientUnikId);
                if (existingPatient != null)
                {
                    throw new ArgumentException($"Patient with PatientUnikId {patient.PatientUnikId} already exists");
                }
                if (patient.InfectedCorona==true)
                {
                    if (patient.InfectedDate == null)
                    {
                        throw new ArgumentException("Infected patients require both InfectedDate");
                    }
                }
                else
                {
                    // Reset infection and recovery dates if patient is not marked as infected
                    patient.InfectedDate = null;
                    patient.RecoveryDate = null;
                }

                await _CoronaProjectContext.Patients.AddAsync(patient);
                await _CoronaProjectContext.SaveChangesAsync();
                Patient newPatient = await _CoronaProjectContext.Patients.OrderByDescending(item => item.PatientId).FirstOrDefaultAsync();
                return newPatient;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }
        public async Task<Patient> UpdatePatient(int id, Patient patient)
        {
            try
            {
                Patient currentPatientToUpdate = await _CoronaProjectContext.Patients.FirstOrDefaultAsync(item => item.PatientId == id);

                if (currentPatientToUpdate == null)
                    throw new ArgumentException($"{id} is not found");

                // Check if the patient is marked as infected
                if (patient.InfectedCorona==true)
                {
                    // Validate the infection and recovery dates
                    if (patient.InfectedDate == null)
                    {
                        throw new ArgumentException("Infected patient must have infection date specified");
                    }
                }
                else
                {
                    // Reset infection and recovery dates if patient is not marked as infected
                    patient.InfectedDate = null;
                    patient.RecoveryDate = null;
                }

                // Get the number of vaccinations associated with the patient's PatientUnikId
                int numOfVaccinations = await _CoronaProjectContext.Vaccinations
                    .CountAsync(v => v.PatientUnikId == currentPatientToUpdate.PatientUnikId);

                // Check if the number of vaccinations exceeds 4
                if (numOfVaccinations >= 4)
                {
                    throw new InvalidOperationException("Cannot update patient because there are already 4 or more vaccinations");
                }

                // Update patient's information
                currentPatientToUpdate.FirstName = patient.FirstName;
                currentPatientToUpdate.LastName = patient.LastName;
                currentPatientToUpdate.CityName = patient.CityName;
                currentPatientToUpdate.Street = patient.Street;
                currentPatientToUpdate.BirthDate = patient.BirthDate;
                currentPatientToUpdate.Phone = patient.Phone;
                currentPatientToUpdate.Mobile = patient.Mobile;
                currentPatientToUpdate.InfectedCorona = patient.InfectedCorona;
                currentPatientToUpdate.InfectedDate = patient.InfectedDate;
                currentPatientToUpdate.RecoveryDate = patient.RecoveryDate;
                currentPatientToUpdate.PatientUnikId = patient.PatientUnikId;

                await _CoronaProjectContext.SaveChangesAsync();
                return currentPatientToUpdate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    
        public async Task<Patient> DeletePatient(int id)
        {
            try
            {
                // Get the patient to be deleted
                Patient currentPatientToDelete = await _CoronaProjectContext.Patients.FirstOrDefaultAsync(item => item.PatientId == id);

                if (currentPatientToDelete == null)
                    throw new ArgumentException($"{id} is not found");

                // Get the number of vaccinations associated with the patient's PatientUnikId
                int numOfVaccinations = await _CoronaProjectContext.Vaccinations
                    .CountAsync(v => v.PatientUnikId == currentPatientToDelete.PatientUnikId);

                // Check if there are any vaccinations associated with the patient
                if (numOfVaccinations > 0)
                {
                    throw new InvalidOperationException("Cannot delete patient because there are associated vaccinations");
                }

                // No vaccinations associated with the patient, delete the patient
                _CoronaProjectContext.Patients.Remove(currentPatientToDelete);
                await _CoronaProjectContext.SaveChangesAsync();

                return currentPatientToDelete;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Patient> GetPatientById(int id)
        {
            return await _CoronaProjectContext.Patients.FirstOrDefaultAsync(item => item.PatientId == id);
        }
        public async Task<Patient> GetPatientByLastName(string lastName)
        {
            return await _CoronaProjectContext.Patients.FirstOrDefaultAsync(item => item.LastName == lastName);
        }
        public async Task<Patient> GetPatientByPatientUnikId(int patientUnikId)
        {
            return await _CoronaProjectContext.Patients.FirstOrDefaultAsync(item => item.PatientUnikId == patientUnikId);
        }
    }
}

