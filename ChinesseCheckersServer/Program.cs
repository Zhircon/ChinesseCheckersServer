using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinesseCheckersServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server Activo");
            var result= Logic.PlayerManager.AddPlayer("Zhircon", "A1G2n3i4", "agnizahir@gmail.com");
            Console.WriteLine(result);
        }
    }
}
