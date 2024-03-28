using CoronaProjectBL.Interfaces;
using CoronaProjectDTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoronaProject.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ManufacterController : ControllerBase
    {
        IManufacterBL _manufacterBL;
        public ManufacterController(IManufacterBL manufacterBL)
        {
            _manufacterBL = manufacterBL;
        }

        // GET: api/<ManufacterController>
        [HttpGet]
        [Route("GetAllManufacters")]
        public async Task<List<ManufacterDTO>> GetAllManufacters()
        {
            return await _manufacterBL.GetAllManufacters();
        }

        // GET api/<ManufacterController>
        [HttpGet("GetManufacterById/{id}")]
        public async Task<ManufacterDTO> GetManufacterById(int id)
        {
            return await _manufacterBL.GetManufacterById(id);
        }


        // POST api/<ManufacterController>
        [HttpPost]
        public async Task<ManufacterDTO> AddManufacter([FromBody] ManufacterDTO manufacterDTO)
        {
            ManufacterDTO newManufacter = await _manufacterBL.AddManufacter(manufacterDTO);
            return newManufacter;
        }



        // PUT api/<ManufacterController>
        [HttpPut("{id}")]
        public async Task<ManufacterDTO> UpdateManufacter(int id, [FromBody] ManufacterDTO manufacterDTO)
        {
            ManufacterDTO isUpdate = await _manufacterBL.UpdateManufacter(id, manufacterDTO);
            return isUpdate;
        }


        // DELETE api/<ManufacterController>
        [HttpDelete("{id}")]
        public async Task<ManufacterDTO> DeleteManufacter(int id)
        {
            ManufacterDTO isDelete = await _manufacterBL.DeleteManufacter(id);
            return isDelete;
        }
    }
        
}
