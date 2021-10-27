using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TimeBank.Logic
{
    public static class EmailHelper
    {
        public static void Email(string body, bool isHtml, string toEmailAddress,string subject)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("mybuildingnoreplay@gmail.com");
                message.To.Add(new MailAddress(toEmailAddress));
                message.Subject = subject;
                message.IsBodyHtml = isHtml; //to make message body as html  
                message.Body = body;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("mybuildingnoreplay@gmail.com", "Purhoanj!209");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
