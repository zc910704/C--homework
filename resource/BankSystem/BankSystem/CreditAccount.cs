using System;
namespace BankSystem
{
    public class CreditAccount : Account
    {
        double Credit { get; set; }

        public CreditAccount(string id, string pwd, double money,double credit) : base(id, pwd, money)
        {
            this.Credit = credit;
        }

        public override void WithdrawMoney(double money)
        {
            if ((this.Money + this.Credit) >= money)
            {
                this.Money -= money;
            }
            else
            {
                throw new MyAppException("Money Amount Error");
            }
        }
        public new bool SaveMoney(double money)
        {
            this.Money += money;
            return true;
        }

    }
}