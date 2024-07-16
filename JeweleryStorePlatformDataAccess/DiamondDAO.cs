using JeweleryStorePlatformBusinessObject.Diamond;
using Microsoft.EntityFrameworkCore;

namespace JeweleryStorePlatformDataAccess;

public class DiamondDAO
{
    private readonly AppDbContext _context;
    private static DiamondDAO instance;
    
    public DiamondDAO()
    {
        _context = new AppDbContext();
    }

    public static DiamondDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DiamondDAO();
            }
            return instance;
        }
    }

    public IQueryable<Diamond> GetAllDiamonds()
    {
        return _context.Set<Diamond>();

    }
    public async Task<Diamond> GetDiamondById(int id)
    {
        return await _context.Set<Diamond>().FindAsync(id);

    }

    public async Task<Diamond> CreateDiamond(Diamond diamond)
    {
        _context.Set<Diamond>().Add(diamond);
        await _context.SaveChangesAsync();
        return diamond;
    }

    public async Task<Diamond> UpdateDiamond(Diamond diamond)
    {
        var existingDiamond = await _context.Set<Diamond>().FindAsync(diamond.Id);
        if (existingDiamond == null)
        {
            return null;
        }

        _context.Entry(existingDiamond).CurrentValues.SetValues(diamond);
        await _context.SaveChangesAsync();
        return existingDiamond;
    }

    public async Task<bool> DeleteDiamond(int id)
    {
        var diamond = await _context.Set<Diamond>().FindAsync(id);
        if (diamond == null)
        {
            return false;
        }

        _context.Set<Diamond>().Remove(diamond);
        await _context.SaveChangesAsync();
        return true;
    }
}