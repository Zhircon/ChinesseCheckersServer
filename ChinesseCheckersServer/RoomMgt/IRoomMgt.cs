using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChinesseCheckersServer
{
    [ServiceContract(CallbackContract =typeof(IRoomMgtCallback))]
    public interface IRoomMgt 
    {
        [OperationContract]
        string CreateRoom(int _numberOfAllowedPlayers);
        [OperationContract]
        Room SearchRoom(string _idRoom);
        [OperationContract]
        int JoinToRoom(string _idRoom,DataAccess.Player _player);
        [OperationContract]
        Logic.OperationResult LeaveRoom(string _idRoom, int _idPlayer);
        [OperationContract]
        bool IsPlayerInRoom(string _idRoom, int _idPlayer);
        [OperationContract]
        void NotifyAllPlayersReady(string _idRoom);
    }
}
