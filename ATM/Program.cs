using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            StartMenu();
            MainMenu();
            CardManipulations();
            
            Console.ReadLine();
        }
        public static void CardManipulations()
        {
            ATMachine atm = new ATMachine("ATMPRO", "12345");
            int userChoice = int.Parse(Console.ReadLine());
            Money money = new Money();
            bool correctOption = false;
            while(!correctOption)
            {
                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("Your card balance is " + atm.GetCardBalance() + "$.");
                        correctOption = true;
                        break;
                    case 2:
                        Console.WriteLine("Enter a amount of money to withdraw.");
                        int amount = int.Parse(Console.ReadLine());
                        atm.WithdrawMoney(amount);
                        correctOption = true;
                        break;
                    case 3:
                        Console.WriteLine("Enter a amount of money to load onto your card.");
                        int am = int.Parse(Console.ReadLine());
                        money.Amount = am;
                        atm.LoadMoney(money);
                        correctOption = true;
                        break;
                    case 4:
                        atm.ReturnCard();
                        break;
                    default:
                        Console.WriteLine("Option doesn't exist! Choose option from 1 to 4.");
                        userChoice = int.Parse(Console.ReadLine());
                        break;
                }
            }
        }
        public static void StartMenu()
        {
            ATMachine atm = new ATMachine("ATMPRO", "12345");
            Console.WriteLine("1. Insert the card");
            Console.WriteLine("2. Exit");

            Console.WriteLine(new string('-', 30));
            bool correctOption = false;

            Console.WriteLine("Please, choose the option!");
            int userInput = int.Parse(Console.ReadLine());
            while(!correctOption)
            {
                switch (userInput)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Enter a card number of 5 digits: ");
                        string cardNumber = Console.ReadLine();
                        atm.InsertCard(cardNumber);
                        correctOption = true;
                        break;
                    case 2:
                        Console.WriteLine($"Thank you, for using {atm.Manufacter}, Good Bye!");
                        Thread.Sleep(2000);
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Wrong option, try one more time, by choosing option 1 or 2");
                        userInput = int.Parse(Console.ReadLine());
                        break;
                }
            }    
        }
        public static void MainMenu()
        {
            Console.WriteLine("1. Check balance");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Load money");
            Console.WriteLine("4. Exit");

            Console.WriteLine(new string('-', 30));

            Console.WriteLine("Please, choose the option!");
        }
    }
}
