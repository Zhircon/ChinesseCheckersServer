using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChinesseCheckersServer
{
    [ServiceContract]
    public interface IChatMgtCallback
    {
        [OperationContract]
        void ReceiveMessage(string _nickname,string _message);
    }
}
