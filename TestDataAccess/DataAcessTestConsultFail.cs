using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestDataAccess
{
    [TestClass]
    public class DataAcessTestConsultFail
    {
        [TestMethod]
        public void LoginFail()
        {
            var session = Logic.PlayerManager.Login("agnizahi@gmail.com", "A1G2n3i4zhirn.");
            Assert.AreEqual(session, null);
        }
        [TestMethod]
        public void SearchByIdFail()
        {
            var player = Logic.PlayerManager.SearchPlayerById(0);
            Assert.AreEqual(player, null);
        }
        [TestMethod]
        public void GetRelationshipsFail()
        {
            int idPlayer = 0;
            var relationship = Logic.RelationshipManager.GetRelationships(idPlayer);
            Assert.AreEqual(relationship.Count,0);
        }
    }
}
