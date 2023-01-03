using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChinesseCheckersServer
{
    [ServiceContract(CallbackContract = typeof(IChatMgtCallback))]
    public interface IChatMgt
    {
        [OperationContract]
        void JoinToChat(string _idRoom, int _idPlayer);
        [OperationContract]
        void SendMessage(string _idRoom,string _nickname, string _message);
    }
}
