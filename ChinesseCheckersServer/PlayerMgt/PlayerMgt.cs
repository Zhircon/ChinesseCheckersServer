using DataAccess;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ChinesseCheckersServer
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "GameService" en el código y en el archivo de configuración a la vez.
    public partial class GameService : IPlayerMgt
    {
        Logic.OperationResult IPlayerMgt.DeletePlayer(int _idPlayer)
        {
            return Logic.PlayerManager.DeletePlayer(_idPlayer);
        }

        Logic.Session IPlayerMgt.Login(string _email, string _password)
        {
            return Logic.PlayerManager.Login(_email, _password);
        }

        Logic.OperationResult IPlayerMgt.RegisterPlayer(string _nickname, string _password, string _email)
        {
            return Logic.PlayerManager.AddPlayer(_nickname, _password, _email);
        }

        OperationResult IPlayerMgt.UpdateConfiguration(Configuration _configuration)
        {
            return Logic.ConfigurationManager.UpdateConfiguration(_configuration);
        }

        OperationResult IPlayerMgt.UpdatePlayer(Player _player)
        {
            return Logic.PlayerManager.UpdatePlayer(_player);
        }
    }
}
