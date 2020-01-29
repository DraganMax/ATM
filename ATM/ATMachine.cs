using ATM;
using ATM.Exceptions;
using System;
using System.Collections.Generic;

namespace ATM
{
    public class ATMachine : IATMachine
    {
        public List<Fee> ClientFees = new List<Fee>();
        public string Manufacter { get; }
        public string CardNumber { get; set; }
        public string SerialNumber { get; }

        public Money ATMCash;

        public Dictionary<string, decimal> cardList = new Dictionary<string, decimal>
        {
            { "44444", 10 },
            { "22222", 45 },
            { "11111", 19 }
        };
        public ATMachine(string manufacter, string serialNumber)
        {
            Manufacter = manufacter;
            SerialNumber = serialNumber;

            ATMCash.Notes = new Dictionary<PaperNote, int> {
                { PaperNote.FiveEuro, 0 },
                { PaperNote.TenEuro, 0 },
                { PaperNote.TwentyEuro, 0 },
                { PaperNote.FiftyEuro, 0 }
            };
        }
        public decimal GetCardBalance()
        {
            if (CardNumber == null)
            {
                throw new CardIsNotInsertedException();
            }
            return cardList[CardNumber];
        }

        public void InsertCard(string cardNumber)
        {
            if (!string.IsNullOrEmpty(CardNumber))
            {
                throw new CardAlreadyInATMException();
            }
            else if (cardList.ContainsKey(cardNumber))
            {
                CardNumber = cardNumber;
            }
            else
            {
                throw new WrongCardNumberException();
            }
        }

        public void LoadMoney(Money money)
        {
            if(!MoneyValidation.CorrectNotesAndMoneyAmount(money))
            {
                throw new WrongAmountException();
            }
            ATMCash.Amount += money.Amount;
            ATMCash.Notes[PaperNote.FiveEuro] += money.Notes[PaperNote.FiveEuro];
            ATMCash.Notes[PaperNote.TenEuro] += money.Notes[PaperNote.TenEuro];
            ATMCash.Notes[PaperNote.TwentyEuro] += money.Notes[PaperNote.TwentyEuro];
            ATMCash.Notes[PaperNote.FiftyEuro] += money.Notes[PaperNote.FiftyEuro];
        }

        public IEnumerable<Fee> RetrieveChargedFees()
        {
            return ClientFees;
        }

        public void ReturnCard()
        {
            if (CardNumber == null)
                throw new CardIsNotInsertedException();
            else
            {
                CardNumber = null;
            }
        }

        public Money WithdrawMoney(int amount)
        {
            if (amount % 5 != 0)
            {
                throw new WrongAmountException();
            }
            else if (CardNumber == null)
            {
                throw new CardIsNotInsertedException();
            }
            else if (cardList[CardNumber] < amount)
            {
                throw new NotEnoughFundsException();
            }
            var fee = new Fee
            {
                CardNumber = CardNumber,
                WithdrawalFeeAmount = Convert.ToDecimal(amount * 0.01),
                WithdrawalDate = DateTime.Now
            };
            ClientFees.Add(fee);
            cardList[CardNumber] -= amount + fee.WithdrawalFeeAmount;
            return new Money
            {
                Amount = amount,
                Notes = new Dictionary<PaperNote, int>
                {
                    { PaperNote.FiveEuro, 1 },
                    { PaperNote.TenEuro, 1 },
                    { PaperNote.TwentyEuro, 1 },
                    { PaperNote.FiftyEuro, 1 },
                }
            };
        }
    }
}
