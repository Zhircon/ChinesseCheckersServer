using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChinesseCheckersServer
{
    public static class Program
    {
        static void Main(string[] args)
        {
            ServiceHost gameService = new ServiceHost(typeof(GameService));
            gameService.Open();
            Logic.EmailManager.SendEmailMessage("agnizahir@gmail.com", "agnizahir@gmail.com", "test", "HHola mundo");
            Console.WriteLine("Server Activo");
            Console.Read();
            gameService.Close();
        }
    }
}
