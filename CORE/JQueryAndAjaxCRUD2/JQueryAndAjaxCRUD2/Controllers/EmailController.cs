using JQueryAndAjaxCRUD2.Data;
using JQueryAndAjaxCRUD2.Models;
using JQueryAndAjaxCRUD2.Repositories;
using Microsoft.AspNetCore.Mvc;
using MimeKit;


namespace JQueryAndAjaxCRUD2.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly EmpData _email;

        public EmailController(IEmailService emailService, EmpData email)
        {
            _emailService = emailService;
            _email = email;
        }


        public IActionResult Index()
        {
            var Emails = _email.TotalEmail.ToList();
            return View(Emails);
             
        }

        [HttpGet]
        public IActionResult SendEmail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail(Email email)
        {
            if (ModelState.IsValid)
            {
                await _emailService.SendEmail(email.ToEmail, email.Subject, email.Message, email.Attachment);
                var EmailData = new Email() {
                    ToEmail = email.ToEmail,
                    Subject = email.Subject,
                    Message = email.Message,
                    SentDate = DateTime.Now,
                };

                 _email.TotalEmail.Add(EmailData);
                await _email.SaveChangesAsync();
                TempData["Message"] = "Email sent successfully!";
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var findrecord = await _email.TotalEmail.FindAsync(id);
            _email.TotalEmail.Remove(findrecord);
            _email.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
