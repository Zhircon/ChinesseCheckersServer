using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChinesseCheckersServer
{
    public partial class GameService : IGameplayMgt
    {
        void IGameplayMgt.JoinToGameplay(string _idRoom, int _idPlayer)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IGameplayMgtCallback>();

            if (!roomList[_idRoom].GameplayCallbacks.ContainsKey(_idPlayer))
            {
                roomList[_idRoom].GameplayCallbacks.Add(_idPlayer, callback);
            }
            else
            {
                roomList[_idRoom].GameplayCallbacks.Remove(_idPlayer);
                roomList[_idRoom].GameplayCallbacks.Add(_idPlayer, callback);
            }
        }

        void IGameplayMgt.MoveToken(string _idRoom, Point _from, Point _to)
        {
            foreach (IGameplayMgtCallback callback in roomList[_idRoom].GameplayCallbacks.Values)
            {
                callback.MoveAllPlayers(_from, _to);
            }
        }

        void IGameplayMgt.TerminateTurn(string _idRoom)
        {
            throw new NotImplementedException();
        }
    }
}
