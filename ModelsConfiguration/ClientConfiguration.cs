using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhonesManager.Entities.Models;

namespace PhonesManager.ModelsConfiguration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure( EntityTypeBuilder<Client> builder )
        {
            builder.ToTable( nameof( Client ) ).HasKey( c => c.Id );

            builder.Property( c => c.Name ).IsRequired().HasMaxLength( 50 );
            builder.Property( c => c.Surname ).HasMaxLength( 70 );
            builder.Property( c => c.Address ).HasMaxLength( 100 );

            builder.HasMany( c => c.Phones );
        }
    }
}
