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

    public IQueryable<DiamondEntity> GetAllDiamonds()
    {
        return _context.Set<DiamondEntity>();
    }

}