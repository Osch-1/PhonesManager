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
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure( EntityTypeBuilder<Service> builder )
        {
            builder.ToTable( nameof( Service ) ).HasKey( s => s.Id );

            builder.Property( s => s.Name ).IsRequired().HasMaxLength( 50 );
            builder.Property( s => s.Description ).HasMaxLength( 300 );
            builder.Property( s => s.Price ).HasColumnType( "money" );

            builder.HasMany( s => s.Phones ).WithMany( s => s.Services );
            builder.HasMany( s => s.Packages ).WithMany( p => p.Services );
        }
    }
}
