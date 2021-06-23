using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhonesManager.Entities.Models;
using PhonesManager.ModelsConfiguration;

namespace PhonesManager.DbContexts
{
    public class PhoneOperatorContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Service> Services { get; set; }

        /*public PhoneOperatorContext( DbContextOptions<PhoneOperatorContext> options )
            : base( options )
        {
            Database.EnsureCreated();
        }*/

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer( @"Data Source = localhost\SQLEXPRESS; Database = PhoneOperator; Trusted_Connection = True" );
        }

        protected override void OnModelCreating( ModelBuilder builder )
        {
            base.OnModelCreating( builder );

            builder.ApplyConfiguration( new ClientConfiguration() );
            builder.ApplyConfiguration( new PackageConfiguration() );
            builder.ApplyConfiguration( new PaymentConfiguration() );
            builder.ApplyConfiguration( new PhoneConfiguration() );
            builder.ApplyConfiguration( new ServiceConfiguration() );
        }
    }
}
