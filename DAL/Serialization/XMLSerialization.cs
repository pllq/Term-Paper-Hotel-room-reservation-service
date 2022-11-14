using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DAL
{
    public class XMLSerialization<T> : ISerializeData<T>
    {
        public void Serialize(T data, string filePath)
        {
            filePath = filePath + ".xml";

            XmlSerializer xMLSerialization = new XmlSerializer(typeof(T));

            if (File.Exists(filePath)) 
            { 
                File.Delete(filePath);
            }

            using(StreamWriter writer = new StreamWriter(filePath)) 
            {
                xMLSerialization.Serialize(writer, data);
            }
        }

        public T Deserialize(string filePath)
        {
            filePath = filePath + ".xml";

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
