using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesManager.Entities.Models
{
    public class Client : Entity
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Address { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public List<Phone> Phones { get; private set; } = new();
    }
}
