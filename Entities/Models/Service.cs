using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesManager.Entities.Models
{
    public class Service : Entity
    {
        public Service( string name, bool isActive, string description, decimal price )
        {
            Name = name;
            IsActive = isActive;
            Description = description;
            Price = price;
        }

        public string Name { get; private set; }
        public bool IsActive { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public List<Phone> Phones { get; private set; } = new();
        public List<Package> Packages { get; private set; } = new();
    }
}
