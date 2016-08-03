using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using System.Collections.Generic;

namespace TestLogic
{
    [TestClass]
    public class AddTests
    {
        BuisnessLogic.LogicBankSystem _logic = new BuisnessLogic.LogicBankSystem("D:/input.xml");
        [TestMethod]
        public void CheckAddBank()
        {
            Bank bank = new Bank
                {
                    Id = Guid.NewGuid(),
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
        public void CheckAddNewClient()
        {
            Client client = new Client
            {
                Id=Guid.NewGuid(),
                LastName = "Авосина",
                FirstName = "Антонина",
                MiddleName = "Анатольевна",
                BirthDay = new DateTime(1985,02,01),
                NameBank = "ВТБ"

            };
            bool result = _logic.AddNewClient(client,new Guid(""));
            Assert.IsTrue(result);
        }
        
    }
}
