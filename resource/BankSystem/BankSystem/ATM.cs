using System;
using System.Collections;
namespace BankSystem
{
    public class BigMoneyArgs
    {
        internal string Id {get;set ;}
        internal double Amount { get; set; }
        public BigMoneyArgs(string Id,double Amount)
        {
            this.Id = Id;
            this.Amount = Amount;
        }

    }
    public delegate void BigMoneyHandler(object sender, BigMoneyArgs e);

    public class ATM
    {
        public event BigMoneyHandler BigMoneyFetched;
        Bank bank;
        public ATM(Bank bank)
        {
            this.bank = bank;
        }

        public void Transaction()
        {
            Show("please insert your card");
            string id = GetInput();

            Show("please enter your password");
            string pwd = GetInput();

            Account account = bank.FindAccount(id, pwd);

            if (account == null)
            {
                Show("card invalid or password not corrent");
                return;
            }

            Show("1: display; 2: save; 3: withdraw");
            string op = GetInput();
            if (op == "1")
            {
                Show("balance: " + account.Money);
            }
            else if (op == "2")
            {
                try
                {
                    Show("save money");
                    string smoney = GetInput();
                    double money = double.Parse(smoney);
                    try
                    {
                        account.SaveMoney(money);
                        Console.WriteLine("complete");
                    }
                    catch (AccountException e)
                    {
                        if (e.money > 10000)
                        {
                            throw new MyAppException("Money too much");
                        }
                        else
                        {
                            throw new MyAppException("Money amount must bigger than zero");
                        }
                    }
                }
                catch(MyAppException e)
                {
                    Console.WriteLine(e.Message);
                }
                
                Show("balance: " + account.Money);
            }
            else if (op == "3")
            {
                Show("withdraw money");
                string smoney = GetInput();
                double money = double.Parse(smoney);
                if(BigMoneyFetched != null&&money>=10000)
                {
                    BigMoneyFetched(this,new BigMoneyArgs(id,money));
                } try
                    {
                        account.WithdrawMoney(money);
                    }
                    catch (MyAppException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                 Show("balance: " + account.Money);
            }
        }


        public void Show(string msg)
        {
            Console.WriteLine(msg);
        }
        public string GetInput()
        {
            return Console.ReadLine();// ÊäÈë×Ö·û
        }
    }
}