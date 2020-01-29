using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Exceptions
{
    public class CardAlreadyInATMException : Exception
    {
        public CardAlreadyInATMException() : base("Card already in ATM!")
        {

        }
    }
}
