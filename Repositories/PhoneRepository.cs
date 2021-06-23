using System;
using System.Collections.Generic;
using PhonesManager.DbContexts;
using PhonesManager.Entities.Models;

namespace PhonesManager.Repositories
{
    public class PhoneRepository : EFRepository<Phone>
    {
        public PhoneRepository( PhoneOperatorContext db )
            : base( db )
        {
        }
    }
}
