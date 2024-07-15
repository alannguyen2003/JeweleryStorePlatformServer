using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService.Interface;

namespace JeweleryStorePlatformService;

public class DataService : IDataService
{
    private readonly IDataRepository _dataRepository;

    public DataService(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository;
    }
    public async Task MigrationAsync()
    {
        await _dataRepository.MigrationAsync();
    }
}