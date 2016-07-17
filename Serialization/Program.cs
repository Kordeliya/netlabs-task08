using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    public class Program
    {
        private static string _nameInputFile;
        private static string _nameOutputFile;

        static void Main(string[] args)
        {
            _nameInputFile = ConfigurationManager.AppSettings["inputFile"].ToString();
            _nameOutputFile = ConfigurationManager.AppSettings["outputFile"].ToString();
            while (true)
            {
                try
                {
                    if (!File.Exists(_nameInputFile))
                        HelperForTest.CreateTestInputFile(_nameInputFile);
                    Client filter = FilterRequest();
                    List<Client> result = GetFiltredClients(filter, _nameInputFile);
                    if (result.Count > 0)
                    {
                        foreach (var client in result)
                            Console.WriteLine("ФИО {0}, Дата рождения {1}, Наименование банка {2}",
                                client.FullName, client.BirthDay, client.NameBank);
                        WriteResultInFile(result);
                        if (File.Exists(_nameOutputFile))
                        {
                            Process.Start(_nameOutputFile);
                        }

                    }
                    else
                        Console.WriteLine("Не найдено! по фильтру {0} {1}", filter.FullName, filter.NameBank);

                }
                catch (Exception)
                {
                    Console.WriteLine("Произошла ошибка!");
                }
                finally
                {
                    Console.WriteLine();
                }
            }

        }

        /// <summary>
        /// Запись результата в файл
        /// </summary>
        /// <param name="result"></param>
        private static void WriteResultInFile(List<Client> result)
        {
            if (File.Exists(_nameOutputFile))
                File.Delete(_nameOutputFile);
            try
            {
                if (File.Exists(_nameInputFile))
                    File.Delete(_nameInputFile);
                using (FileStream file = new FileStream(_nameOutputFile,FileMode.CreateNew))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Client>));
                    serializer.Serialize(file, result);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Получение списка клиентов в соответствии с введенным фильтром
        /// </summary>
        /// <param name="filter">фильтр</param>
        /// <param name="_nameFile">имя файла где хранится список</param>
        /// <returns></returns>
        private static List<Client> GetFiltredClients(Client filter, string nameFile)
        {
            List<Client> result = new List<Client>();
            try
            {
                using (FileStream file = new FileStream(nameFile, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Bank>));
                    var banks = (List<Bank>)serializer.Deserialize(file);
                    if (!String.IsNullOrEmpty(filter.NameBank))
                        banks = (List<Bank>)banks.Where(b => b.Name.ToLower().StartsWith(filter.NameBank.ToLower())).ToList();

                    foreach (var bank in banks)
                        result.AddRange(bank.Clients);

                    if(!String.IsNullOrEmpty(filter.LastName))
                        result = result.Where(c => c.LastName.ToLower().StartsWith(filter.LastName.ToLower())).ToList();
                    if(!String.IsNullOrEmpty(filter.FirstName))
                        result = result.Where(c => c.FirstName.ToLower().StartsWith(filter.FirstName.ToLower())).ToList();
                    if (!String.IsNullOrEmpty(filter.MiddleName))
                        result = result.Where(c => c.MiddleName.ToLower().StartsWith(filter.MiddleName.ToLower())).ToList();
                    if (!String.IsNullOrEmpty(filter.NameBank))
                        result = result.Where(c => c.NameBank.ToLower().StartsWith(filter.NameBank.ToLower())).ToList();

                    return result.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }            
        }

        /// <summary>
        /// Запрос фильтра
        /// </summary>
        /// <returns></returns>
        private static Client FilterRequest()
        {
            Client filter = new Client();
            Console.WriteLine("Введите фамилию полностью или ее начало для фильтра");
            filter.LastName = Console.ReadLine();
            Console.WriteLine("Введите имя полностью или начало имени для фильтра");
            filter.FirstName = Console.ReadLine();
            Console.WriteLine("Введите отчество полностью или начало отчества для фильтра");
            filter.MiddleName = Console.ReadLine();
            Console.WriteLine("Введите название банка полностью или начало его названия для фильтра");
            filter.NameBank = Console.ReadLine();

            return filter;

        }


    }


}
