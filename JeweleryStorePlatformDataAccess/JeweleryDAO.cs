using JeweleryStorePlatformBusinessObject.Jewelery;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeweleryStorePlatformDataAccess
{
    public class JeweleryDAO
    {
        private readonly AppDbContext _context;
        private static JeweleryDAO _instance;

        private JeweleryDAO()
        {
            _context = new AppDbContext(); // Ensure you have a parameterless constructor or configure DI
        }

        public async Task<List<Jewelery>> GetAllJewelery()
        {
            return await _context.Jeweleries.Include(j => j.JeweleryType).ToListAsync();
        }

        public static JeweleryDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new JeweleryDAO();
                }
                return _instance;
            }
        }

        public async Task<Jewelery> GetById(int jewelryId)
        {
            return await _context.Jeweleries.FindAsync(jewelryId);
        }

        public async Task Add(Jewelery jewelry)
        {
            await _context.Jeweleries.AddAsync(jewelry);
            await _context.SaveChangesAsync();
        }

        public async Task AddRange(List<Jewelery> jewelry)
        {
            await _context.Jeweleries.AddRangeAsync(jewelry);
            await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Jewelery jewelery)
        {
            var existingJewelery = await _context.Jeweleries.FindAsync(jewelery.Id);
            if (existingJewelery == null)
            {
                throw new KeyNotFoundException($"Jewelery with ID {jewelery.Id} not found.");
            }

            // Update properties
            existingJewelery.JeweleryName = jewelery.JeweleryName;
            existingJewelery.JeweleryTypeId = jewelery.JeweleryTypeId;
            // Update other properties as needed

            _context.Jeweleries.Update(existingJewelery);
            return await _context.SaveChangesAsync(); // This will return the number of affected rows
        }

        public async Task<int> Delete(int jeweleryId)
        {
            var jewelry = await _context.Jeweleries.FindAsync(jeweleryId);
            if (jewelry == null)
            {
                return 0; // Or throw an exception if preferred
            }

            _context.Jeweleries.Remove(jewelry);
            return await _context.SaveChangesAsync(); // This will return the number of affected rows
        }
    }
}
