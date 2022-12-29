using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Session
    {
        private DataAccess.Player playerLoged;
        private DataAccess.Configuration playerConfiguration;
        public DataAccess.Player PlayerLoged
        {
            get { return playerLoged; } 
            set { playerLoged = value; } 
        }
        public DataAccess.Configuration PlayerConfiguration
        {
            get { return playerConfiguration; }
            set { playerConfiguration = value; }
        }
    }
}
