using System.Text.Json;
using FullCart.Domain;
using FullCart.Domain.Entities;
using FullCart.Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace FullCart.Infrastructure;

public class CartContextSeed
{
    public static async Task SeedAsync (CartDbContext cartDbContext,ILoggerFactory loggerFactory){
        try{
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
           var loggerError = loggerFactory.CreateLogger<CartContextSeed>();
                loggerError.LogError("You Current DIRECTORY IS:"+baseDirectory);
                if(!cartDbContext.Brands.Any())
                    {
                        var branddata = File.ReadAllText(".././FullCart.Infrastracture/SeedData/Brand.json");
                        var brands = JsonSerializer.Deserialize<List<Brand>>(branddata);
                        if(brands == null){// Needs to be refactored
                            return;
                        }
                        foreach (var brandItem in brands)
                        {
                            await cartDbContext.Brands.AddAsync(brandItem);
                        }
                        await cartDbContext.SaveChangesAsync();
                    }
                    if (!cartDbContext.Categories.Any())
                    {
                        var categoryData = File.ReadAllText("../FullCart.Infrastracture/SeedData/Category.json");
                        var categories = JsonSerializer.Deserialize<List<Category>>(categoryData);
                         if(categories == null){ // Needs to be refactored
                            return;
                        }
                        foreach (var category in categories)
                        {
                            await cartDbContext.Categories.AddAsync(category);
                        }
                        await cartDbContext.SaveChangesAsync();
                    }
                    if (!cartDbContext.Products.Any())
                    {
                        var productsdata = File.ReadAllText("../FullCart.Infrastracture/SeedData/Product.json");
                        var products = JsonSerializer.Deserialize<List<Product>>(productsdata);
                        if(products == null){ // Needs to be refactored
                            return ;
                        }
                        foreach (var productsItems in products)
                        {
                            await cartDbContext.Products.AddAsync(productsItems);
                        }
                        await cartDbContext.SaveChangesAsync();
                    }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<CartContextSeed>();
                logger.LogError(ex, "Something went wrong with your request");
            }
    }
}
