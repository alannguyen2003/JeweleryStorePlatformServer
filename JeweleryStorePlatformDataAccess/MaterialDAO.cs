using JeweleryStorePlatformBusinessObject.Jewelery;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformDataAccess
{
    public class MaterialDAO
    {
        private readonly AppDbContext _context;
        private static MaterialDAO instance;

        public MaterialDAO()
        {
            _context = new AppDbContext();
        }

        public static MaterialDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MaterialDAO();
                }
                return instance;
            }
        }
        public async Task AddRange(IEnumerable<Material> materials)
        {
            await _context.Materials.AddRangeAsync(materials);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Material>> GetAllMaterials()
        {
            return await _context.Materials.ToListAsync();
        }
    }
}
