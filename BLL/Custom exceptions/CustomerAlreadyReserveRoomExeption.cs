using BaseLibS.Num;
using BLL.Custom_exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Custom_exceptions
{
    internal class CustomerAlreadyReserveRoomExeption : Exception
    {
        public CustomerAlreadyReserveRoomExeption() => throw new CustomerDidntReserveRoomExeption("ERROR: Customer have already reserved a room.");

        public CustomerAlreadyReserveRoomExeption(string message) : base(String.Format($"{message}\n")) { }

        public CustomerAlreadyReserveRoomExeption(string message, Exception inner) : base(message, inner) { }
    }
}
