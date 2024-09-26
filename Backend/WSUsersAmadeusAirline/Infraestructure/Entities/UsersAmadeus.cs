using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entities
{
    public class UsersAmadeus
    {
        public long IDIdentifier { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }        
        public DateTime DateOfBirthday { get; set; }
        public float Salary { get; set; }

    }
}
