using BankAccountNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTests
{
    [TestClass]
    public class BankDepositAccountTests
    {
        [TestMethod]
        public void Deposit_Amount_Less_Than_Zero() {
            double beginningBalance = 11.99;
            double depositAmount = 4.55;
            double limitAccount = 1000;
            double expected = 7.44;
            BankAccount account = new("Mr. Bryan Walton", beginningBalance, limitAccount);

            try
            {
                account.DepositAmount(depositAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DepositAmountLessThanZero);
                return;
            }
        }

        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 11.99;
            double depositAmount = 4.55;
            double limitAccount = 1000;
            double expected = 7.44;
            BankAccount account = new("Mr. Bryan Walton", beginningBalance, limitAccount);

            account.DepositAmount(depositAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "Account not debited correctly");
        }
    }
}
