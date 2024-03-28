using AutoMapper;
using CoronaProjectBL.Interfaces;
using CoronaProjectDL.Interfaces;
using CoronaProjectDL.Models;
using CoronaProjectDTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaProjectBL
{
    public class PatientBL : IPatientBL
    {
        public IMapper _mapper;
        IPatientDL _patientDL;
        public PatientBL(IPatientDL patientDL, IMapper mapper)
        {
            _mapper = mapper;
            _patientDL = patientDL;
        }
        public async Task<List<PatientDTO>> GetAllPatients()
        {
            try
            {
                List<Patient> patient = await _patientDL.GetAllPatients();
                List<PatientDTO> patientDTO = _mapper.Map<List<Patient>, List<PatientDTO>>(patient);
                return patientDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<PatientDTO>> GetAllPatientsByCity(string cityName)

        {
            try
            {
                List<Patient> patient = await _patientDL.GetAllPatientsByCity(cityName);
                List<PatientDTO> patientDTO = _mapper.Map<List<Patient>, List<PatientDTO>>(patient);
                return patientDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<PatientDTO>> GetAllPatientsByInfectedCorona(bool infectedCorona)

        {
            try
            {
                List<Patient> patient = await _patientDL.GetAllPatientsByInfectedCorona(infectedCorona);
                List<PatientDTO> patientDTO = _mapper.Map<List<Patient>, List<PatientDTO>>(patient);
                return patientDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<PatientDTO>> GetAllPatientsByUnrecoveryCorona(bool infectedCorona)
        {
            try
            {
                List<Patient> patient = await _patientDL.GetAllPatientsByUnrecoveryCorona(infectedCorona);
                List<PatientDTO> patientDTO = _mapper.Map<List<Patient>, List<PatientDTO>>(patient);
                return patientDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
         public async Task<PatientDTO> GetPatientById(int id)
        {
            Patient patient = await _patientDL.GetPatientById(id);
            return _mapper.Map<PatientDTO>(patient);
        }
        public async Task<PatientDTO> GetPatientByLastName(string lastName)
        {
            Patient patient = await _patientDL.GetPatientByLastName(lastName);
            return _mapper.Map<PatientDTO>(patient);
        }
        public async Task<PatientDTO> GetPatientByPatientUnikId(int patientUnikId)
        {
            Patient patient = await _patientDL.GetPatientByPatientUnikId(patientUnikId);
            return _mapper.Map<PatientDTO>(patient);
        }



        public async Task<PatientDTO> AddPatient(PatientDTO patientDTO)
        {
            try
            {
                Patient patient = _mapper.Map<Patient>(patientDTO);
                Patient newPatient = await _patientDL.AddPatient(patient);
                return _mapper.Map<PatientDTO>(newPatient);
            }
            catch (Exception ex)
            {

                return null;
            }


        }

        public async Task<PatientDTO> UpdatePatient(int id, PatientDTO patientDTO)
        {
            Patient patient = _mapper.Map<Patient>(patientDTO);
            Patient updatedPatient = await _patientDL.UpdatePatient(id, patient);

            return _mapper.Map<PatientDTO>(updatedPatient);
        }

        public async Task<PatientDTO> DeletePatient(int id)
        {
            Patient deletedPatient = await _patientDL.DeletePatient(id);

            return _mapper.Map<PatientDTO>(deletedPatient);
        }

       

    }
}

    

