using System;

namespace DailyPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Daily C# Practice");
            Console.WriteLine("------------------");
            Console.WriteLine("This is a small practice file I made today.");
            Console.WriteLine();

            Console.WriteLine("1) Simple info card");
            string name = "Malik";
            int age = 20;
            string hobby = "coding";
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Hobby: " + hobby);

            Console.WriteLine();
            Console.WriteLine("2) Mini calculator");
            Console.Write("Enter first number: ");
            double firstNumber = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter second number: ");
            double secondNumber = Convert.ToDouble(Console.ReadLine());

            double sum = firstNumber + secondNumber;
            double difference = firstNumber - secondNumber;
            double product = firstNumber * secondNumber;

            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Difference: " + difference);
            Console.WriteLine("Product: " + product);

            Console.WriteLine();
            Console.WriteLine("3) Age check");
            Console.Write("Enter your age: ");
            int userAge = Convert.ToInt32(Console.ReadLine());

            if (userAge >= 18)
            {
                Console.WriteLine("You are an adult.");
            }
            else
            {
                Console.WriteLine("You are under 18.");
            }

            Console.WriteLine();
            Console.WriteLine("4) Count practice");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Count: " + i);
            }

            Console.WriteLine();
            Console.WriteLine("5) Grade check");
            Console.Write("Enter a grade letter (A, B, C, D, F): ");
            char grade = Convert.ToChar(Console.ReadLine());

            switch (grade)
            {
                case 'A':
                    Console.WriteLine("Excellent");
                    break;
                case 'B':
                    Console.WriteLine("Very Good");
                    break;
                case 'C':
                    Console.WriteLine("Good");
                    break;
                case 'D':
                    Console.WriteLine("Pass");
                    break;
                case 'F':
                    Console.WriteLine("Fail");
                    break;
                default:
                    Console.WriteLine("Invalid grade");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Practice done for today.");
        }
    }
}
