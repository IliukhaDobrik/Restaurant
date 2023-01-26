using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Dtos
{
    public class UserResponseDto
    {
        public Guid UserId { get; set; }
        public Guid? PlaceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime DateOfReservation { get; set; }

    }
}
