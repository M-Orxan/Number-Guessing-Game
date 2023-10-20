using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wellcome!");

            bool continuePlaying = true;
            while (continuePlaying)
            {
                Console.WriteLine("Enter the number between 1 and 100:");
                string userInput = Console.ReadLine();

                int originalNumber = ConvertUserInputToInteger(userInput);


                Random random = new Random();
                int randomNumber = random.Next(1, 101);




                FindNumber(originalNumber, randomNumber, userInput);
                Console.WriteLine();

                Console.WriteLine("Do you want to play again? Yes or no:");
                string choice = Console.ReadLine();
                bool isValid = true;
                while (isValid)
                {
                    if (choice.ToLower() == "yes")
                    {
                        isValid = false;
                        Console.Clear();

                    }
                    else if (choice.ToLower() == "no")
                    {
                        continuePlaying = false;
                        isValid = false;
                        Console.WriteLine("Thanks for playing.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice! Please try again:");
                        choice = Console.ReadLine();
                    }
                }


            }









        }







        public static int ConvertUserInputToInteger(string userInput)
        {
            int number;

            bool isValid = int.TryParse(userInput, out number);

            while (!isValid)
            {
                Console.WriteLine("Wrong input!. Please try again:");
                userInput = Console.ReadLine();
                isValid = int.TryParse(userInput, out number);
            }

            return number;
        }

        public static void FindNumber(int originalNumber, int randomNumber, string userInput)
        {
            int count = 1;



            while (count <= 6)
            {
                if (count == 6 && originalNumber != randomNumber)
                {
                    Console.WriteLine($"You lost. All your chances over... The right number is {randomNumber}");
                    break;

                }
                if (originalNumber < randomNumber)
                {
                    Console.WriteLine();
                    Console.WriteLine($"You have {6 - count} chance left. Please enter higher number:");
                    userInput = Console.ReadLine();
                    originalNumber = ConvertUserInputToInteger(userInput);
                    count++;
                }
                else if (originalNumber > randomNumber)
                {
                    Console.WriteLine();
                    Console.WriteLine($"You have {6 - count} chance left. Please enter lower number:");
                    userInput = Console.ReadLine();
                    originalNumber = ConvertUserInputToInteger(userInput);
                    count++;
                }
                else
                {
                    Console.WriteLine($"You won!. You found the right number at {count}th try");
                    break;
                }


            }
        }

    }
}
