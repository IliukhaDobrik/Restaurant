using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces
{
    public interface IEmailService
    {
        Task Send(int seatNumber, DateTime dateOfReserve, string userName);
        Task Send(decimal price, string userName);
    }
}
