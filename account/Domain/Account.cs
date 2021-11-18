namespace account.Domain
{
    internal class BankAccount
    {
        private static int _number = 0;
        private static object _locker = new object();

        private int id;
        private decimal balance;
        private AccountType type;

        private BankAccount() {
            _initId();
            balance = 0;
            type = AccountType.Payment;
        }

        private void _initId() => id = _number++;

        public int Id => id;
        public decimal Balance => balance;
        public AccountType Type => type;
        
        public static BankAccount Create() => new BankAccount();

        public BankAccount SetBalance(decimal sum) {
            balance = sum;
            return this;
        }

        public BankAccount SetType(AccountType type) {
            this.type = type;
            return this;
        }

        public void TopUp(decimal sum) {
            lock (_locker)
            {
                if (sum > 0)
                {
                    balance += sum;
                    System.Console.WriteLine($"top up by {sum}$ was successed");
                }
                else
                    System.Console.WriteLine($"specified amount is less than zero");
            }
        }

        public void WithDraw(decimal sum) {
            lock (_locker)
            {
                if ((sum > 0 && (balance - sum) > 0)
                {
                    balance -= sum;
                    System.Console.WriteLine($"withdraw by {sum}$ was successed");
                }
                else
                    System.Console.WriteLine($"balance less than sum");
            }
        }

        public string Show() => $"Bank account ->  number: {id}    balance:{balance} $   type: {type}";
    }
}
