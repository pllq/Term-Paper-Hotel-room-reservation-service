using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BIL
{
    public class CustomerListIsEmptyExeption : Exception
    {
        public CustomerListIsEmptyExeption()
        {
        }

        public CustomerListIsEmptyExeption(string message)
            : base(String.Format($"You have created {message} customers. In order to view or remove customer, you have to create it.", message))
        {
        }

        public CustomerListIsEmptyExeption(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
