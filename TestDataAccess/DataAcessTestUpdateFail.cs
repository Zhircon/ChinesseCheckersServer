using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestDataAccess
{
    [TestClass]
    public class DataAcessTestUpdateFail
    {
        [TestMethod]
        public void UpdatePlayerFail()
        {
            DataAccess.Player player = new DataAccess.Player
            {
                IdPlayer = 0,
                Nickname = "Zhircon",
                Email = "agnizahir@gmail.com",
                Password = "A1G2n3i4zhircon."
            };
            Logic.OperationResult operationResult = Logic.PlayerManager.UpdatePlayer(player);
            Assert.AreNotEqual(operationResult, Logic.OperationResult.Sucessfull);
        }
        [TestMethod]
        public void UpdateConfigurationFail()
        {
            DataAccess.Configuration configuration = new DataAccess.Configuration
            {
                IdConfiguration = 0,
                volMusic = 20,
                language = "es"
            };
            Logic.OperationResult operationResult = Logic.ConfigurationManager.UpdateConfiguration(configuration);
            Assert.AreNotEqual(operationResult, Logic.OperationResult.Sucessfull);
        }
        [TestMethod]
        public void UpdateReationshipFail()
        {
            int idPlayerOwner = 0;
            int idPlayerGuest = 0;
            var operationResult = Logic.RelationshipManager.DeclarateBadRelationship(idPlayerOwner, idPlayerGuest);
            Assert.AreNotEqual(operationResult, Logic.OperationResult.Sucessfull);
        }
    }
}
