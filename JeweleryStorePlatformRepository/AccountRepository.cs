  using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformBusinessObject.Constant;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformDataTransfer.Request.AccountDTO;
using JeweleryStorePlatformRepository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeweleryStorePlatformRepository
{
    public class AccountRepository : IAccountRepository
    {

        public async Task<List<Account>> GetAllAccounts()
        {
            return await AccountDAO.Instance.GetAllAccount();
        }

        public async Task AddNewAccount(Account account)
        {
            await AccountDAO.Instance.AddNewAccount(account);
        }

        public async Task AddRangeAccount(List<Account> accounts)
        {
            await AccountDAO.Instance.AddRangeAccount(accounts);
        }

        public Account CheckLogin(string email, string password)
        {
            return AccountDAO.Instance.CheckLogin(email, password);
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            return await AccountDAO.Instance.UpdateAccount(account);
        }

        public async Task<bool> DeleteAccount(int accountId)
        {
            return await AccountDAO.Instance.DeleteAccount(accountId);
        }

        public async Task<Account> GetAccountById(int accountId)
        {
            return await AccountDAO.Instance.GetAccountById(accountId);
        }

        public async Task<int> GetRoleIdByAccountId(int accountId)
        {
            return await AccountDAO.Instance.GetRoleIdByAccountId(accountId);
        }
        public async Task<Account> RegisterNewAccount(SignUpRequest request)
        {
            Account account = new Account()
            {
                Email = request.Email,
                Password = request.Password,
                LastName = request.FullName,
                Points = 0,
                DateOfBirth = DateTime.Now,
                PhoneNumber = request.PhoneNumber,
                EmailConfirmed = true,
                FirstName = "",
                ProfileImage = "",
                MiddleName = ""
            };
            var accountAdded = await AccountDAO.Instance.AddNewAccount(account);
            await AccountRoleDAO.Instance.AddNewAccountRole(new AccountRole()
            {
                AccountId = accountAdded.Id,
                RoleId = (int)RoleConstant.CUSTOMER
            });
            return accountAdded;
        }
    }
}
