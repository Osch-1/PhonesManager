using System;
using System.Collections.Generic;
using PhonesManager.DbContexts;
using PhonesManager.Entities.Models;

namespace PhonesManager.Repositories
{
    public class PaymentRepository : EFRepository<Payment>
    {
        public PaymentRepository( PhoneOperatorContext db )
            : base( db )
        {
        }
    }
}
