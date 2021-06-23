using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesManager.Entities.Models
{
    public class Payment : Entity
    {
        public int PhoneId { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Worth { get; private set; }
    }
}
