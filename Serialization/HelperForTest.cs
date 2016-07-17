using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    public static class HelperForTest
    {

        /// <summary>
        /// Создание тестового файла с данными
        /// </summary>
        public static void CreateTestInputFile(string nameFile)
        {
            try
            {
                List<Bank> listBanks = new List<Bank>();
                listBanks.AddRange(new List<Bank>
            {
                new Bank
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
                },
                new Bank
                {
                    Name = "Сбербанк",
                    Clients = new List<Client> { 
                            new Client { LastName="Абрамов",FirstName="Андрей", MiddleName ="Дмириевич",
                                        BirthDay=new DateTime(1991,4,20), NameBank="Сбербанк"},
                            new Client { LastName="Каляев",FirstName="Максим", MiddleName ="Дмириевич",
                                        BirthDay=new DateTime(1965,5,1), NameBank="Сбербанк"},
                            new Client { LastName="Мамаева",FirstName="Валерия", MiddleName ="Федоровна",
                                        BirthDay=new DateTime(1981,12,23), NameBank="Сбербанк"},
                            new Client{ LastName="Шутов",FirstName="Геннадий", MiddleName ="Геннадьевич",
                                        BirthDay=new DateTime(1992,9,25), NameBank="Сбербанк"}
                        }
                },
                new Bank
                {
                    Name = "Альфа-банк",
                    Clients = new List<Client> { 
                            new Client { LastName="Афанасьев",FirstName="Кирилл", MiddleName ="Александрович",
                                        BirthDay=new DateTime(1991,8,25), NameBank="Альфа-банк"},
                            new Client { LastName="Афанасьев",FirstName="Сергей", MiddleName ="Александрович",
                                        BirthDay=new DateTime(1974,5,8), NameBank="Альфа-банк"},
                            new Client { LastName="Обломов",FirstName="Александр", MiddleName ="Александрович",
                                        BirthDay=new DateTime(1980,11,23), NameBank="Альфа-банк"},
                            new Client{ LastName="Облачкин",FirstName="Алексей", MiddleName ="Максимович",
                                        BirthDay=new DateTime(1996,9,25), NameBank="Альфа-банк"},
                        }
                },
                new Bank
                {
                    Name = "Русский стандарт",
                    Clients = new List<Client> { 
                            new Client { LastName="Молчанова",FirstName="Мария", MiddleName ="Александровна",
                                        BirthDay=new DateTime(1931,8,20), NameBank="Альфа-банк"},
                            new Client { LastName="Молчанов",FirstName="Илья", MiddleName ="Сергеевич",
                                        BirthDay=new DateTime(1969,1,1), NameBank="Альфа-банк"},
                            new Client { LastName="Ленина",FirstName="Василиса", MiddleName ="Маратовна",
                                        BirthDay=new DateTime(1986,10,2), NameBank="Альфа-банк"},
                            new Client{ LastName="Гердт",FirstName="Марина", MiddleName ="Владимировна",
                                        BirthDay=new DateTime(1991,8,11), NameBank="Альфа-банк"},
                        }
                    }
            }
                );
                using (FileStream file = new FileStream(nameFile, FileMode.OpenOrCreate))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Bank>));
                    serializer.Serialize(file, listBanks);
                }
            }
            catch (Exception)
            {
                //
            }


        }
    }
}
