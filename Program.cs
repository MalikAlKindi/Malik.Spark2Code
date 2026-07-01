namespace CsharpSession2Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Practice for loops, while loops, do while loops, and try catch.

            Console.WriteLine("C# Session 2 Practice");
            Console.WriteLine("---------------------");

            // For loop: countable loop
            Console.WriteLine("For loop practice:");

            int counter;

            for (counter = 1; counter <= 5; counter++)
            {
                Console.WriteLine("Practice message number: " + counter);
            }

            Console.WriteLine();

            for (counter = 10; counter >= 5; counter--)
            {
                Console.WriteLine("Counting down: " + counter);
            }

            Console.WriteLine();

            // While loop: repeats while the condition is true
            Console.WriteLine("While loop practice:");

            int number = 1;

            while (number <= 3)
            {
                Console.WriteLine("While loop round: " + number);
                number++;
            }

            Console.WriteLine();

            // Do while loop: runs at least one time
            bool exitDecision = false;
            string userInput;
            int userChoice = 0;

            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1 - Print welcome message");
                Console.WriteLine("2 - Print numbers from 1 to 3");
                Console.WriteLine("3 - Exit");
                Console.Write("Enter your choice: ");

                try
                {
                    userChoice = int.Parse(Console.ReadLine());

                    if (userChoice == 1)
                    {
                        Console.WriteLine("Welcome to my loop practice.");
                    }
                    else if (userChoice == 2)
                    {
                        int menuCounter = 1;

                        while (menuCounter <= 3)
                        {
                            Console.WriteLine("Number: " + menuCounter);
                            menuCounter++;
                        }
                    }
                    else if (userChoice == 3)
                    {
                        exitDecision = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Choose 1, 2, or 3.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                if (exitDecision == false)
                {
                    Console.Write("Do you want to exit? (y/n): ");
                    userInput = Console.ReadLine();

                    if (userInput == "y")
                    {
                        exitDecision = true;
                    }
                }

                Console.WriteLine();

            } while (exitDecision == false);

            Console.WriteLine("Program ended.");
        }
    }
}
