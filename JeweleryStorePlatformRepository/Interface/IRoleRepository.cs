using JeweleryStorePlatformBusinessObject.Account;

namespace JeweleryStorePlatformRepository.Interface;

public interface IRoleRepository
{
    public Task<List<Role>> GetAllRoles();
    public Task AddNewRole(Role role);
    public Task AddRangeRoles(List<Role> roles);
}