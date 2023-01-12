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
        private const int PLAYER_NOT_ALLOWED = -1;
        string IRoomMgt.CreateRoom(int _numberOfAllowedPlayers)
        {
            string idRoom;
            do
            {
                idRoom = Logic.Encrypt.GenerateNewCode();
            } while (roomList.ContainsKey(idRoom));
            var room = new Room { 
                IdRoom = idRoom,
                NumberOfAllowedPlayers = _numberOfAllowedPlayers
            };
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
                if (room.Players.Values.Count() < room.NumberOfAllowedPlayers)
                {
                    room.Players.Add(_player.IdPlayer, _player);
                    room.RoomCallbacks.Add(_player.IdPlayer, callbackOfThis);
                    numberOfPlayer = room.Players.Count();
                    foreach (IRoomMgtCallback callback in room.RoomCallbacks.Values)
                    {
                        callback.UpdateNumberOfPlayersConected(numberOfPlayer);
                    }
                }
                else { 
                    numberOfPlayer = PLAYER_NOT_ALLOWED;
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
                if (room.Players.Count() == 0) { roomList.Remove(_idRoom); }
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

        bool IRoomMgt.IsPlayerInRoom(string _idRoom, int _idPlayer)
        {
            bool isPlayerInRoom=false;
            Room room;
            roomList.TryGetValue(_idRoom, out room);
            if (room != null) { isPlayerInRoom = room.Players.ContainsKey(_idPlayer); }
            return isPlayerInRoom;
        }
    }
}
