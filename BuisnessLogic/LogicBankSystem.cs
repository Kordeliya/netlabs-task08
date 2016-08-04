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

        public LogicBankSystem(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Добавление нового банка
        /// </summary>
        /// <param name="bank">банк</param>
        public void AddNewBank(Bank bank)
        {
            _repository.CreateNewBank(bank);
        }

        /// <summary>
        /// Добавление банковского клиента
        /// </summary>
        /// <param name="client">клиент</param>
        /// /// <param name="idBank">идентификатор банка</param>
        public void AddNewClient(Client client, Guid idBank)
        {
            _repository.CreateNewClient(client, idBank);
        }

        /// <summary>
        /// Получение списка банков
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<Bank> GetListBank(Bank filter = default(Bank))
        {
            
            var result = _repository.ReadListBank(filter);
            return result != null ? result.ToList() : null;
        }

        /// <summary>
        /// Получение списка клиентов
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<Client> GetListClient(Client filter = default(Client))
        {
            var result = _repository.ReadListClient(filter);
            return result!= null ? result.ToList() : null;

        }

        /// <summary>
        /// Удаление банка
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBank(Guid id)
        {
            _repository.DeleteBank(id);
        }

        /// <summary>
        /// Удаление клиента
        /// </summary>
        /// <param name="id"></param>
        public void DeleteClient(Guid id)
        {
            _repository.DeleteClient(id);
        }

        /// <summary>
        /// Обновление банка
        /// </summary>
        /// <param name="newBank"></param>
        public void UpdateBank(Bank newBank)
        {
            _repository.UpdateBank(newBank);
        }

        /// <summary>
        /// Обновление клиента
        /// </summary>
        /// <param name="newClient"></param>
        public void UpdateClient(Client newClient)
        {
            _repository.UpdateClient(newClient);
        }



    }
}
