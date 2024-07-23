using JeweleryStorePlatformBusinessObject.Diamond;
using Microsoft.EntityFrameworkCore;

namespace JeweleryStorePlatformDataAccess;

public class GIAReportDAO
{
    private readonly AppDbContext _context;
    private static GIAReportDAO instance;

    public GIAReportDAO()
    {
        _context = new AppDbContext();
    }

    public static GIAReportDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GIAReportDAO();
            }
            return instance;
        }
    }

    public IQueryable<GIAReport> GetAll()
    {
        return _context.Set<GIAReport>();
    }
    public async Task<GIAReport> GetById(int id)
    {
        return await _context.Set<GIAReport>().FindAsync(id);
    }

    public async Task<GIAReport> CreateGIAReport(GIAReport giareport)
    {
        _context.Set<GIAReport>().Add(giareport);
        await _context.SaveChangesAsync();
        return giareport;
    }

    public async Task<GIAReport> UpdateGIAReport(GIAReport giareport)
    {
        var existingDiamond = await _context.Set<GIAReport>().FindAsync(giareport.Id);
        if (existingDiamond == null)
        {
            return null;
        }

        _context.Entry(existingDiamond).CurrentValues.SetValues(giareport);
        await _context.SaveChangesAsync();
        return existingDiamond;
    }

    public async Task<bool> DeleteGIAReport(int id)
    {
        var giareport = await _context.Set<GIAReport>().FindAsync(id);
        if (giareport == null)
        {
            return false;
        }

        _context.Set<GIAReport>().Remove(giareport);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task AddRangeGIAReports(List<GIAReport> gIAReports)
    {
        await _context.Set<GIAReport>().AddRangeAsync(gIAReports);
        await _context.SaveChangesAsync();
    }
}