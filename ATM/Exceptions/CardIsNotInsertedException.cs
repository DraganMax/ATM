using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Exceptions
{
    public class CardIsNotInsertedException : Exception
    {
        public CardIsNotInsertedException() : base ("Card is not inserted!")
        {

        }
    }
}
