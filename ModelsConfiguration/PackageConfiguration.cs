using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhonesManager.Entities;
using PhonesManager.Entities.Models;

namespace PhonesManager.ModelsConfiguration
{
    public class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure( EntityTypeBuilder<Package> builder )
        {
            builder.ToTable( nameof( Package ) ).HasKey( p => p.Id );

            builder.Property( p => p.Name ).IsRequired().HasMaxLength( 50 );
            builder.Property( p => p.Description ).HasMaxLength( 300 );
            builder.Property( p => p.Price ).HasColumnType( "money" );

            builder.HasMany( p => p.Phones ).WithMany( p => p.Packages );
            builder.HasMany( p => p.Services ).WithMany( s => s.Packages );
        }
    }
}
