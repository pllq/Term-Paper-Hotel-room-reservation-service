using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL.Custom_exceptions
{
    public class RoomIsBookedException : Exception
    {
        public RoomIsBookedException()
        {
            //May be wrong:
            throw new RoomIsBookedException("The room, you have chosen, is already booked by someone.");
        }

        public RoomIsBookedException(string message)
            : base(String.Format($"{message}\n"))
        {
        }

        public RoomIsBookedException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}
