using AutoMapper;
using CoronaProjectBL.Interfaces;
using CoronaProjectDL;
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
    public class VaccinationBL : IVaccinationBL
    {
        public IMapper _mapper;
        IVaccinationDL _vaccinationDL;

        public VaccinationBL(IVaccinationDL vaccinationDL, IMapper mapper)
        {
            _mapper = mapper;
            _vaccinationDL = vaccinationDL;
        }
        public async Task<List<VaccinationDTO>> GetAllVaccinations()
        {
            try
            {
                List<Vaccination> vaccination = await _vaccinationDL.GetAllVaccinations();
                List<VaccinationDTO> vaccinationDTO = _mapper.Map<List<Vaccination>, List<VaccinationDTO>>(vaccination);
                return vaccinationDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<VaccinationDTO> GetVaccinationById(int id)
        {
            Vaccination vaccination = await _vaccinationDL.GetVaccinationById(id);
            return _mapper.Map<VaccinationDTO>(vaccination);
        }

        public async Task<List<VaccinationDTO>> GetAllVaccinationsByPatientUniqId(int patientUnikId)
        {
            try
            {
                List<Vaccination> vaccination = await _vaccinationDL.GetAllVaccinationsByPatientUniqId(patientUnikId);
                List<VaccinationDTO> vaccinationDTO = _mapper.Map<List<Vaccination>, List<VaccinationDTO>>(vaccination);
                return vaccinationDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }





        public async Task<VaccinationDTO> AddVaccination(VaccinationDTO vaccinationDTO, int patientUnikId)
        {
            try
            {
                Vaccination vaccination = _mapper.Map<Vaccination>(vaccinationDTO);
                Vaccination newVaccination = await _vaccinationDL.AddVaccination(vaccination, patientUnikId);
                return _mapper.Map<VaccinationDTO>(newVaccination);
            }
            catch (Exception ex)
            {

                return null;
            }


        }

        public async Task<VaccinationDTO> UpdateVaccination(int id, VaccinationDTO vaccinationDTO)
        {
            Vaccination vaccination = _mapper.Map<Vaccination>(vaccinationDTO);
            Vaccination updatedVaccination = await _vaccinationDL.UpdateVaccination(id, vaccination);

            return _mapper.Map<VaccinationDTO>(updatedVaccination);
        }

        public async Task<VaccinationDTO> DeleteVaccination(int vaccinationId)
        {
            Vaccination deletedVaccination = await _vaccinationDL.DeleteVaccination(vaccinationId);

            return _mapper.Map<VaccinationDTO>(deletedVaccination);
        }


        public async Task<List<VaccinationDTO>> DeleteAllVaccinationsByPatientUniqId(int patientUnikId)
        {
            try
            {
                List<Vaccination> vaccinationsToDelete = await _vaccinationDL.DeleteAllVaccinationsByPatientUniqId(patientUnikId);
                List<VaccinationDTO> vaccinationDTO = _mapper.Map<List<Vaccination>, List<VaccinationDTO>>(vaccinationsToDelete);
                return vaccinationDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}



