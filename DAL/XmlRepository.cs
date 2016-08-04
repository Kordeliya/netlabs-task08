using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Реализация для работы с Xml хранилищем
    /// </summary>
    public class XmlRepository : IRepository
    {
        public XmlRepository(string fileName)
        {
            InputFile = fileName;
        }

        /// <summary>
        /// Имя файла хранилища
        /// </summary>
        public string InputFile { get; private set; }


        /// <summary>
        /// Создание нового клиента
        /// </summary>
        /// <param name="client"></param>
        /// <param name="idBank"></param>
        public void CreateNewClient(Client client, Guid idBank)
        {
            Bank seekingBank = null;
            List<Bank> banks = this.ReadListBank().ToList();
            if (banks.Count() > 0)
            {
                seekingBank = banks.Where(b => b.Id == idBank).FirstOrDefault();
            }
            if (seekingBank != null)
            {
                client.Id = Guid.NewGuid();
                client.NameBank = seekingBank.Name;
                seekingBank.Clients.Add(client);
                WorkerWithXmlFile.Write<Bank>(banks, InputFile);
            }
            else
            {
                throw new RepositoryException("Не существует указанного банка");
            }

        }

        /// <summary>
        /// Создание нового банка
        /// </summary>
        /// <param name="bank"></param>
        public void CreateNewBank(Bank bank)
        {
            Bank seekingBank = null;
            var banks = this.ReadListBank();
            if (banks != null && banks.Count() > 0)
            {
                seekingBank = banks.Where(b => b.Name == bank.Name).FirstOrDefault();
            }
            else
            {
                banks = new List<Bank>();
            }

            if (seekingBank != null)
            {
                throw new RepositoryException("Существует банк с таким названием");
            }
            bank.Id = Guid.NewGuid();
            banks.Add(bank);
            WorkerWithXmlFile.Write<Bank>(banks.ToList(), InputFile);
        }

        /// <summary>
        /// Получение списка клиентов в соответствии с фильтром
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IList<Client> ReadListClient(Client filter = default(Client))
        {
            IQueryable<Client> result;
            List<Client> clients = new List<Client>();
            try
            {
                var banks = WorkerWithXmlFile.Read<Bank>(InputFile);
                if (!String.IsNullOrEmpty(filter.NameBank))
                {
                    banks = (IQueryable<Bank>)banks.Where(b => b.Name.ToLower().StartsWith(filter.NameBank.ToLower()));
                }

                foreach (var bank in banks)
                {
                    clients.AddRange(bank.Clients);
                }
                result = clients.AsQueryable();
                if (filter != null)
                {
                    if (!String.IsNullOrEmpty(filter.LastName))
                    {
                        result = result.Where(c => c.LastName.ToLower().StartsWith(filter.LastName.ToLower()));
                    }
                    if (!String.IsNullOrEmpty(filter.FirstName))
                    {
                        result = result.Where(c => c.FirstName.ToLower().StartsWith(filter.FirstName.ToLower()));
                    }
                    if (!String.IsNullOrEmpty(filter.MiddleName))
                    {
                        result = result.Where(c => c.MiddleName.ToLower().StartsWith(filter.MiddleName.ToLower()));
                    }
                    if (!String.IsNullOrEmpty(filter.NameBank))
                    {
                        result = result.Where(c => c.NameBank.ToLower().StartsWith(filter.NameBank.ToLower()));
                    }
                }

                return result.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Получение списка банков в соответствии с фильтром
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IList<Bank> ReadListBank(Bank filter = default(Bank))
        {
            IQueryable<Bank> banks = WorkerWithXmlFile.Read<Bank>(InputFile);

            if (banks != null && filter != null)
            {
                if(filter.Id != null)
                {
                    banks = banks.Where(c => c.Id == filter.Id);
                }
                if(!String.IsNullOrEmpty(filter.Name))
                {
                    banks = banks.Where(c => c.Name.ToLower().StartsWith(filter.Name.ToLower()));
                }
            }
            return banks != null ? banks.ToList() : null;
        }
        
        /// <summary>
        /// Обновление данных о клиенте
        /// </summary>
        /// <param name="oldClient"></param>
        /// <param name="newClient"></param>
        public void UpdateClient(Client newClient)
        {
            IQueryable<Client> result;
            List<Client> clients = new List<Client>();
            try
            {
                var banks = WorkerWithXmlFile.Read<Bank>(InputFile);

                foreach (var bank in banks)
                {
                    clients.AddRange(bank.Clients);
                }
                result = clients.AsQueryable();
                if (newClient.Id != null)
                {
                    result = result.Where(c => c.Id == newClient.Id);
                }
                if (result != null)
                {
                    var client = result.FirstOrDefault();
                    if (client != null)
                    {
                        client.FirstName = newClient.FirstName;
                        client.LastName = newClient.LastName;
                        client.MiddleName = newClient.MiddleName;
                        client.NameBank = newClient.NameBank;
                        client.BirthDay = newClient.BirthDay;
                    }
                    WorkerWithXmlFile.Write<Bank>(banks.ToList(), InputFile);
                }
            }
            catch (Exception)
            {
                throw new RepositoryException("Ошибка при обновлении данных клиента");
            }
        }

        /// <summary>
        /// Обновление данных о Банке
        /// </summary>
        /// <param name="oldBank"></param>
        /// <param name="newBank"></param>
        public void UpdateBank(Bank newBank)
        {
            try
            {
                if (newBank != null && newBank.Id != null)
                {
                    Bank seekingBank = null;
                    var banks = this.ReadListBank();
                    if (banks != null && banks.Count() > 0)
                    {
                        seekingBank = banks.Where(b => b.Id == newBank.Id).FirstOrDefault();
                    }
                    else
                    {
                        banks = new List<Bank>();
                    }

                    if (seekingBank != null)
                    {
                        seekingBank.Name = newBank.Name;
                        WorkerWithXmlFile.Write<Bank>(banks.ToList(), InputFile);
                    }
                    else
                    {
                        throw new RepositoryException("Не существует указанного банка");
                    }
                }
                else
                {
                    throw new RepositoryException("Не верно переданы данные для обновления");
                }

            }
            catch (Exception ex)
            {
                throw new RepositoryException("Ошибка при обновлении данных банка");
            }
        }

        /// <summary>
        /// Удаление клиента
        /// </summary>
        /// <param name="client"></param>
        public void DeleteClient(Guid id)
        {
            IQueryable<Client> result;
            List<Client> clients = new List<Client>();
            var banks = WorkerWithXmlFile.Read<Bank>(InputFile);

            foreach (var bank in banks)
            {
                clients.AddRange(bank.Clients);
            }
            result = clients.AsQueryable();
            if (id != null)
            {
                var client = result.Where(c=>c.Id==id).FirstOrDefault();
                if (client != null)
                {
                    result.ToList().Remove(client);
                    WorkerWithXmlFile.Write<Bank>(banks.ToList(), InputFile);
                }
                else
                {
                    throw new RepositoryException("Не существует указанного клиента");
                }
            }
            else
            {
                throw new RepositoryException("Не передан Идентификатор удаляемого объекта");
            }
        }

        /// <summary>
        /// Удаление банка
        /// </summary>
        /// <param name="bank"></param>
        public void DeleteBank(Guid Id)
        {
            Bank seekingBank = null;
            if (Id != null)
            {
                List<Bank> banks = this.ReadListBank().ToList();
                if (banks.Count() > 0)
                {
                    seekingBank = banks.Where(b => b.Id == Id).FirstOrDefault();
                }

                if (seekingBank == null)
                {
                    throw new RepositoryException("Не существует банк с таким названием");
                }
                banks.Remove(seekingBank);
                WorkerWithXmlFile.Write<Bank>(banks, InputFile);
            }
            else
            {
                throw new RepositoryException("Не передан Идентификатор удаляемого объекта");
            }
        }
    }
}
