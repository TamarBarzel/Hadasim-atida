using CoronaProjectBL.Interfaces;
using CoronaProjectDTO.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CoronaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        

            IPatientBL _patientBL;
            public PatientController(IPatientBL patientBL)
            {
                _patientBL = patientBL;
            }

            // GET: api/<PatientController>
            [HttpGet]
            public async Task<List<PatientDTO>> GetAllPatients()
            {
                return await _patientBL.GetAllPatients();
            }

            // GET: api/<PatientController>
            [HttpGet("GetAllPatientsByCity/{cityName}")]
            public async Task<List<PatientDTO>> GetAllPatientsByCity(string cityName)
            {
                return await _patientBL.GetAllPatientsByCity(cityName);
            }
            // GET: api/<PatientController>
            [HttpGet("GetAllPatientsByInfectedCorona/{InfectedCorona}")]
            public async Task<List<PatientDTO>> GetAllPatientsByInfectedCorona(bool infectedCorona)
            {
                return await _patientBL.GetAllPatientsByInfectedCorona(infectedCorona);
            }
            // GET: api/<PatientController>
            [HttpGet("GetAllPatientsByUnrecoveryCorona/{infectedCorona}")]
            public async Task<List<PatientDTO>> GetAllPatientsByUnrecoveryCorona(bool infectedCorona)
            {
                return await _patientBL.GetAllPatientsByUnrecoveryCorona(infectedCorona );
            }


            // GET api/<PatientController>
            [HttpGet("GetPatientById/{id}")]
            public async Task<PatientDTO> GetPatientById(int id)
            {
                return await _patientBL.GetPatientById(id);
            }
            // GET api/<PatientController>
            [HttpGet("GetPatientByLastName/{lastName}")]
            public async Task<PatientDTO> GetPatientByLastName(string lastName)
            {
                return await _patientBL.GetPatientByLastName(lastName);
            }
            // GET api/<PatientController>
            [HttpGet("GetPatientByPatientUnikId/{patientUnikId}")]
            public async Task<PatientDTO> GetPatientByPatientUnikId(int patientUnikId)
            {
                return await _patientBL.GetPatientByPatientUnikId(patientUnikId);
            }
       

            // POST api/<PatientController>
            [HttpPost]
            public async Task<PatientDTO> AddPatient([FromBody] PatientDTO patientDTO)
            {
                PatientDTO newPatient = await _patientBL.AddPatient(patientDTO);
                return newPatient;
            }

            // PUT api/<PatientController>
            [HttpPut("{id}")]
            public async Task<PatientDTO> UpdatePatient(int id, [FromBody] PatientDTO patientDTO)
            {
                PatientDTO isUpdate = await _patientBL.UpdatePatient(id, patientDTO);
                return isUpdate;
            }

            // DELETE api/<PatientController>
            [HttpDelete("{id}")]
            public async Task<PatientDTO> DeletePatient(int id)
            {
                PatientDTO isDelete = await _patientBL.DeletePatient(id);
                return isDelete;
            }
        }
    }

