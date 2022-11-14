using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BinarySerialization<T> : ISerializeData<T>
    {
        public void Serialize(T data, string filePath)
        {
            filePath = filePath + ".bin";
            BinaryFormatter formatter = new BinaryFormatter();

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            /*
                        using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
                        {
                            formatter.Serialize(fileStream, data);
                        }

            */

            using (FileStream fileStream = File.Create(filePath))
            {
                formatter.Serialize(fileStream, data);
            }


        }

        public T Deserialize(string filePath)
        {
            T obj;
            filePath = filePath + ".bin";

            BinaryFormatter formatter = new BinaryFormatter();

            if (File.Exists(filePath))
            {
                using (FileStream fileStream = File.OpenRead(filePath)) 
                {
                    obj = (T)formatter.Deserialize(fileStream);
                }
                return obj;
            }
            else 
            {
                throw new Exception("File doesnt exists");
            }
        }
    }
}
