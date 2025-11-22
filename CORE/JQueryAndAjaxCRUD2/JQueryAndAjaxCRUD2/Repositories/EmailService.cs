using JQueryAndAjaxCRUD2.Models;
using MailKit.Net.Smtp;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MimeKit;
using System.Net;
using System.Net.Mail;

namespace JQueryAndAjaxCRUD2.Repositories
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration config)
        {
            _configuration = config;
        }

        public async Task SendEmail(string toEmail, string subject, string message, List<IFormFile>? attachments)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_configuration["SmtpSettings:SenderName"], _configuration["SmtpSettings:SenderEmail"]));
            emailMessage.To.Add(new MailboxAddress("", toEmail));
            emailMessage.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = message  // HTML body for list typed data,colored text etc..html format ma na dekhay te mate
            };

            if (attachments != null )
            {
                foreach ( var attachmentItem in attachments ) 
                {
                    using var ms = new MemoryStream();

                    await attachmentItem.CopyToAsync(ms);
                    bodyBuilder.Attachments.Add(attachmentItem.FileName, ms.ToArray());
                }
               
            }
            emailMessage.Body = bodyBuilder.ToMessageBody();   // <-- IMPORTANT 

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                await client.ConnectAsync(_configuration["SmtpSettings:Server"], int.Parse(_configuration["SmtpSettings:Port"]), MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_configuration["SmtpSettings:Username"], _configuration["SmtpSettings:Password"]);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }

            
        }
    }
}
