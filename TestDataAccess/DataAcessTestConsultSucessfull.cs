using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestDataAccess
{
    [TestClass]
    public class DataAcessTestConsultSucessfull
    {
        [TestMethod]
        public void LoginSucessfull()
        {
            var session = Logic.PlayerManager.Login("agnizahir@gmail.com","A1G2n3i4zhircon.");
            Assert.AreNotEqual(session,null);
        }
        [TestMethod]
        public void SearchByIdSucessfull()
        {
            var player = Logic.PlayerManager.SearchPlayerById(1);
            Assert.AreNotEqual(player, null);
        }
        [TestMethod]
        public void GetRelationshipsSucessfull()
        {
            int idPlayer = 1;
            var relationship = Logic.RelationshipManager.GetRelationships(idPlayer);
            Assert.AreNotEqual(relationship.Count,0);
        }
    }
}
