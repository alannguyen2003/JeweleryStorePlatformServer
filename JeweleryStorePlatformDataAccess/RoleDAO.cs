using JeweleryStorePlatformBusinessObject.Account;
using Microsoft.EntityFrameworkCore;

namespace JeweleryStorePlatformDataAccess;

public class RoleDAO
{
    private readonly AppDbContext _context;
    private static RoleDAO instance;
    
    public RoleDAO()
    {
        _context = new AppDbContext();
    }

    public static RoleDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new RoleDAO();
            }
            return instance;
        }
    }

    public async Task<List<Role>> GetAllRoles()
    {
        return await _context.Roles.ToListAsync();
    }

    public async Task AddNewRole(Role role)
    {
        await _context.Roles.AddAsync(role);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeRole(List<Role> roles)
    {
        await _context.Roles.AddRangeAsync(roles);
        await _context.SaveChangesAsync();
    }
}