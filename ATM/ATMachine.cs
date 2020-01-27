using ATM;
using ATM.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATM
{
    public class ATMachine : IATMachine
    {
        public Money CardBalance;
        public Dictionary<string, decimal> userList = new Dictionary<string, decimal>
        {
            { "44444", 10 }
        };  
        public string Manufacter { get; }
        public string CardNumber { get; set; }
        public string SerialNumber { get; }

        public ATMachine(string manufacter, string serialNumber)
        {
            Manufacter = manufacter;
            SerialNumber = serialNumber;
        }
        public decimal GetCardBalance()
        {
            return userList[CardNumber];
        }

        public void InsertCard(string cardNumber)
        {
            bool pass = false;
            
            foreach (var card in userList.Keys)
            {
                if (card == cardNumber)
                {
                   pass = true;
                   CardNumber = cardNumber;
                }
            }
            if (pass)
            {
                Console.WriteLine("Your card is inserted!");
                Console.WriteLine(new string('-', 30));
            }
            else
            {
                throw new NoCardInsertedException();
            }
        }

        public void LoadMoney(Money money)
        {
            CardBalance.Amount += money.Amount;
            Console.WriteLine(CardBalance.Amount);
        }

        public IEnumerable<Fee> RetrieveChargedFees()
        {
            throw new NotImplementedException();
        }

        public void ReturnCard()
        {
            Console.WriteLine("Your card has been returned to you!");
            Thread.Sleep(2000);
            Environment.Exit(1);
        }

        public Money WithdrawMoney(int amount)
        {
            throw new Exception();
        }
    }
}
