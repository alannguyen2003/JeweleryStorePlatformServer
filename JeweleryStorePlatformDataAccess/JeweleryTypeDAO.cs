using JeweleryStorePlatformBusinessObject.Jewelery;
using Microsoft.EntityFrameworkCore;

namespace JeweleryStorePlatformDataAccess;

public class JeweleryTypeDAO
{
    private readonly AppDbContext _context;
    private static JeweleryTypeDAO instance;
    
    public JeweleryTypeDAO()
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

    public async Task<List<JeweleryType>> GetAllJeweleryType()
    {
        return await _context.JeweleryTypes.ToListAsync();
    }

    public async Task AddNewJeweleryType(JeweleryType jeweleryType)
    {
        await _context.JeweleryTypes.AddAsync(jeweleryType);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeJeweleryType(List<JeweleryType> jeweleryTypes)
    {
        await _context.JeweleryTypes.AddRangeAsync(jeweleryTypes);
        await _context.SaveChangesAsync();
    }
}