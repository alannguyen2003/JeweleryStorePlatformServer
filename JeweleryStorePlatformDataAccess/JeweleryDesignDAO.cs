using JeweleryStorePlatformBusinessObject.Design;
using JeweleryStorePlatformBusinessObject.Jewelery;
using Microsoft.EntityFrameworkCore;

namespace JeweleryStorePlatformDataAccess;

public class JeweleryDesignDAO
{
    private readonly AppDbContext _context;
    private static JeweleryDesignDAO instance;

    public JeweleryDesignDAO()
    {
        _context = new AppDbContext();
    }

    public static JeweleryDesignDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new JeweleryDesignDAO();
            }
            return instance;
        }
    }
    public async Task<List<JeweleryDesign>> GetAllJeweleryDesign()
    {
        return await _context.JeweleryDesigns.ToListAsync();
    }

    public async Task<JeweleryDesign> AddNewJeweleryDesign(JeweleryDesign jeweleryDesign)
    {
        _context.Set<JeweleryDesign>().Add(jeweleryDesign);
        await _context.SaveChangesAsync();
        return jeweleryDesign;
    }

}