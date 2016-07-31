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
        /// <param name="bank"></param>
        /// <returns></returns>
        public bool DeleteBank(Bank bank)
        {
            try
            {
                _repository.DeleteBank(bank);
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
        /// <param name="client"></param>
        /// <returns></returns>
        public bool DeleteClient(Client client)
        {
            try
            {
                _repository.DeleteClient(client);
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
        /// <param name="bank"></param>
        /// <returns></returns>
        public bool UpdateBank(Bank oldBank, Bank newBank)
        {
            try
            {
                _repository.UpdateBank(oldBank, newBank);
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
        /// <param name="client"></param>
        /// <returns></returns>
        public bool UpdateClient(Client oldClient, Client newClient)
        {
            try
            {
                _repository.UpdateClient(oldClient, newClient);
                return true;
            }
            catch (RepositoryException ex)
            {
                return false;
            }
        }



    }
}
