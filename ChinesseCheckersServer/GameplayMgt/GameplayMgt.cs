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

        char IGameplayMgt.AssingColor(string _idRoom, int _idPlayer)
        {
            char[] colors;
            char colorToAssing;
            Room room;
            roomList.TryGetValue(_idRoom,out  room);
            if (room != null)
            {
                if (room.NumberOfAllowedPlayers == 2) { colors = room.ColorForTwoPlayers; }
                else { colors = room.ColorForThreePlayers; }
                colorToAssing = colors[room.GameplayCallbacks.Keys.Count()];
                room.PlayersColors.Add(_idPlayer, colorToAssing );
            }
            else
            {
                colorToAssing = 'X';
            }
            return colorToAssing;
        }



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

        void IGameplayMgt.MoveToken(string _idRoom,char _charToken,Point _from, Point _to)
        {
            foreach (IGameplayMgtCallback callback in roomList[_idRoom].GameplayCallbacks.Values)
            {
                callback.MoveAllPlayers(_charToken,_from, _to);
            }
        }

        void IGameplayMgt.TerminateTurn(string _idRoom)
        {
            Room room;
            roomList.TryGetValue(_idRoom,out room);
            if (room != null)
            {
                char[] currentPalette;
                char colorTurn;
                int nextTurn;
                currentPalette = (room.NumberOfAllowedPlayers == 2) ? room.ColorForTwoPlayers : room.ColorForThreePlayers;
                do
                {
                    nextTurn = room.ChangeTurn();
                    Console.WriteLine("nextTurn:" + nextTurn);
                    colorTurn = currentPalette.ElementAt(nextTurn);
                } while (!room.PlayersColors.Values.Contains(colorTurn));
                foreach (IGameplayMgtCallback callback in roomList[_idRoom].GameplayCallbacks.Values)
                {
                    callback.ChangeTurn(colorTurn);
                }
            }
        }
        char IGameplayMgt.GetCurrentTurn(string _idRoom)
        {
            Room room;
            roomList.TryGetValue(_idRoom, out room);
            char[] currentPalette;
            char colorTurn='X';
            if (room != null)
            {
                currentPalette = (room.NumberOfAllowedPlayers == 2) ? room.ColorForTwoPlayers : room.ColorForThreePlayers;
                colorTurn = currentPalette.ElementAt(room.Turn);
            }
            return colorTurn;
        }

        void IGameplayMgt.DeclareGameOver(string _idRoom, string _playerNicknameDeclare, string _message)
        {
            Room room;
            roomList.TryGetValue(_idRoom, out room);
            if (room != null)
            {
                foreach (IGameplayMgtCallback callback in roomList[_idRoom].GameplayCallbacks.Values)
                {
                    callback.GameOver(_playerNicknameDeclare,_message);
                }
            }
        }
    }
}
