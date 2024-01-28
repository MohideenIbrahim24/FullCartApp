using FullCart.Application;
using FullCart.Infrastructure;
using FullCart.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Infrastructure DI only - API needs to DI into Application services
builder.Services.AddScoped<IProductRepository, ProductRepository>();




builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CartDbContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
// var loggerfactory = scope.ServiceProvider.GetService<ILoggerFactory>();
// try{
//     var context = services.GetRequiredService<CartDbContext>();
//     await context.Database.MigrateAsync();
//     // await CartContextSeed.SeedAsync(context, loggerfactory!);
// }
// catch(Exception ex)
// {
//     var logger = services.GetService<ILogger<Program>>();
//     logger?.LogError(ex,"An error occured during migration");
// }

app.Run();