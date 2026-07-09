using System;
using System.Collections.Generic;

namespace BankingSystemApp
{
    internal class Program
    {
        static List<string> customerNames = new List<string>();
        static List<string> accountNumbers = new List<string>();
        static List<double> balances = new List<double>();

        static void Main(string[] args)
        {
            bool exitApp = false;

            while (!exitApp)
            {
                Console.WriteLine("\n===== Welcome to Spark Bank =====");
                Console.WriteLine("1. Add New Account");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Show Balance");
                Console.WriteLine("5. Transfer Amount");
                Console.WriteLine("6. List All Accounts");
                Console.WriteLine("7. Find Richest Customer");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");

                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number from 1 to 8.");
                    continue; // skip the rest of this loop pass, show the menu again
                }

                switch (choice)
                {
                    case 1:
                        AddAccount();
                        break;
                    case 2:
                        DepositMoney();
                        break;
                    case 3:
                        WithdrawMoney();
                        break;
                    case 4:
                        ShowBalance();
                        break;
                    case 5:
                        TransferAmount();
                        break;
                    case 6:
                        ListAllAccounts();
                        break;
                    case 7:
                        FindRichestCustomer();
                        break;
                    case 8:
                        exitApp = true;
                        Console.WriteLine("Thank you for banking with Spark Bank. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please choose between 1 and 8.");
                        break;
                }
            }
        }

        static void AddAccount()
        {
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();

            Console.Write("Enter new account number: ");
            string accNumber = Console.ReadLine();

            if (accountNumbers.Contains(accNumber))
            {
                Console.WriteLine("Error: An account with that account number already exists.");
                return;
            }

            double initialDeposit;
            try
            {
                Console.Write("Enter initial deposit amount: ");
                initialDeposit = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid amount entered. Account not created.");
                return;
            }

            if (initialDeposit < 0)
            {
                Console.WriteLine("Error: Initial deposit cannot be negative. Account not created.");
                return;
            }
            customerNames.Add(name);
            accountNumbers.Add(accNumber);
            balances.Add(initialDeposit);

            Console.WriteLine("Account created successfully!");
            Console.WriteLine("Name: " + name + " | Account Number: " + accNumber + " | Starting Balance: " + initialDeposit.ToString("F2"));
        }

        static void DepositMoney()
        {
            Console.Write("Enter account number: ");
            string accNumber = Console.ReadLine();

            int index = accountNumbers.IndexOf(accNumber);
            if (index == -1)
            {
                Console.WriteLine("Error: Account number not found.");
                return;
            }

            double amount;
            try
            {
                Console.Write("Enter deposit amount: ");
                amount = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid amount entered.");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Error: Deposit amount must be positive.");
                return;
            }

            balances[index] += amount;
            Console.WriteLine("Deposit successful. New balance for account " + accNumber + ": " + balances[index].ToString("F2"));
        }

        static void WithdrawMoney()
        {
            Console.Write("Enter account number: ");
            string accNumber = Console.ReadLine();

            int index = accountNumbers.IndexOf(accNumber);
            if (index == -1)
            {
                Console.WriteLine("Error: Account number not found.");
                return;
            }

            double amount;
            try
            {
                Console.Write("Enter withdrawal amount: ");
                amount = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid amount entered.");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Error: Withdrawal amount must be positive.");
                return;
            }

            if (amount > balances[index])
            {
                Console.WriteLine("Error: Insufficient balance. Current balance is " + balances[index].ToString("F2"));
                return;
            }

            balances[index] -= amount;
            Console.WriteLine("Withdrawal successful. New balance for account " + accNumber + ": " + balances[index].ToString("F2"));
        }

        static void ShowBalance()
        {
            Console.Write("Enter account number: ");
            string accNumber = Console.ReadLine();

            int index = accountNumbers.IndexOf(accNumber);
            if (index == -1)
            {
                Console.WriteLine("Error: Account number not found.");
                return;
            }

            Console.WriteLine("Customer: " + customerNames[index] + " | Account Number: " + accountNumbers[index] + " | Balance: " + balances[index].ToString("F2"));
        }

        static void TransferAmount()
        {
            Console.Write("Enter sender's account number: ");
            string senderAcc = Console.ReadLine();

            Console.Write("Enter receiver's account number: ");
            string receiverAcc = Console.ReadLine();

            int senderIndex = accountNumbers.IndexOf(senderAcc);
            int receiverIndex = accountNumbers.IndexOf(receiverAcc);

            if (senderIndex == -1 || receiverIndex == -1)
            {
                Console.WriteLine("Error: One or both account numbers were not found.");
                return;
            }

            double amount;
            try
            {
                Console.Write("Enter transfer amount: ");
                amount = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid amount entered.");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Error: Transfer amount must be positive.");
                return;
            }

            if (amount > balances[senderIndex])
            {
                Console.WriteLine("Error: Sender has insufficient balance. Current balance is " + balances[senderIndex].ToString("F2"));
                return;
            }

            balances[senderIndex] -= amount;
            balances[receiverIndex] += amount;

            Console.WriteLine("Transfer successful!");
            Console.WriteLine("Sender (" + senderAcc + ") new balance: " + balances[senderIndex].ToString("F2"));
            Console.WriteLine("Receiver (" + receiverAcc + ") new balance: " + balances[receiverIndex].ToString("F2"));
        }

        static void ListAllAccounts()
        {
            if (customerNames.Count == 0)
            {
                Console.WriteLine("There are no accounts in the system yet.");
                return;
            }

            Console.WriteLine("----- All Accounts -----");
            for (int i = 0; i < customerNames.Count; i++)
            {
                Console.WriteLine((i + 1) + ". Name: " + customerNames[i] + " | Account Number: " + accountNumbers[i] + " | Balance: " + balances[i].ToString("F2"));
            }
        }

        static void FindRichestCustomer()
        {
            if (customerNames.Count == 0)
            {
                Console.WriteLine("There are no accounts in the system yet.");
                return;
            }

            int richestIndex = 0;
            for (int i = 1; i < balances.Count; i++)
            {
                if (balances[i] > balances[richestIndex])
                {
                    richestIndex = i;
                }
            }

            Console.WriteLine("Richest Customer -> Name: " + customerNames[richestIndex] + " | Account Number: " + accountNumbers[richestIndex] + " | Balance: " + balances[richestIndex].ToString("F2"));
        }
    }
}
