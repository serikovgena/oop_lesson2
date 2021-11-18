using account.Domain;
using System;

namespace account
{
    class Program
    {
        static void Main() {
            TestBankAccount();
        }

        static void TestBankAccount() {
            var account = BankAccount
                               .Create()
                               .SetType(AccountType.Social)
                               .SetBalance(1000m);

            Console.WriteLine(account.Show());

            account.TopUp(200);
            account.TopUp(300);

            Console.WriteLine(account.Show());

            account.TopUp(0);
            account.TopUp(-1);

            account.WithDraw(500);
            account.WithDraw(500);

            Console.WriteLine(account.Show());

            account.WithDraw(500);

            Console.WriteLine(account.Show());
        }   
    }
}
