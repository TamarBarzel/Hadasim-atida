using CoronaProjectDL.Interfaces;
using CoronaProjectDL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaProjectDL
{
    public class ManufacterDL : IManufacterDL
    {
        CoronaProjectContext _coronaProjectContext = new CoronaProjectContext();

        public async Task<List<Manufacter>> GetAllManufacters()
        {
            List<Manufacter> manufacters = await _coronaProjectContext.Manufacters.ToListAsync();
            return manufacters;
        }
        public async Task<Manufacter> GetManufacterById(int id)
        {
            return await _coronaProjectContext.Manufacters.FirstOrDefaultAsync(item => item.ManufacterId == id);
        }
        public async Task<Manufacter> GetManufacterByName(string name)
        {
            return await _coronaProjectContext.Manufacters.FirstOrDefaultAsync(item => item.ManufacterName == name);
        }

        public async Task<Manufacter> AddManufacter(Manufacter manufacter)
        {
            try
            {
                await _coronaProjectContext.Manufacters.AddAsync(manufacter);
                await _coronaProjectContext.SaveChangesAsync();

                Manufacter newManufacter = await _coronaProjectContext.Manufacters.OrderByDescending(item => item.ManufacterId).FirstOrDefaultAsync();
                return newManufacter;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Manufacter> UpdateManufacter(int id, Manufacter manufacter)
        {
            try
            {
                Manufacter currentManufacterToUpdate = await _coronaProjectContext.Manufacters.Where(item => item.ManufacterId == id).FirstOrDefaultAsync();

                if (currentManufacterToUpdate == null)
                    throw new ArgumentException($"{id} is not found");

                currentManufacterToUpdate.ManufacterName = manufacter.ManufacterName;

                await _coronaProjectContext.SaveChangesAsync();
                return currentManufacterToUpdate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Manufacter> DeleteManufacter(int id)
        {
            try
            {
                Manufacter currentManufacterToDelete = await _coronaProjectContext.Manufacters.SingleOrDefaultAsync(item => item.ManufacterId == id);

                if (currentManufacterToDelete == null)
                    throw new ArgumentException($"{id} is not found");

                _coronaProjectContext.Manufacters.Remove(currentManufacterToDelete);
                await _coronaProjectContext.SaveChangesAsync();
                return currentManufacterToDelete;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}

