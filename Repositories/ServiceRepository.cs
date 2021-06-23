using System;
using System.Collections.Generic;
using PhonesManager.DbContexts;
using PhonesManager.Entities.Models;

namespace PhonesManager.Repositories
{
    public class ServiceRepository : EFRepository<Service>
    {
        public ServiceRepository( PhoneOperatorContext db )
            : base( db )
        {
        }
    }
}
