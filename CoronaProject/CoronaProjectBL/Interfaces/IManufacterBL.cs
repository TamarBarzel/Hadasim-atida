using CoronaProjectDTO.DTO;

namespace CoronaProjectBL.Interfaces
{
    public interface IManufacterBL
    {
        Task<ManufacterDTO> AddManufacter(ManufacterDTO manufacterDTO);
        Task<ManufacterDTO> DeleteManufacter(int id);
        Task<List<ManufacterDTO>> GetAllManufacters();
        Task<ManufacterDTO> GetManufacterById(int id);
        Task<ManufacterDTO> UpdateManufacter(int id, ManufacterDTO manufacterDTO);
    }
}