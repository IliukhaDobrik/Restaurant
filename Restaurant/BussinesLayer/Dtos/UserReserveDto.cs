using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Dtos
{
    public class UserReserveDto
    {
        public string Email { get; set; }
        public DateTime DateOfReservation { get; set; }
        public int CountOfSeats { get; set; }
    }
}
