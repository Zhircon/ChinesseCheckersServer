using DataAccess;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChinesseCheckersServer
{
    public partial class GameService : IRoomMgt
    {
        private readonly Dictionary<string, Room> roomList = new Dictionary<string, Room>();
        string IRoomMgt.CreateRoom()
        {
            string idRoom;
            do
            {
                idRoom = Logic.Encrypt.GenerateNewCode();
            } while (roomList.ContainsKey(idRoom));
            var room = new Room { IdRoom = idRoom };
            roomList.Add(idRoom, room);
            return idRoom;
        }

        int IRoomMgt.JoinToRoom(string _idRoom, Player _player)
        {
            var callbackOfThis = OperationContext.Current.GetCallbackChannel<IRoomMgtCallback>();
            int numberOfPlayer = 0;
            Room room;
            roomList.TryGetValue(_idRoom, out room);
            if (room != null){
                room.Players.Add(_player.IdPlayer,_player);
                room.RoomCallbacks.Add(_player.IdPlayer, callbackOfThis);
                numberOfPlayer = room.Players.Count();
                foreach (IRoomMgtCallback callback in room.RoomCallbacks.Values)
                {
                    callback.UpdateNumberOfPlayersConected(numberOfPlayer);
                }
                
            }
            return numberOfPlayer;
        }
        OperationResult IRoomMgt.LeaveRoom(string _idRoom, int _idPlayer)
        {
            Logic.OperationResult operationResult = OperationResult.Unknown;
            Room room;
            roomList.TryGetValue(_idRoom, out room);
            if (room != null)
            {
                room.Players.Remove(_idPlayer);
                if (room.RoomCallbacks.ContainsKey(_idPlayer)) { room.RoomCallbacks.Remove(_idPlayer); }
                if (room.ChatCallbacks.ContainsKey(_idPlayer)) { room.ChatCallbacks.Remove(_idPlayer); }
                if (room.GameplayCallbacks.ContainsKey(_idPlayer)) { room.GameplayCallbacks.Remove(_idPlayer); }
                { operationResult = OperationResult.Sucessfull; }
            }
            return operationResult;
        }

        void IRoomMgt.NotifyAllPlayersReady(string _idRoom)
        {
            Room room;
            roomList.TryGetValue(_idRoom, out room);
            if (room != null)
            {
                foreach (IRoomMgtCallback callback in room.RoomCallbacks.Values)
                {
                    callback.SendAllPlayerToGameplay();
                }
            }
        }

        Room IRoomMgt.SearchRoom(string _idRoom)
        {
            Room room;
            roomList.TryGetValue(_idRoom, out room);
            return room;
        }
    }
}
