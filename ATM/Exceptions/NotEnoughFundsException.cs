using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Exceptions
{
    public class NotEnoughFundsException : Exception
    {
        public NotEnoughFundsException() : base("Withdrawal failed. You do not have enough fund to withdraw.")
        {

        }
    }
}
