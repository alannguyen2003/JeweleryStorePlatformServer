using JeweleryStorePlatformBusinessObject.Jewelery;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeweleryStorePlatformDataAccess
{
    public class JeweleryTypeDAO
    {
        private readonly AppDbContext _context;
        private static JeweleryTypeDAO instance;

        private JeweleryTypeDAO()
        {
            _context = new AppDbContext();
        }

        public static JeweleryTypeDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JeweleryTypeDAO();
                }
                return instance;
            }
        }

        public IQueryable<JeweleryType> GetAllJeweleryTypes()
        {
            return _context.Set<JeweleryType>();
        }

        public async Task<JeweleryType> GetJeweleryTypeById(int id)
        {
            return await _context.Set<JeweleryType>().FindAsync(id);
        }

        public async Task<JeweleryType> CreateJeweleryType(JeweleryType jeweleryType)
        {
            _context.Set<JeweleryType>().Add(jeweleryType);
            await _context.SaveChangesAsync();
            return jeweleryType;
        }

        public async Task<JeweleryType> UpdateJeweleryType(JeweleryType jeweleryType)
        {
            var existingJeweleryType = await _context.Set<JeweleryType>().FindAsync(jeweleryType.Id);
            if (existingJeweleryType == null)
            {
                return null;
            }

            _context.Entry(existingJeweleryType).CurrentValues.SetValues(jeweleryType);
            await _context.SaveChangesAsync();
            return existingJeweleryType;
        }

        public async Task<bool> DeleteJeweleryType(int id)
        {
            var jeweleryType = await _context.Set<JeweleryType>().FindAsync(id);
            if (jeweleryType == null)
            {
                return false;
            }

            _context.Set<JeweleryType>().Remove(jeweleryType);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task AddRangeJeweleryTypes(List<JeweleryType> jeweleryTypes)
        {
            await _context.Set<JeweleryType>().AddRangeAsync(jeweleryTypes);
            await _context.SaveChangesAsync();
        }
    }
}
