using ATM.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ATM.Test
{
    [TestClass]
    public class ATMTest
    {
        private ATMachine atm;
        private Money money;

        [TestInitialize]
        public void TestInitialize()
        {
            atm = new ATMachine("ATMPRO", "12345");
            money = new Money();
        }

        [TestMethod]
        public void TestATM()
        {
            Assert.AreEqual(atm.Manufacter, "ATMPRO");
            Assert.AreEqual(atm.SerialNumber, "12345");
        }

        #region InsertCard
        [TestMethod]
        public void InsertCard_CorrectCardNumber_Inserted()
        {
            atm.InsertCard("44444");
            Assert.AreEqual(atm.CardNumber, "44444");
        }

        [TestMethod]
        public void InsertCard_CardAlreadyInserted_Throws()
        {
            atm.InsertCard("44444");
            Assert.ThrowsException<CardAlreadyInATMException>(() => atm.InsertCard("11111"));
        }

        [TestMethod]
        public void InsertCard_InvalidCardNumber_Throws()
        {
            Assert.ThrowsException<WrongCardNumberException>(() => atm.InsertCard("88888"));
        }
        #endregion

        #region GetBalance
        [TestMethod]
        public void GetBalance_CorrectBalance_GotBalance()
        {
            atm.InsertCard("44444");
            atm.GetCardBalance();
            Assert.AreEqual(atm.cardList["44444"], 10);
        }

        [TestMethod]
        public void GetBalance_WithoutInsertedCard_Throws()
        {
            Assert.ThrowsException<CardIsNotInsertedException>(() => atm.GetCardBalance());
        }
        #endregion

        #region CardReturn
        [TestMethod]
        public void CardReturn_FromEmptyAtm_Throws()
        {
            Assert.ThrowsException<CardIsNotInsertedException>(() => atm.ReturnCard());
        }

        [TestMethod]
        public void CardReturn_Success()
        {
            atm.InsertCard("11111");
            atm.ReturnCard();
            Assert.IsTrue(string.IsNullOrEmpty(atm.CardNumber));
        }
        #endregion

        #region WithdrawMoney
        [TestMethod]
        public void WithdrawMoney_ValidAmount()
        {
            atm.InsertCard("44444");
            atm.cardList["44444"] = 150;
            atm.WithdrawMoney(100);
            var fees = atm.RetrieveChargedFees();
            var firstFee = fees.FirstOrDefault();
            Assert.AreEqual(firstFee.CardNumber, "44444");
            Assert.AreEqual(firstFee.WithdrawalFeeAmount, 1);
            Assert.AreEqual(atm.cardList["44444"], 49);
        }

        [TestMethod]
        public void WithdrawMoney_FromEmptyATM_Throws()
        {
            Assert.ThrowsException<CardIsNotInsertedException>(() => atm.WithdrawMoney(20));
        }

        [TestMethod]
        public void Withdraw_MoneyWithIncorrectAmount_Throws()
        {
            atm.InsertCard("11111");
            Assert.ThrowsException<WrongAmountException>(() => atm.WithdrawMoney(18));
        }

        [TestMethod]
        public void Withdraw_WithLessCardBalanceThanWithdrawalAmount_Throws()
        {
            atm.InsertCard("11111");
            atm.cardList["11111"] = 10;
            Assert.ThrowsException<NotEnoughFundsException>(() => atm.WithdrawMoney(20));
        }
        #endregion

        #region LoadMoney
        [TestMethod]
        public void LoadMoney_CorrectAmountAndPaperNotes_SuccessLoad()
        {
            money.Amount = 85;
            money.Notes = new Dictionary<PaperNote, int>
            {
                { PaperNote.FiveEuro, 1 },
                { PaperNote.TenEuro, 1 },
                { PaperNote.TwentyEuro, 1 },
                { PaperNote.FiftyEuro, 1 }
            };

            atm.LoadMoney(money);
            Assert.AreEqual(atm.ATMCash.Notes[PaperNote.FiveEuro], 1);
            Assert.AreEqual(atm.ATMCash.Notes[PaperNote.TenEuro], 1);
            Assert.AreEqual(atm.ATMCash.Notes[PaperNote.TwentyEuro], 1);
            Assert.AreEqual(atm.ATMCash.Notes[PaperNote.FiftyEuro], 1);
            Assert.AreEqual(atm.ATMCash.Amount, 85);
        }

        [TestMethod]
        public void LoadMoney_IncorrectAmountOfPaperNotes_Fail()
        {
            money.Amount = 110;
            money.Notes = new Dictionary<PaperNote, int>
            {
                { PaperNote.FiveEuro, 3 },
                { PaperNote.TenEuro, 2 },
                { PaperNote.TwentyEuro, 1 },
                { PaperNote.FiftyEuro, 1 }
            };

            Assert.ThrowsException<WrongAmountException>(() => atm.LoadMoney(money));
        }
        #endregion
    }
}
