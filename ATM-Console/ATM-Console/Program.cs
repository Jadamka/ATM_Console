using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// ATM-Console
///     ---Make a class with Login information , in console user should be able to create his own card with card number, pin etc.
///     Checking whether an input – such as an ATM card (a debit/credit card number) – is recorded correctly
///     Verifying the user by asking for a PIN
///     In case of negative verification, logging out the user
///     Incase of positive verification, showing multiple options, including cash availability, the previous five transactions, and cash withdrawal
///     /// </summary>
///     
/// Fixes: 
/// - try and catch on inputs
/// - add to account a login so user can check his balance
namespace ATM_Console
{
    class Program
    {
        static List<User> users = new List<User>();
        static public int money = 0;

        static void Main(string[] args)
        {
            User bot;

            int input;

            do
            {
                Console.Clear();
                Menu();
                input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1: // Create account
                        Console.Clear();
                        bot = Account();
                        users.Add(bot);
                        break;
                    case 2: // Deposit
                        Console.Clear();
                        Deposit(users);
                        break;
                    case 3: // Withdraw
                        break;
                    case 4: // Check users (only for admin)
                        Console.Clear();
                        Login();
                        break;
                    case 5: // Exit
                        break;
                    default:
                        Console.WriteLine("Wrong input!");
                        break;
                }
            } while (input != 5);

            Console.ReadKey();
        }
        
        static void Menu()
        {
            Console.WriteLine("1. Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Check users (admin)");
            Console.WriteLine("5. Exit");
        }

        static User Account()
        {
            // Card number
            Console.Write("Type card number: ");
            long CardNumber;
            do
            {
                CardNumber = long.Parse(Console.ReadLine());
                if (CardNumber.ToString().Length < 16 || CardNumber.ToString().Length > 16)
                {
                    Console.WriteLine("Must be 16 digits");
                }
                else
                {
                    Console.WriteLine("Correct");
                    Console.Clear();
                }
            } while (CardNumber.ToString().Length < 16 || CardNumber.ToString().Length > 16);

            // Pin
            Console.WriteLine("Choose pin: ");
            int Pin;
            do
            {
                Pin = int.Parse(Console.ReadLine());
                if(Pin.ToString().Length < 4 || Pin.ToString().Length > 4)
                {
                    Console.WriteLine("Must be 4 digits");
                }
                else
                {
                    Console.WriteLine("Correct");
                    Console.Clear();
                }
            } while (Pin.ToString().Length < 4);

            // Name
            Console.Write("Type name: ");
            string name = Console.ReadLine();

            return new User((int)CardNumber, Pin, name, 0);
        }

        static void Login()
        {
            string checkU = "admin";
            string checkP = "admin";

            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("\nPassword: ");
            string password = Console.ReadLine();

            if(username == checkU && password == checkP)
            {
                Console.Clear();
                Check(users);
            }
            else
            {
                Console.WriteLine("Wrong");
                Console.ReadKey();
            }

        }

        static void Check(List<User> users)
        {
            foreach(var a in users)
            {
                Console.WriteLine(a.Name);
            }

            Console.ReadKey();
        }

        static void Deposit(List<User> users)
        {
            bool cardExists = false, pinExists = false;
            Console.Write("Enter card number: ");
            long CN = long.Parse(Console.ReadLine());
            foreach (var a in users)
            {
                if (a.CardNumber == (int)CN)
                {
                    cardExists = true;
                    Console.Clear();
                    Console.Write("Now enter pin: ");
                    int pin = int.Parse(Console.ReadLine());
                    foreach(var b in users)
                    {
                        if(b.Pin == pin)
                        {
                            pinExists = true;
                            Console.Clear();
                            int deposit;
                            Console.WriteLine($"Money in bank: {b.Money}");
                            Console.Write("How much do you wish to deposit(to quit type 0): ");
                            deposit = int.Parse(Console.ReadLine());
                            if (deposit > 0)
                            {
                                b.Money += deposit;
                            }
                            Console.WriteLine("Everything went well!");
                            Console.Clear();
                        }
                    }
                }
            }

            if (!cardExists)
            {
                Console.WriteLine("Wrong card number!");
            }
            if(!pinExists)
            {
                Console.WriteLine("Wrong pin!");
            }

            Console.ReadKey();
        }
    }
}
