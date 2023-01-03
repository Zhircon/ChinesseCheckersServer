using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChinesseCheckersServer
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, InstanceContextMode = InstanceContextMode.Single)]
    public partial class GameService : IConnectionTestMgt
    {
        bool IConnectionTestMgt.IsConnectionUp()
        {
            return true;
        }
    }
}
