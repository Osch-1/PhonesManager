using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PhonesManager.DbContexts;
using PhonesManager.Entities.Models;

namespace PhonesManager.Repositories
{
    public class PackageRepository : EFRepository<Package>
    {
        public PackageRepository( PhoneOperatorContext db )
            : base( db )
        {
        }
    }
}
