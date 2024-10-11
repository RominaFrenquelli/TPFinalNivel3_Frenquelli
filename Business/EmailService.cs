using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Business
{
    public class EmailService
    {
        private MailMessage mail;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("roprograma24@gmail.com", "hjlg qxvy mlwm cknw");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void ArmarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            mail = new MailMessage(); 
            mail.From = new MailAddress("noresponder@miempresaweb.com");
            mail.To.Add(emailDestino);
            mail.Subject = asunto;
            mail.IsBodyHtml = true;
            //mail.Body = "<h1>Bienvenido a Mi Empresa</h1>";
            mail.Body = cuerpo;
        }

        public void EnviarMail()
        {
            try
            {
                server.Send(mail);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
