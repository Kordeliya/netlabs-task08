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



    }
}
