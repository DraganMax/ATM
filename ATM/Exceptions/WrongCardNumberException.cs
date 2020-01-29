using System;

namespace ATM.Exceptions
{
    public class WrongCardNumberException : Exception
    {
        public WrongCardNumberException() : base ("Wrong card number!")
        {
        }
    }
}
