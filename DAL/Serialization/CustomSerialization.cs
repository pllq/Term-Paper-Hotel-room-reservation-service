using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL
{
    public class CustomSerialization<T> : ISerializeData<T>
    {
        public void Serialize(T data, string filePath)
        {
            filePath = filePath + ".custOMEGALULm";

            XmlSerializer xMLSerialization = new XmlSerializer(typeof(T));

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                xMLSerialization.Serialize(writer, data);
            }
        }

        public T Deserialize(string filePath)
        {
            filePath = filePath + ".custOMEGALULm";

            T obj;

            XmlSerializer formatter = new XmlSerializer(typeof(T));

            if (File.Exists(filePath))
            {
                using (Stream reader = new FileStream(filePath, FileMode.Open))
                {
                    obj = (T)formatter.Deserialize(reader);
                }
                return obj;
            }
            else
            {
                throw new Exception("File doesnt exists.");
            }
        }
    }
}
