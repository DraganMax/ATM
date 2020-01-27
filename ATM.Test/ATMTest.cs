using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATM.Test
{
    [TestClass]
    public class ATMTest
    {
        [TestMethod]
        public void TestATM()
        {
            ATMachine atm = new ATMachine("ATMPRO", "12345");

            Assert.AreEqual(atm.Manufacter, "ATMPRO");
            Assert.AreEqual(atm.SerialNumber, "12345");
        }

        [TestMethod]

        public void TestCardInsert()
        {
            ATMachine atm = new ATMachine("ATMPRO", "12345");
        }
    }
}
