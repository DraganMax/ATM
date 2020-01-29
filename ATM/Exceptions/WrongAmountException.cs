using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Exceptions
{
    public class WrongAmountException : Exception
    {
        public WrongAmountException() : base ("Not correct amount of money! ATM takes and withdraws only 5, 10, 20, 50 paper notes.")
        {

        }
    }
}
