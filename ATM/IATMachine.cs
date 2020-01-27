using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IATMachine
    {
        string Manufacter { get; }
        string SerialNumber { get; }
        void InsertCard(string cardNumber);
        decimal GetCardBalance();
        Money WithdrawMoney(int amount);
        void ReturnCard();
        void LoadMoney(Money money);
        IEnumerable<Fee> RetrieveChargedFees();
    }
}
