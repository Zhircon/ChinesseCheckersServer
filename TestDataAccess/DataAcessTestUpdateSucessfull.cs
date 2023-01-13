using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestDataAccess
{
    [TestClass]
    public class DataAcessTestUpdateSucessfull
    {
        [TestMethod]
        public void UpdatePlayerSucessfull()
        {
            DataAccess.Player player = new DataAccess.Player
            {
                IdPlayer = 1,
                Nickname = "Zhircon",
                Email = "agnizahir@gmail.com",
                Password = "A1G2n3i4zhircon."
            };
            Logic.OperationResult operationResult = Logic.PlayerManager.UpdatePlayer(player);
            Assert.AreEqual(operationResult, Logic.OperationResult.Sucessfull);
        }
        [TestMethod]
        public void UpdateConfigurationSucessfull()
        {
            DataAccess.Configuration  configuration = new DataAccess.Configuration
            {
                IdConfiguration = 1,
                volMusic = 20,
                language = "es"
            };
            Logic.OperationResult operationResult = Logic.ConfigurationManager.UpdateConfiguration(configuration);
            Assert.AreEqual(operationResult, Logic.OperationResult.Sucessfull);
        }
        public void UpdateReationshipSucessful()
        {
            int idPlayerOwner = 1;
            int idPlayerGuest = 2;
            var operationResult= Logic.RelationshipManager.DeclarateBadRelationship(idPlayerOwner, idPlayerGuest);
            Assert.AreEqual(operationResult, Logic.OperationResult.Sucessfull);
        }
    }
}
