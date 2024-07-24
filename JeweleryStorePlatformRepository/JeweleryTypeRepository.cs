using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository
{
    public class JeweleryTypeRepository : IJeweleryTypeRepository
    {
        private readonly AppDbContext _context;

        public JeweleryTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<JeweleryType> GetAllJeweleryTypes()
        {
            return _context.JeweleryTypes.AsNoTracking();
        }

        public async Task<JeweleryType> GetJeweleryTypeByIdAsync(int id)
        {
            return await _context.JeweleryTypes.FindAsync(id);
        }

        public async Task AddNewJeweleryTypeAsync(JeweleryType jeweleryType)
        {
            await _context.JeweleryTypes.AddAsync(jeweleryType);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeJeweleryTypesAsync(List<JeweleryType> jeweleryTypes)
        {
            await _context.JeweleryTypes.AddRangeAsync(jeweleryTypes);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateJeweleryTypeAsync(JeweleryType jeweleryType)
        {
            _context.JeweleryTypes.Update(jeweleryType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteJeweleryTypeAsync(int id)
        {
            var jeweleryType = await _context.JeweleryTypes.FindAsync(id);
            if (jeweleryType != null)
            {
                _context.JeweleryTypes.Remove(jeweleryType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
