using CoronaProjectDL.Interfaces;
using CoronaProjectDL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaProjectDL
{
    public class VaccinationDL : IVaccinationDL
    {
        CoronaProjectContext _CoronaProjectContext = new CoronaProjectContext();


        public async Task<List<Vaccination>> GetAllVaccinations()
        {
            List<Vaccination> vaccinationList = await _CoronaProjectContext.Vaccinations.ToListAsync();
            return vaccinationList;
        }

        public async Task<Vaccination> GetVaccinationById(int id)
        {
            return await _CoronaProjectContext.Vaccinations.FirstOrDefaultAsync(item => item.VaccinationId == id);

        }
        public async Task<List<Vaccination>> GetAllVaccinationsByPatientUniqId(int patientUnikId)
        {
            List<Vaccination> vaccinationListByUniqId = await _CoronaProjectContext.Vaccinations.Where(item => item.PatientUnikId == patientUnikId).ToListAsync();
            return vaccinationListByUniqId;
        }


       
        public async Task<Vaccination> AddVaccination(Vaccination vaccination, int patientUnikId)
        {
            try
            {
                // Check if the patient exists
                Patient existingPatient = await _CoronaProjectContext.Patients.FirstOrDefaultAsync(p => p.PatientUnikId == patientUnikId);

                if (existingPatient == null)
                {
                    throw new ArgumentException($"Patient with PatientUnikId {patientUnikId} not found");
                }

                // Check if the patient has reached the maximum limit of 4 vaccinations
                int numOfVaccinations = await _CoronaProjectContext.Vaccinations
                    .CountAsync(v => v.PatientUnikId == patientUnikId);

                if (numOfVaccinations >= 4)
                {
                    throw new InvalidOperationException($"Cannot add vaccination because the maximum limit of 4 vaccinations has been reached for PatientUnikId {patientUnikId}");
                }

                // Add the vaccination to the database
                await _CoronaProjectContext.Vaccinations.AddAsync(vaccination);
                await _CoronaProjectContext.SaveChangesAsync();

                return vaccination;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Vaccination> UpdateVaccination(int id, Vaccination vaccination)
        {
            try
            {
                Vaccination currentVaccinationToUpdate = await _CoronaProjectContext.Vaccinations.FirstOrDefaultAsync(v => v.VaccinationId == id);

                if (currentVaccinationToUpdate == null)
                    throw new ArgumentException($"Vaccination with ID {id} not found");

                // Check if the number of vaccinations for the same patient exceeds 4
                int patientUnikId = currentVaccinationToUpdate.PatientUnikId;
                int numOfVaccinations = await _CoronaProjectContext.Vaccinations.CountAsync(v => v.PatientUnikId == patientUnikId);

                if (numOfVaccinations >= 4)
                {
                    throw new InvalidOperationException($"Cannot update vaccination because the patient already has 4 vaccinations");
                }
                // Check if the PatientUnikId parameter has changed
                if (vaccination.PatientUnikId != currentVaccinationToUpdate.PatientUnikId)
                {
                    throw new InvalidOperationException($"Cannot update PatientUnikId");
                }

                currentVaccinationToUpdate.ManufacterId = vaccination.ManufacterId;
                currentVaccinationToUpdate.VaccinationDate = vaccination.VaccinationDate;
                currentVaccinationToUpdate.PatientUnikId = vaccination.PatientUnikId;

                await _CoronaProjectContext.SaveChangesAsync();

                return currentVaccinationToUpdate;
            }
            catch (Exception ex)
            {
                throw ex;


            }


        }

        public async Task<Vaccination> DeleteVaccination(int vaccinationId)
        {
            try
            {
                Vaccination vaccinationToDelete = await _CoronaProjectContext.Vaccinations.FirstOrDefaultAsync(v => v.VaccinationId == vaccinationId);
                if (vaccinationToDelete == null)
                    throw new ArgumentException($"Vaccination with ID {vaccinationId} not found");

                _CoronaProjectContext.Vaccinations.Remove(vaccinationToDelete);
                await _CoronaProjectContext.SaveChangesAsync();

                return vaccinationToDelete;

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }


        public async Task<List<Vaccination>> DeleteAllVaccinationsByPatientUniqId(int patientUnikId)
        {
            try
            {
                List<Vaccination> vaccinationsToDelete = await _CoronaProjectContext.Vaccinations.Where(v => v.PatientUnikId == patientUnikId).ToListAsync();
                if (vaccinationsToDelete == null || !vaccinationsToDelete.Any())
                    throw new ArgumentException($"No vaccinations found for patient with PatientUnikId {patientUnikId}");

                _CoronaProjectContext.Vaccinations.RemoveRange(vaccinationsToDelete);
                await _CoronaProjectContext.SaveChangesAsync();

                return vaccinationsToDelete;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}



