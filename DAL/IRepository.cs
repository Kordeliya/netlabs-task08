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
        /// /// <param name="idBank"></param>
        void CreateNewClient(Client client, Guid idBank);

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
        /// <param name="newClient"></param>
        void UpdateClient(Client newClient);

        /// <summary>
        /// Обновление списка банка
        /// </summary>
        /// <param name="newBank"></param>
        void UpdateBank(Bank newBank);

        /// <summary>
        /// Удаление клиента
        /// </summary>
        /// <param name="id"></param>
        void DeleteClient(Guid id);

        /// <summary>
        /// Удаление банка
        /// </summary>
        /// <param name="id"></param>
        void DeleteBank(Guid id);

    }
}
