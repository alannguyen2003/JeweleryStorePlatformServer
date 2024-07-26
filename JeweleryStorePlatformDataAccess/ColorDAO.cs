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
    public class ColorDAO
    {
        private readonly AppDbContext _context;
        private static ColorDAO instance;

        public ColorDAO()
        {
            _context = new AppDbContext();
        }

        public static ColorDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ColorDAO();
                }
                return instance;
            }
        }
        public async Task AddRange(IEnumerable<Color> colors)
        {
            await _context.Colors.AddRangeAsync(colors);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Color>> GetAllColors()
        {
            return await _context.Colors.ToListAsync();
        }
        public async Task<Color?> GetById(int color)
        {
            return await _context.Colors.FindAsync(color);
        }
    }
}
