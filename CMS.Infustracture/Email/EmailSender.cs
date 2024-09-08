using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace CMS.Infustracture.Email
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string fromemail, string subject, string htmlMessage)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("osamadammag84@gmail.com", "aqib yvyi jjln niwm"),
                EnableSsl = true,
            };
            return smtpClient.SendMailAsync($"{fromemail}", "osamadammag84@gmail.com", subject, htmlMessage);
        }

        public Task SendToEmailAsync(string toEmail, string subject, string htmlMessage)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("osamadammag84@gmail.com", "aqib yvyi jjln niwm"),
                EnableSsl = true,
            };
            return smtpClient.SendMailAsync("osamadammag84@gmail.com", toEmail,  subject, htmlMessage);
        }
    }
}
