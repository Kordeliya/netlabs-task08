using DAL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLogic
{
    [TestClass]
    public class GetTests
    {
        BuisnessLogic.LogicBankSystem _logic = new BuisnessLogic.LogicBankSystem(new XmlRepository("D:/input.xml"));
        [TestMethod]
        public void CheckGetListBanks()
        {
            List<Bank> banks = _logic.GetListBank();
            Assert.AreEqual(banks.Count, 1);
            Assert.AreEqual(banks[0].Name, "ВТБ");
        }

        [TestMethod]
        public void GetListClient()
        {
            List<Client> clients = _logic.GetListClient(new Client { LastName = "Мерк" });
            Assert.IsTrue(clients.Count > 0);
            Assert.AreEqual(clients[0].LastName, "Меркушкин");
        }

    }
}
