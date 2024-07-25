using JeweleryStorePlatformBusinessObject.Address;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformDataAccess
{
    public class DistrictDAO
    {
        private readonly AppDbContext _context;
        private static DistrictDAO instance;

        public DistrictDAO()
        {
            _context = new AppDbContext();
        }

        public static DistrictDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DistrictDAO();
                }
                return instance;
            }
        }
        public async Task AddRange(IEnumerable<District> districts)
        {
            await _context.Districts.AddRangeAsync(districts);
            await _context.SaveChangesAsync();
        }
        public async Task<List<District>> GetAllDistricts()
        {
            return await _context.Districts.ToListAsync();
        }

        public async Task<List<District>> GetAllDistrictsByProvinceId(int provinceId)
        {
            return await _context.Districts
                .Where(item => item.CityId == provinceId)
                .ToListAsync(); 
        }
    }
}
