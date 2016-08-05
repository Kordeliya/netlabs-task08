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
    public class UpdateTests
    {
        BuisnessLogic.LogicBankSystem _logic = new BuisnessLogic.LogicBankSystem(new XmlRepository("D:/input.xml"));
        [TestMethod]
        public void CheckUpdateBank()
        {
            var banks = _logic.GetListBank();
            banks[0].Name = "ВТБ24";

            _logic.UpdateBank(banks[0]);

        }

        [TestMethod]
        public void CheckUpdateClient()
        {
            Client client = _logic.GetListClient(new Client { LastName = "Меркушкин" }).FirstOrDefault();
            client.LastName = "Мерккушкин";
            _logic.UpdateClient(client);

        }


    }
}
