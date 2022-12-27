using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class EmailManager
    {
        private static readonly SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
        {
            Credentials = new NetworkCredential("agnizahir@gmail.com", "dsedbcgjqhaisphv"),
            EnableSsl = true
        };
        public static void SendEmailMessage(string _from,string _recipients,string _subject,string _body)
        {
            smtpClient.Send(_from, _recipients , _subject, _body);
            Console.WriteLine("Sent");
            Console.ReadLine();
        }
    }
}
