using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhonesManager.DbContexts;
using PhonesManager.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace PhonesManager.Repositories
{
    public class ClientRepository : EFRepository<Client>
    {
        public ClientRepository( PhoneOperatorContext db )
            : base( db )
        {
        }
    }
}
