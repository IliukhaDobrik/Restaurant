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
        public Guid? UserId { get; set; }
        public int NumberOfSeats { get; set; }
        public bool IsFree { get; set; }
        public User User { get; set; }
    }
}
