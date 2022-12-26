using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
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
            DataAccess.Player playerToAdd = new DataAccess.Player();
            OperationResult operationResult = OperationResult.Unknown;
            using (var dbContext = new DataAccess.ChinesseCheckersDBEntities())
            {
                try
                {
                    if (searchPlayerByEmail(_email) == null)
                    {
                        playerToAdd.Nickname = _nickname;
                        playerToAdd.Password = _password;
                        playerToAdd.Email = _email;
                        dbContext.PlayerSet.Add(playerToAdd);
                        dbContext.SaveChanges();
                        if (playerToAdd.IdPlayer != 0)
                        {
                            operationResult = OperationResult.Sucessfull;
                        }
                    }
                    else
                    {
                        operationResult = OperationResult.OperationNoValid;
                    }
                }catch (System.Data.Entity.Core.EntityException)
                {
                    operationResult = OperationResult.ConnectionLost;
                }
            }
            return operationResult;
        }
        public static DataAccess.Player Login(string _email,string _password)
        {
            DataAccess.Player playerLoged = null;
            using (var _context = new DataAccess.ChinesseCheckersDBEntities())
            {
                try
                {
                    playerLoged = _context.PlayerSet.Where(
                        r => r.Email.Equals(_email.ToLower())
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
    }
}
