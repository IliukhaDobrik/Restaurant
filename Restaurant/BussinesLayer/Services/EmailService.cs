using BussinesLayer.Interfaces;
using Entities;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class EmailService : IEmailService
    {
        public async Task Send(int seatNumber, DateTime dateOfReserve, string userName)
        {
            using var emailMessage = new MimeMessage();

            emailMessage.From.Add(MailboxAddress.Parse("bogdobrinskiy@gmail.com"));
            emailMessage.To.Add(MailboxAddress.Parse(userName));
            emailMessage.Subject = "Билет";
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

        public async Task Send(decimal price, string userName)
        {
            using var emailMessage = new MimeMessage();

            emailMessage.From.Add(MailboxAddress.Parse("bogdobrinskiy@gmail.com"));
            emailMessage.To.Add(MailboxAddress.Parse(userName));
            emailMessage.Subject = "Билет";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"Заказ оформлен, с вашей карточки сняло {price}"
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("bogdobrinskiy@gmail.com", "yvowmwmtnsxsiglg");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
