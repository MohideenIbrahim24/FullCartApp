using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FullCart.Infrastructure.Configs
{
    public class BrandConfiguration: IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasData( 
            new Brand {Name="Little Group",CreatedOn=DateTime.Parse("18/08/2023"),CreatedBy="ehuddart0",LastModifiedOn= DateTime.Parse("19/08/2023"),LastModifiedBy="biacovelli0",IsDeleted=false},
            new Brand {Name="Heathcote and Sons",CreatedOn= DateTime.Parse("19/08/2023"),CreatedBy="tstillwell1",LastModifiedOn= DateTime.Parse("19/08/2023"),LastModifiedBy="sspinnace1",IsDeleted=false}
            ); 
        }
    }
}