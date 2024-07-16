using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformRepository.Interface;

namespace JeweleryStorePlatformRepository;

public class GIAReportRepository : IGIAReportRepository
{
    public IQueryable<GIAReport> GetAll()
    {
        return GIAReportDAO.Instance.GetAll();
    }
    public async Task<GIAReport> GetGIAById(int id)
    {
        return await GIAReportDAO.Instance.GetById(id);
    }

    public async Task<GIAReport> CreateGIA(GIAReport GIAReport)
    {
        return await GIAReportDAO.Instance.CreateGIAReport(GIAReport);
    }

    public async Task<GIAReport> UpdateGIA(GIAReport GIAReport)
    {
        return await GIAReportDAO.Instance.UpdateGIAReport(GIAReport);
    }

    public async Task<bool> DeleteGIA(int id)
    {
        return await GIAReportDAO.Instance.DeleteGIAReport(id);
    }
}