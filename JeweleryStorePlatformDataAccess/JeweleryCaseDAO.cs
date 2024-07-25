using JeweleryStorePlatformBusinessObject.Address;
using JeweleryStorePlatformBusinessObject.Jewelery;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformDataAccess
{
    public class JeweleryCaseDAO
    {
        private readonly AppDbContext _context;
        private static JeweleryCaseDAO _instance;

        private JeweleryCaseDAO()
        {
            _context = new AppDbContext();
        }

        public async Task<List<JeweleryCase>> GetAll()
        {
            return await _context.JeweleryCases.Include(j => j.Color).Include(j => j.Material).ToListAsync();
        }

        public static JeweleryCaseDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new JeweleryCaseDAO();
                }
                return _instance;
            }
        }

        public async Task<JeweleryCase?> GetById(int jeweleryCaseId)
        {
            return await _context.JeweleryCases.FindAsync(jeweleryCaseId);
        }

        public async Task Add(JeweleryCase jewelry)
        {
            await _context.JeweleryCases.AddAsync(jewelry);
            await _context.SaveChangesAsync();
        }

        public async Task AddRange(List<JeweleryCase> jewelry)
        {
            await _context.JeweleryCases.AddRangeAsync(jewelry);
            await _context.SaveChangesAsync();
        }

        public async Task<int> Update(JeweleryCase jewelery)
        {
            var existingJewelery = await _context.JeweleryCases.FindAsync(jewelery.Id);
            if (existingJewelery == null)
            {
                throw new KeyNotFoundException($"JeweleryCase with ID {jewelery.Id} not found.");
            }

            // Update properties
            existingJewelery.CaseName = jewelery.CaseName;
            existingJewelery.ColorId = jewelery.ColorId;
            existingJewelery.MaterialId = jewelery.MaterialId;
            // Update other properties as needed

            _context.JeweleryCases.Update(existingJewelery);
            return await _context.SaveChangesAsync(); // This will return the number of affected rows
        }

        public async Task<int> Delete(int jeweleryId)
        {
            var jewelry = await _context.JeweleryCases.FindAsync(jeweleryId);
            if (jewelry == null)
            {
                return 0; // Or throw an exception if preferred
            }

            _context.JeweleryCases.Remove(jewelry);
            return await _context.SaveChangesAsync(); // This will return the number of affected rows
        }
        public async Task AddRange(IEnumerable<JeweleryCase> jeweleryCases)
        {
            await _context.JeweleryCases.AddRangeAsync(jeweleryCases);
            await _context.SaveChangesAsync();
        }
    }
}
