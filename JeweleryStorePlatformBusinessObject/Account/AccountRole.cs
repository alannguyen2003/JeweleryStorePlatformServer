using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace JeweleryStorePlatformBusinessObject.Account;

[Table("AccountRoles")]
public class AccountRole 
{
    [ForeignKey("AccountId")]
    public int AccountId { get; set; }
    public Account Account { get; set; }
    [ForeignKey("RoleId")]
    public int RoleId { get; set; }
    public Role Role { get; set; }
}