using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace JeweleryStorePlatformBusinessObject.Account;

[Table("AccountRoles")]
public class AccountRoleEntity 
{
    [ForeignKey("AccountId")]
    public int AccountId { get; set; }
    public AccountEntity AccountEntity { get; set; }
    [ForeignKey("RoleId")]
    public int RoleId { get; set; }
    public RoleEntity RoleEntity { get; set; }
}