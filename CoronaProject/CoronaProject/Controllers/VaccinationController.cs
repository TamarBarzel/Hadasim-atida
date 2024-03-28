using CoronaProjectBL.Interfaces;
using CoronaProjectDTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationController : ControllerBase
    {
        IVaccinationBL _vaccinationBL;
        public VaccinationController(IVaccinationBL vaccinationBL)
        {
            _vaccinationBL = vaccinationBL;
        }

        // GET: api/<VaccinationController>
        [HttpGet("GetAllVaccinations")]
        
        public async Task<List<VaccinationDTO>> GetAllVaccinations()
        {     
             return await _vaccinationBL.GetAllVaccinations();
        }

        // GET api/<VaccinationController>
        [HttpGet("GetVaccinationById/{id}")]
        
        public async Task<VaccinationDTO> GetVaccinationById(int id)
        {
            return await _vaccinationBL.GetVaccinationById(id);
        }
        // GET api/<VaccinationController>
        [HttpGet("GetAllVaccinationsByPatientUniqId/{patientUnikId}")]

        public async Task<List<VaccinationDTO>> GetAllVaccinationsByPatientUniqId(int patientUnikId)
        {
            return await _vaccinationBL.GetAllVaccinationsByPatientUniqId(patientUnikId);
        }



        // POST api/<VaccinationController>
        [HttpPost]
        public async Task<VaccinationDTO> AddVaccination([FromBody] VaccinationDTO vaccinationDTO, int patientUnikId)
        {
            VaccinationDTO newVaccination = await _vaccinationBL.AddVaccination(vaccinationDTO, patientUnikId);
            return newVaccination;
        }



        // PUT api/<VaccinationController>
        [HttpPut("{id}")]
        public async Task<VaccinationDTO> UpdateVaccination(int id, [FromBody] VaccinationDTO vaccinationDTO)
        {
            VaccinationDTO isUpdate = await _vaccinationBL.UpdateVaccination(id, vaccinationDTO);
            return isUpdate;
        }


        // DELETE api/<VaccinationController>
        [HttpDelete("{id}")]
        public async Task<VaccinationDTO> DeleteVaccination(int vaccinationId)
        {
            VaccinationDTO isDelete = await _vaccinationBL.DeleteVaccination(vaccinationId);
            return isDelete;
        }


        // DELETE api/<VaccinationController>
        [HttpDelete("DeleteAllVaccinationsByPatientUniqId/{patientUnikId}")]

        public async Task<List<VaccinationDTO>> DeleteAllVaccinationsByPatientUniqId(int patientUnikId)
        {
            try
            {
                List<VaccinationDTO> deletedVaccinations = await _vaccinationBL.DeleteAllVaccinationsByPatientUniqId(patientUnikId);
                return deletedVaccinations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

