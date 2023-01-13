using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChinesseCheckersServer
{
    [ServiceContract(CallbackContract = typeof(IGameplayMgtCallback)) ]
    public interface IGameplayMgt
    {
        [OperationContract]
        void JoinToGameplay(string _idRoom, int _idPlayer);
        [OperationContract]
        char AssingColor(string _idRoom, int _idPlayer);
        [OperationContract]
        void MoveToken(string _idRoom, char _charToken, Point _from, Point _to);
        [OperationContract]
        void TerminateTurn(string _idRoom);
        [OperationContract]
        char GetCurrentTurn(string _idRoom);
        [OperationContract]
        void DeclareGameOver(string _idRoom, string _playerNicknameDeclare, string _message);
    }
}
