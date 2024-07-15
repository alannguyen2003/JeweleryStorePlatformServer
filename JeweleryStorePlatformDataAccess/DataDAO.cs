using Microsoft.EntityFrameworkCore;

namespace JeweleryStorePlatformDataAccess;

public class DataDAO
{
    private readonly AppDbContext _context;
    private static DataDAO instance;
    
    public DataDAO()
    {
        _context = new AppDbContext();
    }

    public static DataDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DataDAO();
            }
            return instance;
        }
    }

    public async Task MigrationAsync()
    {
        await _context.Database.MigrateAsync();
    }
}