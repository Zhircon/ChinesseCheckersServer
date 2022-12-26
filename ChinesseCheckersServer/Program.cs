using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinesseCheckersServer
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server Activo");
            var result = Logic.PlayerManager.Login("Agnizahir@gmail.com", "A1G2n3i4");
            Console.WriteLine(result.Nickname);
            Console.Read();
        }
    }
}
