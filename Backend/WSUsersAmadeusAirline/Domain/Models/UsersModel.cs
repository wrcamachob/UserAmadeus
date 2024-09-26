using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UsersModel
    {
        private long iDIdentifier;
        private string name;
        private string lastName;
        private string email;
        private long phoneNumber;
        private DateTime dateOfBirthday;
        private float salary;

        //private IUsers users;
        //public EntityState State { private get; set; }

        [Required(ErrorMessage = "The Identification Number is required")]
        [RegularExpression("([0-9]*)", ErrorMessage = "Identifier Number must be only numbers")]
        //[StringLength(maximumLength:12, MinimumLength = 5, ErrorMessage = "Identification Number must be between 5 to 12 digits.")]
        public long IDIdentifier { get => iDIdentifier; set => iDIdentifier = value; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "The field name must be alphanumeric")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string? Name { get => name; set => name = value; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "The field last name must be alphanumeric")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string? LastName { get => lastName; set => lastName = value; }
        [Required]
        [EmailAddress]
        public string? Email { get => email; set => email = value; }

        [RegularExpression("([0-9]*)", ErrorMessage = "Phone Number must be only numbers")]
        public long PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        public DateTime DateOfBirthday { get => dateOfBirthday; set => dateOfBirthday = value; }

        public float Salary { get => salary; set => salary = value; }

        public UsersModel()
        {
        }
    }
}
