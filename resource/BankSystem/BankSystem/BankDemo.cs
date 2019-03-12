using BankSystem;
using System;
public class BankDemo {
	public static void Main(string [] args)
	{
		Bank bank = new Bank();
		bank.OpenAccount("1", "1", 20000);
		bank.OpenAccount("2", "2", 50,1000);
		ATM atm = new ATM(bank);
        atm.BigMoneyFetched += (object sender, BigMoneyArgs e) => { Console.WriteLine("Caution:" + e.Id + "got " + e.Amount); };


        for ( int i=0; i<5; i++)
		{
			atm.Transaction();
		}
	}
}
