using System.Collections.Generic;

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
