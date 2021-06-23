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
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure( EntityTypeBuilder<Phone> builder )
        {
            builder.ToTable( nameof( Phone ) ).HasKey( p => p.Id );

            builder.Property( c => c.Number ).IsRequired().HasMaxLength( 50 );

            builder.HasOne<Client>().WithMany( c => c.Phones ).HasForeignKey( p => p.ClientId );
            builder.HasMany( p => p.Packages ).WithMany( p => p.Phones );
            builder.HasMany( p => p.Services ).WithMany( s => s.Phones );
        }
    }
}
