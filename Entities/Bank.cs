using System;
using System.Collections.Generic;
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
        /// Название банка
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список клиентов
        /// </summary>
        public List<Client> Clients { get; set; }
    }
}
