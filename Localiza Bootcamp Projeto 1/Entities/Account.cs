using System;
using System.Collections.Generic;
using System.Text;
using Localiza_Bootcamp_Projeto_1.Entities.Enums;

namespace Localiza_Bootcamp_Projeto_1.Entities
{
    class Account
    {
        private AccountType AccountType { get; set; }
        private double Balance { get; set; }
        private double Credit { get; set; }
        public string Name { get; private set; }

        public Account ()
        {
        }

        public Account(AccountType accountType, double balance, double credit, string name)
        {
            AccountType = accountType;
            Balance = balance;
            Credit = credit;
            Name = name;
        }

        public void Withdraw(double amount) 
        { 
            if(!CheckBalance(amount))
            {
                Console.WriteLine("Insufficient funds!");
            }
            else
            {
                Balance -= amount;
                ShowBalance();
                Console.WriteLine();
            }
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            ShowBalance();
            Console.WriteLine();
        }

        public void ShowBalance()
        {
            Console.WriteLine("Balance of {0} is {1}", Name, Balance);
        }

        public void Transfer(double amount, Account account)
        {
            if (!CheckBalance(amount))
            {
                Console.WriteLine("Insufficient funds!");
            }
            else
            {
                Balance -= amount;
                account.Deposit(amount);
                ShowBalance();
                Console.WriteLine();
            }
        }

        private bool CheckBalance(double amount)
        {
            if (Balance - amount < (Credit * -1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Account type: ");
            sb.Append(AccountType);
            sb.Append(" | Name: ");
            sb.Append(Name);
            sb.Append(" | Balance: $");
            sb.Append(Balance.ToString("F2"));
            sb.Append(" | Credit: $");
            sb.Append(Credit.ToString("F2"));
            return sb.ToString();
        }
    }
}
