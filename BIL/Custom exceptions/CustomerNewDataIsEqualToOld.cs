using BIL.Custom_exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL
{
    partial class CustomerNewDataIsEqualToOld : Exception
    {

        public CustomerNewDataIsEqualToOld() {} 

        public CustomerNewDataIsEqualToOld(string message) : base(String.Format($"New {message} the same as old. Customer won't be changed.\n")) { }

        public CustomerNewDataIsEqualToOld(string message, Exception inner) : base(message, inner) { }




    }
}
