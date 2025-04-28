using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.DTOs.MailDTOs;

namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {   
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SendMessageByMailDTO m)
        {
            //mime message nesnem konu,kime gideceği(to)
            //kimden gideceği(from),içerik kısmını tanımlamamıza yarar
            MimeMessage mimeMessage = new MimeMessage();
            //Kime Gidecek
            MailboxAddress mailBoxAdressto = new MailboxAddress("User",m.receiverMail);
            //Kimden Gelecek
            MailboxAddress mailBoxAdressFrom = new MailboxAddress("SignalR Rezervasyon", "cenkmelih58@gmail.com");
            mimeMessage.From.Add(mailBoxAdressFrom);
            mimeMessage.To.Add(mailBoxAdressto);
            var bodyBuilder=new BodyBuilder();
            bodyBuilder.TextBody = m.Content;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = m.subject;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("cenkmelih58@gmail.com", "thvc ampo xujc mluj");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return RedirectToAction("Index","Category");
        }
    }
}
