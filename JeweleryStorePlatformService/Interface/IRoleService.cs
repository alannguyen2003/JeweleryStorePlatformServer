using JeweleryStorePlatformBusinessObject.Account;

namespace JeweleryStorePlatformService.Interface;

public interface IRoleService
{
    public Task<List<Role>> GetAllRoles();
    public Task AddNewRole(Role role);
    public Task AddRangeRoles(List<Role> roles);
}