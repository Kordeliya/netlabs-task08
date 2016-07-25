using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL
{
    public class CRUD
    {

        public CRUD(string fileName)
        {
            InputFile = fileName;
        }

        /// <summary>
        /// Имя файла хранилища
        /// </summary>
        public string InputFile { get; private set; }



        /// <summary>
        /// Получение списка клиентов в соответствии с введенным фильтром
        /// </summary>
        /// <param name="filter">фильтр</param>
        /// <returns></returns>
        public List<Client> ReadClientsFilteredList(Client filter)
        {
            List<Client> result = new List<Client>();
            try
            {
                var banks = this.Read<Bank>();
                if (!String.IsNullOrEmpty(filter.NameBank))
                    banks = (List<Bank>)banks.Where(b => b.Name.ToLower().StartsWith(filter.NameBank.ToLower())).ToList();

                foreach (var bank in banks)
                    result.AddRange(bank.Clients);

                if (!String.IsNullOrEmpty(filter.LastName))
                    result = result.Where(c => c.LastName.ToLower().StartsWith(filter.LastName.ToLower())).ToList();
                if (!String.IsNullOrEmpty(filter.FirstName))
                    result = result.Where(c => c.FirstName.ToLower().StartsWith(filter.FirstName.ToLower())).ToList();
                if (!String.IsNullOrEmpty(filter.MiddleName))
                    result = result.Where(c => c.MiddleName.ToLower().StartsWith(filter.MiddleName.ToLower())).ToList();
                if (!String.IsNullOrEmpty(filter.NameBank))
                    result = result.Where(c => c.NameBank.ToLower().StartsWith(filter.NameBank.ToLower())).ToList();

                return result.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// Считывание данных с файла хранилища
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> Read<T>()
        {
            List<T> result;

            using (FileStream file = new FileStream(this.InputFile, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                result = (List<T>)serializer.Deserialize(file);
            }
            return result;

        }


        /// <summary>
        /// Записать в файл данные, если файл существует он перезапишется
        /// </summary>
        /// <typeparam name="T">тип записываемых данных</typeparam>
        /// <param name="data">данные</param>
        /// <returns></returns>
        public bool Write<T>(List<T> data)
        {
            try
            {
                using (FileStream file = new FileStream(this.InputFile, FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                    serializer.Serialize(file, data);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }


        }
        /// <summary>
        /// Удаление
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Delete<T>(T item)
        {
            try
            {
                List<T> list = this.Read<T>();
                list.Remove(item);
                this.Write(list);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
