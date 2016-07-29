using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic
{
    public class Logic
    {
        IRepository _repository;

        public Logic(string file)
        {
            _repository = new XmlRepository(file);
        }

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

        public List<Bank> GetListBank(Bank filter = default(Bank))
        {
            List<Bank> result = new List<Bank>();
            result = _repository.ReadListBank(filter).ToList();
            return result;
        }

        public List<Client> GetListClient(Client filter = default(Client))
        {
            List<Client> result = new List<Client>();
            result = _repository.ReadListClient(filter).ToList();
            return result;
        }

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



    }
}
