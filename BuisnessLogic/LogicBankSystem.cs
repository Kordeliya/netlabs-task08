using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic
{
    public class LogicBankSystem
    {
        IRepository _repository;

        public LogicBankSystem(string file)
        {
            _repository = new XmlRepository(file);
        }

        /// <summary>
        /// Добавление нового банка
        /// </summary>
        /// <param name="bank">банк</param>
        /// <returns></returns>
        public bool AddNewBank(Bank bank)
        {
            try
            {
                _repository.CreateNewBank(bank);
                return true;
            }
            catch (RepositoryException ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Добавление банковского клиента
        /// </summary>
        /// <param name="client">клиент</param>
        /// <returns></returns>
        public bool AddNewClient(Client client)
        {
            try
            {
                _repository.CreateNewClient(client);
                return true;
            }
            catch (RepositoryException ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Получение списка банков
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<Bank> GetListBank(Bank filter = default(Bank))
        {
            List<Bank> result = new List<Bank>();
            result = _repository.ReadListBank(filter).ToList();
            return result;
        }

        /// <summary>
        /// Получение списка клиентов
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<Client> GetListClient(Client filter = default(Client))
        {
            List<Client> result = new List<Client>();
            result = _repository.ReadListClient(filter).ToList();
            return result;
        }

        /// <summary>
        /// Удаление банка
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteBank(Guid id)
        {
            try
            {
                _repository.DeleteBank(id);
                return true;
            }
            catch (RepositoryException ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Удаление клиента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteClient(Guid id)
        {
            try
            {
                _repository.DeleteClient(id);
                return true;
            }
            catch (RepositoryException ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Обновление банка
        /// </summary>
        /// <param name="newBank"></param>
        /// <returns></returns>
        public bool UpdateBank(Bank newBank)
        {
            try
            {
                _repository.UpdateBank(newBank);
                return true;
            }
            catch (RepositoryException ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Обновление клиента
        /// </summary>
        /// <param name="newClient"></param>
        /// <returns></returns>
        public bool UpdateClient(Client newClient)
        {
            try
            {
                _repository.UpdateClient(newClient);
                return true;
            }
            catch (RepositoryException ex)
            {
                return false;
            }
        }



    }
}
