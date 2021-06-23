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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure( EntityTypeBuilder<Payment> builder )
        {
            builder.ToTable( nameof( Payment ) ).HasKey( p => p.Id );

            builder.Property( p => p.Worth ).HasColumnType( "money" );

            builder.HasOne<Phone>().WithMany().HasForeignKey( p => p.PhoneId );
        }
    }
}
