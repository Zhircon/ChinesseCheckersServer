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
        ConnectionLost = 100,
        OperationNoValid = 200
    }

    public static class PlayerManager
    {
        private static DataAccess.Player searchPlayerByEmail(string _email)
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
        public static OperationResult AddPlayer(string _nickname,string _password,string _email)
        {
            OperationResult operationResult = OperationResult.Unknown;

            DataAccess.Player playerToAdd = new DataAccess.Player();
            var emailLowered = _email.ToLower(CultureInfo.InvariantCulture);
            var nicknameLowered = _email.ToLower(CultureInfo.InvariantCulture);

            using (var dbContext = new DataAccess.ChinesseCheckersDBEntities())
            {
                try
                {
                    if (searchPlayerByEmail(_email) == null)
                    {
                        playerToAdd.Nickname = nicknameLowered;
                        playerToAdd.Password = _password;
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
                        operationResult = OperationResult.OperationNoValid;
                    }
                }catch (System.Data.Entity.Core.EntityException)
                {
                    Console.WriteLine("Database server not found");
                    operationResult = OperationResult.ConnectionLost;
                }
            }
            return operationResult;
        }
        public static DataAccess.Player Login(string _email,string _password)
        {
            DataAccess.Player playerLoged = null;
            var emailLowered = _email.ToLower(CultureInfo.InvariantCulture);
            using (var _context = new DataAccess.ChinesseCheckersDBEntities())
            {
                try
                {
                    playerLoged = _context.PlayerSet.Where(
                        r => r.Email.Equals(emailLowered)
                        && r.Password.Equals(_password)
                        ).FirstOrDefault();
                }
                catch (System.Data.Entity.Core.EntityException)
                {
                    Console.WriteLine("Database server not found");
                    playerLoged = null;
                }
                return playerLoged;
            }
        }
        public static OperationResult DeletePlayer(string _email)
        {
            DataAccess.Player playerLoged = null;
            OperationResult operationResult = OperationResult.Unknown;
            var emailLowered = _email.ToLower(CultureInfo.InvariantCulture);
            using (var _context = new DataAccess.ChinesseCheckersDBEntities())
            {
                try
                {
                    playerLoged = _context.PlayerSet.Where(
                        r => r.Email.Equals(emailLowered)).FirstOrDefault();
                    _context.PlayerSet.Remove(playerLoged);
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
