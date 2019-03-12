using System;
using System.Collections;
namespace BankSystem
{
    public class Bank
    {

        ArrayList accounts = new ArrayList();

        public Account OpenAccount(string id, string pwd, double money)
        {
            Account account = new Account(id, pwd, money);
            accounts.Add(account);

            return account;
        }
        public Account OpenAccount(string id, string pwd, double money,double credit)
        {
            CreditAccount account = new CreditAccount(id, pwd, money, credit);
            accounts.Add(account);
            return account;
        }

        public bool CloseAccount(Account account)
        {
            int idx = accounts.IndexOf(account);
            if (idx < 0) return false;
            accounts.Remove(account);
            return true;
        }

        public Account FindAccount(string id, string pwd)
        {
            foreach (Account account in accounts)
            {
                if (account.IsMatch(id, pwd))
                {
                    return account;
                }

            }
            return null;
        }

    }
}
