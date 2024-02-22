using FullCart.Api.Extensions;
using FullCart.Domain.Entities.Identities;
using FullCart.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();

//Extension Methods
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var loggerfactory = services.GetService<ILoggerFactory>();
try{
//     var context = services.GetRequiredService<CartDbContext>();
//     await context.Database.MigrateAsync();
//     // await CartContextSeed.SeedAsync(context, loggerfactory!);

        var userManager = services.GetRequiredService<UserManager<AppUser>>();
        var identityContext = services.GetRequiredService<AppIdentityDbContext>();
        await identityContext.Database.MigrateAsync();
        await AppIdentityDbContextSeed.SeedUsersAsync(userManager);
}
catch(Exception ex)
{
    var logger = services.GetService<ILogger<Program>>();
    logger?.LogError(ex,"An error occured during migration");
}

app.Run();
