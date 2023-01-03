using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChinesseCheckersServer
{
    [ServiceContract]
    public interface IRoomMgtCallback
    {
        [OperationContract]
        void SendAllPlayerToGameplay();
        [OperationContract]
        void UpdateNumberOfPlayersConected(int _numberOfPlayers);
    }
}
