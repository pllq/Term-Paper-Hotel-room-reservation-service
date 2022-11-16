using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL.Custom_exceptions
{
    public class CustomerDidntReserveRoomExeption:Exception
    {
        public CustomerDidntReserveRoomExeption()
        {
            throw new CustomerDidntReserveRoomExeption("Customer havent reserved any of rooms.");
        }

        public CustomerDidntReserveRoomExeption(string message)
            : base(String.Format($"{message}\n"))
        {
        }

        public CustomerDidntReserveRoomExeption(string message, Exception inner)
            : base(message, inner)
        {
        }


    }
}
