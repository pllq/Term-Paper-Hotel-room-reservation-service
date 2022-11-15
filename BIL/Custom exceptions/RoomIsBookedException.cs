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
            throw new RoomIsBookedException("Room is booked by another customer.\n");
        }

        public RoomIsBookedException(string message)
            : base(String.Format("Room is booked by another customer.\n"))
        {
        }

        public RoomIsBookedException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}
