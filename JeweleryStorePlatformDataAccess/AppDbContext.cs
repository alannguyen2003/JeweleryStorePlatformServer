using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformBusinessObject.Address;
using JeweleryStorePlatformBusinessObject.Design;
using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformBusinessObject.Order;
using JeweleryStorePlatformBusinessObject.Promotion;
using JeweleryStorePlatformBusinessObject.Transaction;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JeweleryStorePlatformDataAccess;

public class AppDbContext : IdentityDbContext<AccountEntity, 
    RoleEntity, 
    int,
    IdentityUserClaim<int>,
    IdentityUserRole<int>,
    IdentityUserLogin<int>,
    IdentityRoleClaim<int>,
    IdentityUserToken<int>
>
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<AccountEntity> Accounts { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<AccountRoleEntity> AccountRoles { get; set; }
    public DbSet<JeweleryEntity> Jeweleries { get; set; }
    public DbSet<JeweleryTypeEntity> JeweleryTypes { get; set; }
    public DbSet<JeweleryCaseEntity> JeweleryCases { get; set; }
    public DbSet<PaymentMethodEntity> PaymentMethods { get; set; }
    public DbSet<TransactionEntity> Transactions { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<OrderItemEntity> OrderItems { get; set; }
    public DbSet<JeweleryDesignEntity> JeweleryDesigns { get; set; }
    public DbSet<JeweleryDesignImageEntity> JeweleryDesignImages { get; set; }
    public DbSet<ColorEntity> Colors { get; set; }
    public DbSet<GIAReportEntity> Reports { get; set; }
    public DbSet<MaterialEntity> Materials { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<DistrictEntity> Districts { get; set; }
    public DbSet<CityEntity> Cities { get; set; }
    public DbSet<PromotionEntity> Promotions { get; set; }
    public DbSet<AccountPromotionEntity> AccountPromotions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(GetConnectionString());
    }

    private string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
        return configuration.GetConnectionString("DefaultConnectionString") ?? string.Empty;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<AccountPromotionEntity>()
            .HasKey(item => new { item.AccountId, item.PromotionId });
        builder.Entity<AccountRoleEntity>()
            .HasKey(item => new { item.AccountId, item.RoleId });
        builder.Entity<AccountEntity>(entity =>
        {
            entity.ToTable(name: "Accounts");
        });
        builder.Entity<RoleEntity>(entity =>
        {
            entity.ToTable(name: "Roles");
        });
    }
}