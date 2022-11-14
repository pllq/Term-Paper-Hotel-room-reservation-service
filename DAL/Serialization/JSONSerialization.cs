using Newtonsoft.Json;

namespace DAL
{
    public class JSONSerialization<T> : ISerializeData<T>
    {
        public void Serialize(T data, string filePath)
        {
            filePath = filePath + ".json";
            JsonSerializer formatter = new JsonSerializer();

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (StreamWriter streamWriter = new StreamWriter(filePath))
            using (JsonWriter writer = new JsonTextWriter(streamWriter))
            {
                formatter.Serialize(writer, data);
            }
        }

        public T Deserialize(string filePath)
        {
            T obj;
            filePath = filePath + ".json";

            JsonSerializer formatter = new JsonSerializer();

            if (File.Exists(filePath))
            {
                using (StreamReader streamReader = new StreamReader(filePath))
                using (JsonReader reader = new JsonTextReader(streamReader))
                {
                    obj = JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath));
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
