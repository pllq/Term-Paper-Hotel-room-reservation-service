using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BIL.Custom_exceptions
{
    public class HotelListIsEmptyExeption : Exception
    {
        public HotelListIsEmptyExeption()
        {
        }

        public HotelListIsEmptyExeption(string message)
            : base(String.Format($"You have created {message} hotels. In order to view or remove hotel, you have to create it.", message))
        {
        }

        public HotelListIsEmptyExeption(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
