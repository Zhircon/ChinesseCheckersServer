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
            Console.WriteLine("Server and services are online now");
            Console.Read();
            gameService.Close();
        }
    }
}
