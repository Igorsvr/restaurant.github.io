using Kingrice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

//https://navody.webotvurci.cz/kb/nastaveni-smtp-pro-odesilani-emailu/
//https://www.bing.com/videos/riverview/relatedvideo?q=jak+nastavit+smtp+pro+p%c5%99epos%c3%adl%c3%a1n%c3%ad+emailu+.net+visual+studio+umbraco&mid=162A54D970065E943877162A54D970065E943877&mcid=F31BD7763ED54A6B8D02D214829FC1A1&FORM=VIRE


namespace Kingrice.Controllers
{
    public class ContactFormController : SurfaceController
    {
        [HttpPost]
        public ActionResult SubmitForm(ContentForm model)
        {
            if (ModelState.IsValid)
            {
                MailMessage mailMessage = new MailMessage(model.Email, "buldozerom@gmail.com");
                mailMessage.Subject = model.Subject;
                mailMessage.Body = model.Message;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 465);
                smtpClient.Send(mailMessage);
                TempData["ContactResult"] = "Has been sent";
                return RedirectToCurrentUmbracoPage();
            }
            //MailMessage mailMessage = new MailMessage(model.Email, "buldozerom@gmail.com");
            //mailMessage.Subject = model.Subject;
            //mailMessage.Body = model.Message;

            //SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 465);
            //smtpClient.Send(mailMessage);

            //return RedirectToCurrentUmbracoPage();
            return CurrentUmbracoPage();
        }
    }
}