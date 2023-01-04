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
            Credentials = new NetworkCredential("agnizahir@gmail.com", "opctpjrpdymgeezm"),
            EnableSsl = true
        };
        public static OperationResult SendEmailMessage(string _recipients,string _subject,string _body)
        {
            OperationResult operationResult;
            string _from = "agnizahir@gmail.com";
            try
            {
                smtpClient.Send(_from, _recipients, _subject, _body);
                operationResult = OperationResult.Sucessfull;
            }catch(SmtpException)
            {
                operationResult = OperationResult.Failed;
            }
            return operationResult;
        }
        public static string SendVerificationCode(string _recipients)
        {

            string _from = "agnizahir@gmail.com";
            string code;
            try
            {
                code = Encrypt.GenerateNewCode();
                smtpClient.Send(_from, _recipients, "Verification code ",code);
                
            }
            catch (SmtpException se )
            {
                code = "";
                Console.WriteLine(se.Message);
            }
            return code;
        }
    }
}
