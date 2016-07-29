using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities
{
    /// <summary>
    /// Класс для описания сущности Банк
    /// </summary>
    [Serializable]
    public class Client
    {

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Полное имя
        /// </summary>
        [XmlIgnore]
        public string FullName
        {
            get
            {
                return String.Format("{0} {1} {2}", LastName, FirstName, MiddleName);
            }
        }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Название банка
        /// </summary>
        public string NameBank { get; set; }
    }
}
