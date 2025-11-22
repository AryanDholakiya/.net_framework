
using JQueryAndAjaxCRUD2.Models;

namespace JQueryAndAjaxCRUD2.Repositories
{
    public interface IEmailService
    {
        public Task SendEmail(string? toEmail, string? subject, string? Content, List<IFormFile>? Attachments);
    }
}
