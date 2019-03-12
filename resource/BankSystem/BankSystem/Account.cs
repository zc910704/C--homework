using System;

namespace BankSystem
{
    public class Account
    {
        //属性
        internal double Money { get; set; } //只允许程序集内部读写
        internal string Id { get; set; }
        internal string Pwd { get; set; }
        //string name;

        public Account(string id, string pwd, double money)
        {
            //if( money < 0 ) throw new Exception("....");
            this.Id = id;
            this.Pwd = pwd;
            this.Money = money;
        }

        public void SaveMoney(double money)
        {
            if (money < 0|| money>10000)
            {
                throw new AccountException("Money Amount Error",money);
            }
            else
            {
            this.Money += money;
            }
        }

        public virtual void WithdrawMoney(double money)
        {
            if (this.Money >= money)
            {
                this.Money -= money;
            }
            else
            {
                throw new MyAppException("Money Amount Error");
            }

        }

        public bool IsMatch(string id, string pwd)
        {
             return id == this.Id && pwd == this.Pwd;
        }


    }
    public class AccountException : ApplicationException
    {
        internal double money { get; }
        public AccountException(string message,double money) : base(message)
        {
            this.money = money;
        }
    }
    public class MyAppException : ApplicationException
    {
        public MyAppException(string message)
            : base(message)
        { }
        public MyAppException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}