using Microsoft.AspNetCore.Identity;
using Shelfie.Application;
using Shelfie.Application.Common.Constants;
using Shelfie.Application.Mapping;
using Shelfie.Infrastructure;
using Shelfie.Infrastructure.Data.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ShelfieDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("ShelfieConnection"),
//        b => b.MigrationsAssembly("Shelfie.WebApi"));

//});

builder.Services
    .AddApplicationServices()
    .AddMappingServices()
    .AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

//TODO: Rethink this piece of code. It's not good that Api referes to Infrastructure component so directly
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = ApplicationRoles.GetAllRoles();
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
