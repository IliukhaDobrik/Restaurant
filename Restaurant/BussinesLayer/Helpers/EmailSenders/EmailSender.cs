using MailKit.Security;
using MimeKit;
using BussinesLayer.Helpers.EmailSenders.Interfaces;

namespace BussinesLayer.Helpers.EmailSenders
{
    public class EmailSender : IEmailSender
    {
        //this method for send message for reserve ticket
        public async Task Send(int seatNumber, DateTime dateOfReserve, string userEmail)
        {
            using var emailMessage = new MimeMessage();

            emailMessage.From.Add(MailboxAddress.Parse("bogdobrinskiy@gmail.com"));
            emailMessage.To.Add(MailboxAddress.Parse(userEmail));
            emailMessage.Subject = "Ваши билеты в кино";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"Вы забронировали место {seatNumber} на {dateOfReserve}"
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("bogdobrinskiy@gmail.com", "yvowmwmtnsxsiglg");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }

        //this method for send message for buy dishes
        public async Task Send(decimal price, string userEmail)
        {
            using var emailMessage = new MimeMessage();

            emailMessage.From.Add(MailboxAddress.Parse("ILuxury@gmail.com"));
            emailMessage.To.Add(MailboxAddress.Parse(userEmail));
            emailMessage.Subject = "Ваш заказ";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"Заказ оформлен, с вашей карточки снято {price}"
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("ILuxury@gmail.com", "yvowmwmtnsxsiglg");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
