using JeweleryStorePlatformBusinessObject.Address;
using JeweleryStorePlatformBusinessObject.Design;
using JeweleryStorePlatformBusinessObject.Jewelery;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformDataAccess
{
    public class CityDAO
    {
        private readonly AppDbContext _context;
        private static CityDAO instance;

        public CityDAO()
        {
            _context = new AppDbContext();
        }

        public static CityDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CityDAO();
                }
                return instance;
            }
        }
        public async Task AddRange(IEnumerable<City> city)
        {
            await _context.Cities.AddRangeAsync(city);
            await _context.SaveChangesAsync();
        }
        public async Task<List<City>> GetAllCities()
        {
            return await _context.Cities.ToListAsync();
        }
    }
}
