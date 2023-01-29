using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Dtos
{
    public class UserDishDto
    {
        public string UserEmail { get; set; }
        public Guid DishId { get; set; }
    }
}
