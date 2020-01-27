using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public struct Fee
    {
        public string CardNumber { get; set; }
        public decimal WithdrawalFeeAmount { get; set; }
        public DateTime WithdrawalDate { get; set; }
    }
}
