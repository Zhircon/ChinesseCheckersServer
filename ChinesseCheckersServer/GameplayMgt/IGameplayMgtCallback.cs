using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChinesseCheckersServer
{
    [ServiceContract]
    public interface IGameplayMgtCallback
    {
        [OperationContract]
        void MoveAllPlayers(Point _from, Point _to);
        [OperationContract]
        void ChangeTurn(int turn);
    }
}
