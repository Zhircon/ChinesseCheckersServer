using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinesseCheckersServer
{
    public partial class GameService : IEmailMgt
    {
        Logic.OperationResult IEmailMgt.SendEmail(string _recipients, string _subject, string _body)
        {
            return Logic.EmailManager.SendEmailMessage(_recipients, _subject, _body);
        }

        string IEmailMgt.SendVerificationCode(string _recipients)
        {
            return Logic.EmailManager.SendVerificationCode(_recipients);
        }
    }
}
