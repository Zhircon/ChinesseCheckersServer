using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestDataAccess
{
    [TestClass]
    public class DataAcessTest
    {
        [TestMethod]
        public void LoginSucessfull()
        {
            var session = Logic.PlayerManager.Login("agnizahir@gmail.com","A1G2n3i4zhircon.");
            Assert.AreNotEqual(session,null);
        }

        [TestMethod]
        public void LoginFailed()
        {
            var session = Logic.PlayerManager.Login("agnisito4328@gmail.com", "a1g2n3i4");
            Assert.IsNull(session);
        }
    }
}
