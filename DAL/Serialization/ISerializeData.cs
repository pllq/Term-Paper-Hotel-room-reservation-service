using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ISerializeData<T>
    {
        public void Serialize(T data, string filePath);

        public T Deserialize(string filePath);
    }
}
