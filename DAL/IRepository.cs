﻿using Entities;
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
        /// <param name="filter"></param>
        void UpdateClient(Client client);

        /// <summary>
        /// Обновление списка банка
        /// </summary>
        /// <param name="bank"></param>
        void UpdateBank(Bank bank);

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