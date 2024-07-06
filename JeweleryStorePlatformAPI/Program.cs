using JeweleryStorePlatformAPI.Configuration;
using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformDataAccess;
using JeweleryStorePlatformService.Interface;
using JeweleryStorePlatformService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IJeweleryRepository, JeweleryRepository>();
builder.Services.AddScoped<IJeweleryService, JeweleryService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddRepository();
builder.Services.AddService();
builder.Services.AddAutoMapper();
builder.Services.AddSeeding();
builder.Services.AddCloudinarySetting(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.MapControllers();


using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<Seeding>(); 
    await context.AccountSeeding();
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error while seeding data"); 
}


app.Run();
