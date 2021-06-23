using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesManager.Entities.Models
{
    public class Phone : Entity
    {
        public string Number { get; private set; }
        public int ClientId { get; private set; }
        public DateTime ActivationDate { get; private set; }
        public DateTime DeactivationDate { get; private set; }

        public List<Package> Packages { get; private set; }
        public List<Service> Services { get; private set; }
    }
}
