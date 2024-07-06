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

        public async Task<List<JeweleryEntity>> GetAllJewelery()
        {
            return await _context.Jeweleries.ToListAsync();
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

        public async Task<JeweleryEntity> GetById(int jewelryId)
        {
            return await _context.Jeweleries.FindAsync(jewelryId);
        }

        public async Task Add(JeweleryEntity jewelry)
        {
            await _context.Jeweleries.AddAsync(jewelry);
            await _context.SaveChangesAsync();
        }

        public async Task AddRange(List<JeweleryEntity> jewelry)
        {
            await _context.Jeweleries.AddRangeAsync(jewelry);
            await _context.SaveChangesAsync();
        }

        public async Task Update(JeweleryEntity jewelry)
        {
            _context.Jeweleries.Update(jewelry);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int jewelryId)
        {
            var jewelry = await _context.Jeweleries.FindAsync(jewelryId);
            if (jewelry != null)
            {
                _context.Jeweleries.Remove(jewelry);
                await _context.SaveChangesAsync();
            }
        }
    }
}
