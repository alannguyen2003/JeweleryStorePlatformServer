using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformService.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService
{
    public class JeweleryTypeService : IJeweleryTypeService
    {
        private readonly AppDbContext _context;

        public JeweleryTypeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<JeweleryType>> GetAllJeweleryType()
        {
            return await _context.JeweleryTypes.ToListAsync();
        }

        public async Task<JeweleryType> GetJeweleryTypeById(int id)
        {
            return await _context.JeweleryTypes.FindAsync(id);
        }

        public async Task<int> AddNewJeweleryType(JeweleryType jeweleryType)
        {
            _context.JeweleryTypes.Add(jeweleryType);
            await _context.SaveChangesAsync();
            return jeweleryType.Id;
        }

        public async Task AddRangeJeweleryType(List<JeweleryType> jeweleryTypes)
        {
            _context.JeweleryTypes.AddRange(jeweleryTypes);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateJeweleryType(JeweleryType jeweleryType)
        {
            _context.Entry(jeweleryType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteJeweleryType(int id)
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