using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoByBus.Core.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string? PersonName { get; set; }

        public string? Gender { get; set; }

        public DateTime DOB { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public double Phone { get; set; }

        public string? Password { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? UserType { get; set; }
    }
}
