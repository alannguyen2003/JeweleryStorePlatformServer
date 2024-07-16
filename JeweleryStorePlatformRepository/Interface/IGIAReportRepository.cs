
using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformDataAccess;

namespace JeweleryStorePlatformRepository.Interface;

public interface IGIAReportRepository
{
    public IQueryable<GIAReport> GetAll();
    Task<GIAReport> GetGIAById(int id);
    Task<GIAReport> CreateGIA(GIAReport giareport);
    Task<GIAReport> UpdateGIA(GIAReport giareport);
    Task<bool> DeleteGIA(int id);
}