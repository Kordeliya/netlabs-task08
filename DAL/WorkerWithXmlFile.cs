using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL
{
    public static class WorkerWithXmlFile
    {
        /// <summary>
        /// Считывание данных с файла хранилища
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file">путь к файлу</param>
        /// <returns></returns>
        public static IQueryable<T> Read<T>(string file)
        {
            IQueryable<T> result;
            if (File.Exists(file))
            {
                using (FileStream fileStream = new FileStream(file, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                    result = ((List<T>)serializer.Deserialize(fileStream)).AsQueryable();
                }
                return result;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Записать в файл данные, если файл существует он перезапишется
        /// </summary>
        /// <typeparam name="T">тип записываемых данных</typeparam>
        /// <param name="data">данные</param>
        /// <param name="file">путь к файлу</param>
        /// <returns></returns>
        public static bool Write<T>(List<T> data, string file)
        {
            try
            {
                using (FileStream fileStream = new FileStream(file, FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                    serializer.Serialize(fileStream, data);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
