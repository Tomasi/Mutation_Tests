using BankAccountNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTests
{
    [TestClass]
    public class BankCreditAccountTests
    {
        [TestMethod]
        public void Credit_With_Value_Less_Than_Zero()
        {
            double beginningBalance = 25;
            double limitAccount = 1000;
            double creditAmount = -10;
            BankAccount account = new("Mr. Bryan Walton", beginningBalance, limitAccount);

            try
            {
                account.Credit(creditAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.CreditAmountLessThanZeroMessage);
                return;
            }

            Assert.Fail("The expect exception was not throw.");
        }

        [TestMethod]
        public void Value_Exceeds_Limit_Account()
        {
            double beginningBalance = 25;
            double limitAccount = 500;
            double creditAmount = 1000;
            BankAccount account = new("Mr. Bryan Walton", beginningBalance, limitAccount);

            try
            {
                account.Credit(creditAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.CreditAmountExceedsLimitsAccount);
                return;
            }

            Assert.Fail("The expect exception was not throw.");
        }

    }
}
