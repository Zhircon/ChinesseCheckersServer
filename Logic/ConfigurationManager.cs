using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class ConfigurationManager
    {
        public static DataAccess.Configuration AddConfiguration(int _idPlayer)
        {
            DataAccess.Configuration configuration = new DataAccess.Configuration(); ;
            using (var _context= new DataAccess.ChinesseCheckersDBEntities())
            {
                try
                {
                    configuration.IdConfiguration = _idPlayer;
                    configuration.volMusic = 100;
                    configuration.volSFX = 100;
                    configuration.language = "es";
                    _context.ConfigurationSet.Add(configuration);
                    _context.SaveChanges();
                }catch(System.Data.Entity.Core.EntityException)
                {
                    Console.WriteLine("Database server not found");
                    configuration = null;
                }
                return configuration;
            }
        }
        public static Logic.OperationResult DeleteConfiguration(int _idPlayer)
        {
            OperationResult operationResult = OperationResult.Unknown;
            DataAccess.Configuration configuration;
            using (var _context = new DataAccess.ChinesseCheckersDBEntities())
            {
                try
                {
                    configuration = new DataAccess.Configuration() 
                    { IdConfiguration = _idPlayer};
                    _context.ConfigurationSet.Remove(configuration);
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
