using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ChinesseCheckersServer
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IGameService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPlayerMgt
    {
        [OperationContract]
        Logic.OperationResult RegisterPlayer(string _nickname, string _password, string _email);
        [OperationContract]
        DataAccess.Player Login(string _email, string _password);
        [OperationContract]
        Logic.OperationResult DeletePlayer(int _idPlayer);
    }
}
