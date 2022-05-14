using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Repositary_Layer.Services
{
    public class EmailService
    {
        public static void SendMail(string Email, string token)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential("misterclient18@gmail.com", "18misterclient");

                MailMessage messageObj = new MailMessage();
                messageObj.To.Add(Email);
                messageObj.From = new MailAddress("misterclient18@gmail.com");
                messageObj.Subject = "Passward Reset Link";
                messageObj.IsBodyHtml = true;
                messageObj.Body = $"<!Doctype html>"+
                    "<html>"+
                            "<body style=\"background -colour:#ff7f26;text-align:center;\">"+
                            "<h1 style=\"colour:#051a89;\">Hello Vishal</h1>"+
                            "<h2 style=\"colour:#800000;\">Please click on the below link to reset passward.</h2" +"</body>"
                           +$"www.fundooNotes.com/reset-passward/{token}"+
                   "</html>";
                client.Send(messageObj);
            }
        }
    }
}
