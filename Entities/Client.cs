using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        /// Идентификатор
        /// </summary>
        [ReadOnly(true)]
        public Guid Id { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [Display(Name = "Отчество")]
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
        [Display(Name="Дата Рождения")]
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Название банка
        /// </summary>
        [ReadOnly(true)]
        public string NameBank { get; set; }
    }
}
