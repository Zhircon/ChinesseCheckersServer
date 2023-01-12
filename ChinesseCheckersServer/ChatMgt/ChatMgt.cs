using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChinesseCheckersServer
{
    public partial class GameService : IChatMgt
    {
        void IChatMgt.JoinToChat(string _idRoom, int _idPlayer)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IChatMgtCallback>();
            Room room;
            roomList.TryGetValue(_idRoom, out room);
            if (room != null) { room.ChatCallbacks.Add(_idPlayer, callback); }
        }

        void IChatMgt.SendFrienRequest(string _idRoom, int _idApplicantPlayer, string _nicknameApplicantPlayer, int _idPlayerAddressed)
        {
            Room room;
            roomList.TryGetValue(_idRoom, out room);
            if (room != null)
            {
                try
                {
                    room.ChatCallbacks[_idPlayerAddressed].ReceiveFriendRequest(_idApplicantPlayer,_nicknameApplicantPlayer);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
     
            }
        }

        void IChatMgt.SendMessage(string _idRoom,string _nickname, string _message)
        {
            Room room;
            roomList.TryGetValue(_idRoom, out room);
            if (room != null) {
                foreach (IChatMgtCallback element in room.ChatCallbacks.Values)
                {
                    try
                    {
                        element.ReceiveMessage(_nickname, _message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
