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
    public class UpdateTests
    {
        BuisnessLogic.LogicBankSystem _logic = new BuisnessLogic.LogicBankSystem("D:/input.xml");
        [TestMethod]
        public void CheckUpdateBank()
        {
            Bank oldbank = new Bank
            {
                Name = "ВТБ",
            };
            Bank newBank = new Bank
            {
                Name = "ВТБ24",
            };
            Assert.IsTrue(_logic.UpdateBank(oldbank, newBank));

        }

        [TestMethod]
        public void CheckUpdateClient()
        {
            Client client = _logic.GetListClient(new Client { LastName = "Меркушкин" }).FirstOrDefault();
            Client newClient = new Client { LastName = "Мерккушкин",FirstName = client.FirstName, MiddleName = client.MiddleName, NameBank = client.NameBank, BirthDay = client.BirthDay };
            Assert.IsTrue(_logic.UpdateClient(client, newClient));

        }


    }
}
