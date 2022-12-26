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
    public static class PlayerManager
    {
        public static void SayHelloWorld()
        {
            Console.WriteLine("Hello world!");
        }
        public static int AddPlayer(string _nickname,string _password,string _email)
        {
            DataAccess.Player playerToAdd = new DataAccess.Player();
            int operationResult = 0;
            using (var dbContext = new DataAccess.ChinesseCheckersDBEntities())
            {
                try
                {
                    playerToAdd.Nickname = _nickname;
                    playerToAdd.Password = _password;
                    playerToAdd.Email = _email;
                    dbContext.PlayerSet.Add(playerToAdd);
                    dbContext.SaveChanges();
                    operationResult = playerToAdd.IdPlayer;
                }catch (System.Data.Entity.Core.EntityException)
                {
                    Console.WriteLine("Database server not found");
                }
            }
            return operationResult;
        }
        public static DataAccess.Player CheckIfPlayerExists(string _email)
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
                };
                return playerSearched;
            }
        }
    }
}
