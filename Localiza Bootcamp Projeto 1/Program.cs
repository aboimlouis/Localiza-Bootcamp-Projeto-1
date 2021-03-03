using System;
using System.Collections.Generic;
using System.Globalization;
using Localiza_Bootcamp_Projeto_1.Entities;
using Localiza_Bootcamp_Projeto_1.Entities.Enums;

namespace Localiza_Bootcamp_Projeto_1
{
    class Program
    {
        static List<Account> Accounts = new List<Account>();
        static void Main(string[] args)
        {
            string option = "";
            while (option != "X")
            {
                option = GetOption();        
                if (option == "1")
                {
                    ListAccountsOption();
                }
                else if (option == "2")
                {
                    AddNewAccountOption();
                }
                else if (option == "3")
                {
                    TransferOption();
                }
                else if (option == "4")
                {
                    WithdrawOption();
                }
                else if (option == "5")
                {
                    DepositOption();
                }
                else if (option == "C")
                {
                    Console.Clear();
                }
                else if (option == "X")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Option does not exist!");
                    Console.WriteLine("Please select one of the following option!");
                    Console.WriteLine();
                }
            }
            
        }

        private static string GetOption()
        {
            Console.WriteLine();
            Console.WriteLine("Bank System");
            Console.WriteLine("1 - List Accounts");
            Console.WriteLine("2 - Add new Account");
            Console.WriteLine("3 - Transfer");
            Console.WriteLine("4 - Withdraw");
            Console.WriteLine("5 - Deposit");
            Console.WriteLine("C - Clear Screen");
            Console.WriteLine("X - Exit System");
            Console.WriteLine();

            string selectedOption = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return selectedOption;
        }

        private static void ListAccountsOption()
        {
            if (Accounts.Count == 0)
            {
                Console.WriteLine("No accounts registered in the system.");
            }
            else
            {
                foreach (Account account in Accounts)
                {
                    Console.WriteLine(account.ToString());
                }
                Console.WriteLine("There are {0} accounts registered in the system.", Accounts.Count);
                Console.WriteLine();
            }

        }

        private static void AddNewAccountOption()
        {
            Console.Write("Account type (Personal or Business): ");
            AccountType accountType = Enum.Parse<AccountType>(Console.ReadLine());
            Console.Write("Account first deposit: ");
            double firstDeposit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Account credit: ");
            double credit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Account Holder name: ");
            string name = (Console.ReadLine());
            Accounts.Add(new Account(accountType, firstDeposit, credit, name));
        }

        private static void TransferOption()
        {
            Console.Write("Origin account holder name: ");
            string nameOrigin = (Console.ReadLine());
            Console.Write("Destination account holder name: ");
            string nameDestination = (Console.ReadLine());
            Console.Write("Transfer amount: ");
            double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // FORMA 1
            /*Account origin = Accounts.Find(
                delegate(Account acc)
                {
                    return acc.Name == nameOrigin;
                }
                );
            Account destination = Accounts.Find(
                delegate (Account acc)
                {
                    return acc.Name == nameDestination;
                }
                );
            origin.Transfer(amount, destination);*/

            // FORMA 2
            /*if (Accounts.Exists(x => x.Name == nameOrigin) && Accounts.Exists(y => y.Name == nameDestination))
                Accounts.Find(x => x.Name == nameOrigin).Transfer(amount, Accounts.Find(y => y.Name == nameDestination));
            else
                Console.WriteLine("No account holder was found using this name!");*/

            // FORMA 3
            /*foreach (Account accountOrigin in Accounts)
            {
                if (accountOrigin.Name == nameOrigin)
                {
                    foreach (Account accountDestination in Accounts)
                    {
                        if (accountDestination.Name == nameDestination)
                        {
                            accountOrigin.Transfer(amount, accountDestination);
                            break;
                        }
                    }
                    break;
                }
            }*/

            // FORMA FINAL
            int idxOrigin = Accounts.FindIndex(x => x.Name == nameOrigin);
            int idxDestination = Accounts.FindIndex(x => x.Name == nameDestination);
            if (idxOrigin >= 0 && idxDestination >= 0)
            {
                Accounts[idxOrigin].Transfer(amount, Accounts[idxDestination]);
            }
            else Console.WriteLine("Account not found!");

            Console.WriteLine();
        }
        private static void WithdrawOption()
        {
            Console.Write("Account holder name: ");
            string name = (Console.ReadLine());
            Console.Write("Withdraw amount: ");
            double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();

            int idxName = Accounts.FindIndex(x => x.Name == name);
            if (idxName >= 0) Accounts[idxName].Withdraw(amount);
            else Console.WriteLine("Account not found!");

        }
        private static void DepositOption()
        {
            Console.Write("Account holder name: ");
            string name = (Console.ReadLine());
            Console.Write("Deposit amount: ");
            double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();
            
            int idxName = Accounts.FindIndex(x => x.Name == name);
            if (idxName >= 0) Accounts[idxName].Deposit(amount);
            else Console.WriteLine("Account not found!");

        }
    }
}
