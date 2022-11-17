using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL
{
    public class CustomerAlreadyCreatedExeption : Exception
    {
        public CustomerAlreadyCreatedExeption() => throw new CustomerAlreadyCreatedExeption("ERROR: Such customer already on the list.");

        public CustomerAlreadyCreatedExeption(string message) : base(String.Format($"{message}\n")) { }

        public CustomerAlreadyCreatedExeption(string message, Exception inner) : base(message, inner) { }
    }
}
