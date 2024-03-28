using CoronaProjectDL.Models;

namespace CoronaProjectDL.Interfaces
{
    public interface IManufacterDL
    {
        Task<Manufacter> AddManufacter(Manufacter manufacter);
        Task<Manufacter> DeleteManufacter(int id);
        Task<List<Manufacter>> GetAllManufacters();
        Task<Manufacter> GetManufacterById(int id);
        Task<Manufacter> GetManufacterByName(string name);
        Task<Manufacter> UpdateManufacter(int id, Manufacter manufacter);
    }
}