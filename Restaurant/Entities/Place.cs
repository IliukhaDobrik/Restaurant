using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public sealed class Place
    {
        public Guid PlaceId { get; set; }
        public int CountOfSeats { get; set; }
        public int SeatNumber { get; set; }
        public bool IsFree { get; set; }
        public User User { get; set; }
    }
}
