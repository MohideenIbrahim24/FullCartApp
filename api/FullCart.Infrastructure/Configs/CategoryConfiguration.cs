using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullCart.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FullCart.Infrastructure.Configs
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData( 
                new Category {CategoryName="Electronics",CategoryDisplayOrder=1,CreatedOn=DateTime.Parse("18/08/2023"),CreatedBy="ehuddart0",LastModifiedOn= DateTime.Parse("19/08/2023"),LastModifiedBy="biacovelli0",IsDeleted=false},
                new Category {CategoryName="Wear",CategoryDisplayOrder=2,CreatedOn= DateTime.Parse("19/08/2023"),CreatedBy="tstillwell1",LastModifiedOn= DateTime.Parse("19/08/2023"),LastModifiedBy="sspinnace1",IsDeleted=false},
                new Category {CategoryName="Books",CategoryDisplayOrder=3,CreatedOn= DateTime.Parse("19/08/2023"),CreatedBy="tstillwell1",LastModifiedOn= DateTime.Parse("19/08/2023"),LastModifiedBy="sspinnace1",IsDeleted=false}
            ); 
        }
    }
}