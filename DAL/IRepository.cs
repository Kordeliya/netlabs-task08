using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository
    {
        /// <summary>
        /// Создание нового клиента
        /// </summary>
        /// <param name="client"></param>
        void CreateNewClient(Client client);

        /// <summary>
        /// Создание нового банка
        /// </summary>
        /// <param name="bank"></param>
        void CreateNewBank(Bank bank);

        /// <summary>
        /// Получение списка клиентов в соответствии с фильтром
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IList<Client> ReadListClient(Client filter);

        /// <summary>
        /// Получение списка банка
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IList<Bank> ReadListBank(Bank filter);

        /// <summary>
        /// Обновление данных клиента
        /// </summary>
        /// <param name="oldClient"></param>
        /// <param name="newClient"></param>
        void UpdateClient(Client oldClient, Client newClient);

        /// <summary>
        /// Обновление списка банка
        /// </summary>
        /// <param name="oldBank"></param>
        /// <param name="newBank"></param>
        void UpdateBank(Bank oldBank, Bank newBank);

        /// <summary>
        /// Удаление клиента
        /// </summary>
        /// <param name="client"></param>
        void DeleteClient(Client client);

        /// <summary>
        /// Удаление банка
        /// </summary>
        /// <param name="bank"></param>
        void DeleteBank(Bank bank);

    }
}
