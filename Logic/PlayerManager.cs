using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public enum OperationResult
    {
        Sucessfull = 0,
        Unknown = 1,
        Failed = 2,
        ConnectionLost = 100
    }

    public static class PlayerManager
    {
        private static DataAccess.Player SearchPlayerByEmail(string _email)
        {
            DataAccess.Player playerSearched = null;
            using (var _context = new DataAccess.ChinesseCheckersDBEntities())
            {
                try
                {
                    playerSearched = _context.PlayerSet.Where(r => r.Email.Equals(_email)).FirstOrDefault();
                }
                catch (System.Data.Entity.Core.EntityException)
                {
                    Console.WriteLine("Database server not found");
                    playerSearched = null;
                }
                return playerSearched;
            }
        }

        public static DataAccess.Player SearchPlayerById(int _idPlayer)
        {
            DataAccess.Player playerSearched = null;
            using (var _context = new DataAccess.ChinesseCheckersDBEntities())
            {
                try
                {
                    playerSearched = _context.PlayerSet.Where(r => r.IdPlayer.Equals(_idPlayer)).FirstOrDefault();
                }
                catch (System.Data.Entity.Core.EntityException)
                {
                    Console.WriteLine("Database server not found");
                    playerSearched = null;
                }
                return playerSearched;
            }
        }
        public static OperationResult AddPlayer(string _nickname,string _password,string _email)
        {
            OperationResult operationResult = OperationResult.Unknown;

            DataAccess.Player playerToAdd = new DataAccess.Player();
            var emailLowered = _email.ToLower(CultureInfo.InvariantCulture);

            using (var dbContext = new DataAccess.ChinesseCheckersDBEntities())
            {
                try
                {
                    if (SearchPlayerByEmail(_email) == null)
                    {
                        playerToAdd.Nickname = _nickname;
                        playerToAdd.Password = Encrypt.GetSHA256(_password);
                        playerToAdd.Email = emailLowered;
                        dbContext.PlayerSet.Add(playerToAdd);
                        dbContext.SaveChanges();
                        
                        if (playerToAdd.IdPlayer != 0)
                        {
                            Logic.ConfigurationManager.AddConfiguration(playerToAdd.IdPlayer);
                            operationResult = OperationResult.Sucessfull;
                        }
                    }
                    else
                    {
                        operationResult = OperationResult.Failed;
                    }
                }catch (System.Data.Entity.Core.EntityException)
                {
                    Console.WriteLine("Database server not found");
                    operationResult = OperationResult.ConnectionLost;
                }
            }
            return operationResult;
        }
        public static Session Login(string _email,string _password)
        {
            Session session = null;
            DataAccess.Player playerLoged = null;
            DataAccess.Configuration playerConfiguration = null;
            var emailLowered = _email.ToLower(CultureInfo.InvariantCulture);
            var passwordHashed = Encrypt.GetSHA256(_password);
            using (var _context = new DataAccess.ChinesseCheckersDBEntities())
            {
                try
                {
                    playerLoged = _context.PlayerSet.Where(
                        r => r.Email.Equals(emailLowered)
                        && r.Password.Equals(passwordHashed)
                        ).FirstOrDefault();
                    if (playerLoged != null)
                    {
                        playerConfiguration = _context.ConfigurationSet.Where(
                        r => r.IdConfiguration.Equals(playerLoged.IdPlayer)
                        ).FirstOrDefault();
                        session = new Session();
                        session.PlayerLoged = playerLoged;
                        session.PlayerConfiguration = playerConfiguration;
                    }
                    else
                    {
                        session = null;
                    }

                }
                catch (System.Data.Entity.Core.EntityException)
                {
                    Console.WriteLine("Database server not found");
                    session = null;
                }
                return session;
            }
        }
        public static OperationResult UpdatePlayer(DataAccess.Player _Player)
        {
            if (_Player == null) { return OperationResult.Failed; }
            OperationResult operationResult = OperationResult.Unknown;
            using (var _context = new DataAccess.ChinesseCheckersDBEntities())
            {
                try
                {
                    var dbPlayer = _context.PlayerSet.Find(_Player.IdPlayer);
                    if(dbPlayer!=null)
                    {
                        dbPlayer.Email = _Player.Email;
                        dbPlayer.Nickname = _Player.Nickname;
                        dbPlayer.Password = Encrypt.GetSHA256(_Player.Password);
                        _context.SaveChanges();
                        operationResult = OperationResult.Sucessfull;
                    }
                    else {
                        operationResult = OperationResult.Failed;
                    }

                }catch(System.Data.Entity.Core.EntityException){
                    operationResult = OperationResult.ConnectionLost;
                }
            }
            return operationResult;
        }
        public static OperationResult DeletePlayer(int _idPlayer)
        {
            DataAccess.Player playerLoged = null;
            OperationResult operationResult = OperationResult.Unknown;
            using (var _context = new DataAccess.ChinesseCheckersDBEntities())
            {
                try
                {
                    playerLoged = _context.PlayerSet.Where(
                        r => r.IdPlayer.Equals(_idPlayer)).FirstOrDefault();
                    _context.PlayerSet.Remove(playerLoged);
                    ConfigurationManager.DeleteConfiguration(playerLoged.IdPlayer);
                    operationResult = OperationResult.Sucessfull;
                }
                catch (System.Data.Entity.Core.EntityException)
                {
                    Console.WriteLine("Database server not found");
                    operationResult = OperationResult.ConnectionLost;
                }
                return operationResult;
            }
        }
    }
}
