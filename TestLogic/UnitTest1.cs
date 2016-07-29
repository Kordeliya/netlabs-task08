using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using System.Collections.Generic;

namespace TestLogic
{
    [TestClass]
    public class UnitTest1
    {
        BuisnessLogic.Logic _logic = new BuisnessLogic.Logic("D:/input.xml");
        [TestMethod]
        public void CheckAddBank()
        {
            Bank bank = new Bank
                {
                    Name = "ВТБ",
                    Clients = new List<Client> { 
                            new Client { LastName="Меркушкин",FirstName="Андрей", MiddleName ="Федорович",
                                        BirthDay=new DateTime(1991,4,20), NameBank="Сбербанк"},
                            new Client { LastName="Меркушкина",FirstName="Феодосья", MiddleName ="Дмириевна",
                                        BirthDay=new DateTime(1968,8,1), NameBank="Сбербанк"},
                            new Client { LastName="Мамаева",FirstName="Кристина", MiddleName ="Олеговна",
                                        BirthDay=new DateTime(1963,12,18), NameBank="Сбербанк"},
                            new Client{ LastName="Шутов",FirstName="Вячеслав", MiddleName ="Дмитриевич",
                                        BirthDay=new DateTime(1993,6,17), NameBank="Сбербанк"}
                        }
                };
            bool result = _logic.AddNewBank(bank);
            Assert.IsTrue(result);


        }
        [TestMethod]
        public void CheckGetListBanks()
        {
            List<Bank> banks = _logic.GetListBank();
            Assert.AreEqual(banks.Count, 1);
            Assert.AreEqual(banks[0].Name, "ВТБ");
        }

        [TestMethod]
        public void CheckAddNewClient()
        {
            Client client = new Client
            {
                LastName = "Авосина",
                FirstName = "Антонина",
                MiddleName = "Анатольевна",
                BirthDay = new DateTime(1985,02,01),
                NameBank = "ВТБ"

            };
            bool result = _logic.AddNewClient(client);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GetListClient()
        {
            List<Client> clients = _logic.GetListClient(new Client { LastName = "Мерк" });
            Assert.IsTrue(clients.Count>0);
            Assert.AreEqual(clients[0].LastName, "Меркушкин");
        }
    }
}
