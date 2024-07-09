using JeweleryStorePlatformBusinessObject.Account;
using Microsoft.EntityFrameworkCore;

namespace JeweleryStorePlatformDataAccess;

public class AccountDAO
{
    private readonly AppDbContext _context;
    private static AccountDAO instance;
    
    public AccountDAO()
    {
        _context = new AppDbContext();
    }

    public static AccountDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AccountDAO();
            }
            return instance;
        }
    }

    public async Task<List<Account>> GetAllAccount()
    {
        return await _context.Accounts.ToListAsync();
    }

    public async Task AddNewAccount(Account account)
    {
        await _context.Accounts.AddAsync(account);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeAccount(List<Account> accounts)
    {
        await _context.Accounts.AddRangeAsync(accounts);
        await _context.SaveChangesAsync();
    }
}