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
            DataAccess.Configuration configuration;
            using (var _context= new DataAccess.ChinesseCheckersDBEntities())
            {
                try
                {
                    configuration = new DataAccess.Configuration();
                    configuration.IdConfiguration = _idPlayer;
                    configuration.volMusic = 100;
                    configuration.volSFX = 100;
                    configuration.language = "es";
                    _context.ConfigurationSet.Add(configuration);
                }catch(System.Data.Entity.Core.EntityException)
                {
                    Console.WriteLine("Database server not found");
                    configuration = null;
                }
                return configuration;
            }
        }
    }
}
