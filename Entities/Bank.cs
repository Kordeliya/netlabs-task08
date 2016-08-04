using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Класс для описания сущности Банк
    /// </summary>
    [Serializable]
    public class Bank
    {
        /// <summary>
        /// идентификатор
        /// </summary>
        [ReadOnly(true)]
        public Guid Id { get; set; }

        /// <summary>
        /// Название банка
        /// </summary>
        [Display(Name="Название банка")]
        public string Name { get; set; }

        /// <summary>
        /// Список клиентов
        /// </summary>
        public List<Client> Clients { get; set; }
    }
}
