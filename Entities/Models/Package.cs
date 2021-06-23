using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesManager.Entities.Models
{
    public class Package : Entity
    {
        public string Name { get; private set; }
        public bool IsActive { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public List<Service> Services { get; private set; } = new();
        public List<Phone> Phones { get; private set; } = new();
    }
}
