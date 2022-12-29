using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinesseCheckersServer
{
    public partial class GameService : IConnectionTestMgt
    {
        bool IConnectionTestMgt.IsConnectionUp()
        {
            return true;
        }
    }
}
