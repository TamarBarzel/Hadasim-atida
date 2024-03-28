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
    public class ManufacterBL : IManufacterBL
    {
        public IMapper _mapper;
        IManufacterDL _manufacterDL;
        public ManufacterBL(IManufacterDL manufacterDL, IMapper mapper)
        {
            _mapper = mapper;
            _manufacterDL = manufacterDL;
        }
        public async Task<List<ManufacterDTO>> GetAllManufacters()
        {
            try
            {
                List<Manufacter> manufacter = await _manufacterDL.GetAllManufacters();
                List<ManufacterDTO> manufacterDTO = _mapper.Map<List<Manufacter>, List<ManufacterDTO>>(manufacter);
                return manufacterDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ManufacterDTO> GetManufacterById(int id)
        {
            Manufacter manufacter = await _manufacterDL.GetManufacterById(id);
            return _mapper.Map<ManufacterDTO>(manufacter);
        }

        public async Task<ManufacterDTO> AddManufacter(ManufacterDTO manufacterDTO)
        {
            try
            {
                Manufacter manufacter = _mapper.Map<Manufacter>(manufacterDTO);
                Manufacter newManufacter = await _manufacterDL.AddManufacter(manufacter);
                return _mapper.Map<ManufacterDTO>(newManufacter);
            }
            catch (Exception ex)
            {

                return null;
            }


        }

        public async Task<ManufacterDTO> UpdateManufacter(int id, ManufacterDTO manufacterDTO)
        {
            Manufacter manufacter = _mapper.Map<Manufacter>(manufacterDTO);
            Manufacter updatedManufacter = await _manufacterDL.UpdateManufacter(id, manufacter);

            return _mapper.Map<ManufacterDTO>(updatedManufacter);
        }

        public async Task<ManufacterDTO> DeleteManufacter(int id)
        {
            Manufacter deletedManufacter = await _manufacterDL.DeleteManufacter(id);

            return _mapper.Map<ManufacterDTO>(deletedManufacter);
        }



    }
}

    



