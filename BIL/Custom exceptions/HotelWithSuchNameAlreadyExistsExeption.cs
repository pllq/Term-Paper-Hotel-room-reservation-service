using BIL.Custom_exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL
{
    public class HotelWithSuchNameAlreadyExistsExeption : Exception
    {
        public HotelWithSuchNameAlreadyExistsExeption() => throw new HotelWithSuchNameAlreadyExistsExeption("ERROR: Hotel with such name already created.");

        public HotelWithSuchNameAlreadyExistsExeption(string message) : base(String.Format($"{message}\n")) {}

        public HotelWithSuchNameAlreadyExistsExeption(string message, Exception inner) : base(message, inner) {}
    }
}

