namespace BankAccountNS
{
    public class BankAccount
    {
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
        public const string CreditAmountLessThanZeroMessage = "Credit amount is less than zero";
        public const string CreditAmountExceedsLimitsAccount = "Credit amount is more than limit";
        public const string DepositAmountLessThanZero = "Deposit amount is less than limit";

        private readonly string m_customerName;
        private readonly double m_limitAccount;
        private double m_balance;

        private BankAccount() {}

        public BankAccount(string customerName, double balance, double limitAccount){
            m_customerName = customerName;
            m_balance = balance;
            m_limitAccount = limitAccount;
        }


        public string CustomerName{
            get { return m_customerName; }
        }

        public double Balance{
            get { return m_balance; }
        }

        public void DepositAmount(double amount) 
        {
            var zeroValue = 0;

            if (Math.Max(zeroValue, amount) == zeroValue)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, DepositAmountLessThanZero);
            }
            else {
                m_balance -= amount;
            }
        }

        public void Debit(double amount)
        {
            var maxValue = m_balance;
            var zeroValue = 0;

            if (Math.Max(maxValue, amount) == amount){
                throw new ArgumentOutOfRangeException(nameof(amount), amount, DebitAmountExceedsBalanceMessage);
            }

            if (Math.Max(zeroValue, amount) == zeroValue){
                throw new ArgumentOutOfRangeException(nameof(amount), amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount;
        }

        public void Credit(double amount)
        {
            var zeroValue = 0;
            var maxLimitValue = m_limitAccount;

            if (Math.Max(zeroValue, amount) == zeroValue)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, CreditAmountLessThanZeroMessage);
            }

            if (Math.Max(maxLimitValue, amount) == amount) {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, CreditAmountExceedsLimitsAccount);
            }
        }

        public static void Main()
        {
            BankAccount bank = new("Mr. Bryan Walton", 11.99, 1000);

            bank.Credit(5.77);
            bank.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", bank.Balance);
        }
    }
}