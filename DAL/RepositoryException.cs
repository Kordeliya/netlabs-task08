using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Исключения при работе с репозиторием
    /// </summary>
    [Serializable]
    public class RepositoryException: Exception
    {

        public RepositoryException()
            : base()
        {
        }

        public RepositoryException(string message)
            : base(message)
        {
        }

        protected RepositoryException(SerializationInfo info, StreamingContext context)
            :base(info,context)
        {
        }

        public RepositoryException(string message, Exception innerException)
            :base(message,innerException)
        {
        }
    }
}
