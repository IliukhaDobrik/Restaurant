namespace BussinesLayer.Helpers.EmailSenders.Interfaces
{
    public interface IEmailSender
    {
        //this method for send message for reserve ticket
        Task Send(int seatNumber, DateTime dateOfReserve, string userName);

        //this method for send message for buy dishes
        Task Send(decimal price, string userName);
    }
}