using System.Globalization;
using FullCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FullCart.Infrastructure;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p=>p.Id).IsRequired();
        builder.Property(p=>p.ProductName).IsRequired().HasMaxLength(100);
        builder.Property(p=>p.ProductDescription).IsRequired().HasMaxLength(180);
        builder.Property(p=>p.ProductPrice).HasColumnType("decimal(18,2)");
        builder.Property(p=>p.ProductImageUrl).IsRequired();
        builder.HasOne(b=>b.Category).WithMany().HasForeignKey(p=>p.CategoryId);
        builder.HasOne(b=>b.Brand).WithMany().HasForeignKey(p=>p.BrandId);
        var date = DateTime.Parse("18/08/2023");

        builder.HasData( 
          new Product {ProductName="Accelerate Diagnostics, Inc.",ProductDescription="tortor sollicitudin mi sit amet lobortis sapien sapien non mi integer ac neque duis bibendum morbi non",ProductPrice=10000,ProductImageUrl="http://dummyimage.com/174x100.png/cc0000/ffffff",CategoryId=new Guid("7bec4a97-51e0-44f8-8512-9d4f2d8a9a10"),BrandId= new Guid("9685bffe-a1ab-4f45-aee1-5f3ecdd0ac5c"),CreatedOn=DateTime.Parse("18/08/2023"),CreatedBy="ehuddart0",LastModifiedOn= DateTime.Parse("19/08/2023"),LastModifiedBy="biacovelli0",IsDeleted=false},
          new Product {ProductName="Lennox International, Inc.", ProductDescription="molestie nibh in lectus pellentesque at nulla suspendisse potenti cras in purus",ProductPrice=69752,ProductImageUrl="http=//dummyimage.com/186x100.png/5fa2dd/ffffff",CategoryId=new Guid("7bec4a97-51e0-44f8-8512-9d4f2d8a9a10"),BrandId=new Guid("b89697c1-3458-4af2-9ed5-0397d0132f19"),CreatedOn= DateTime.Parse("19/08/2023"),CreatedBy="tstillwell1",LastModifiedOn= DateTime.Parse("19/08/2023"),LastModifiedBy="sspinnace1",IsDeleted=false},
          new Product {ProductName="Diagnostics, Iasnc.",ProductDescription="tortor sollicitudin mi sit amet lobortis sapien sapien non mi integer ac neque duis bibendum morbi non",ProductPrice=10000,ProductImageUrl="http://dummyimage.com/174x100.png/cc0000/ffffff",CategoryId=new Guid("7bec4a97-51e0-44f8-8512-9d4f2d8a9a10"),BrandId= new Guid("9685bffe-a1ab-4f45-aee1-5f3ecdd0ac5c"),CreatedOn=DateTime.Parse("18/08/2023"),CreatedBy="ehuddart0",LastModifiedOn= DateTime.Parse("19/08/2023"),LastModifiedBy="biacovelli0",IsDeleted=false}, 
          new Product {ProductName="Accelerate Insc.",ProductDescription="tortor sollicis sapien sapien non mi integer ac neque duis bibendum morbi non",ProductPrice=20000,ProductImageUrl="http://dummyimage.com/174x100.png/cc0000/ffffff",CategoryId=new Guid("7bec4a97-51e0-44f8-8512-9d4f2d8a9a10"),BrandId= new Guid("9685bffe-a1ab-4f45-aee1-5f3ecdd0ac5c"),CreatedOn=DateTime.Parse("18/08/2023"),CreatedBy="ehuddart0",LastModifiedOn= DateTime.Parse("19/08/2023"),LastModifiedBy="biacovelli0",IsDeleted=false}, 
          new Product {ProductName="Accesadsasfsalercs, Issnc.",ProductDescription="tortor sollobortis sapien sapien non mi integer ac neque duis bibendum morbi non",ProductPrice=13000,ProductImageUrl="http://dummyimage.com/174x100.png/cc0000/ffffff",CategoryId=new Guid("7bec4a97-51e0-44f8-8512-9d4f2d8a9a10"),BrandId= new Guid("9685bffe-a1ab-4f45-aee1-5f3ecdd0ac5c"),CreatedOn=DateTime.Parse("18/08/2023"),CreatedBy="ehuddart0",LastModifiedOn= DateTime.Parse("19/08/2023"),LastModifiedBy="biacovelli0",IsDeleted=false}
        ); 
    }
}
