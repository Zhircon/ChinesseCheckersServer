using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChinesseCheckersServer
{
    [ServiceContract]
    public interface IEmailMgt
    {
        [OperationContract]
        string SendVerificationCode(string _recipients);
        [OperationContract]
        Logic.OperationResult SendEmail(string _recipients, string _subject, string _body);
    }
}
