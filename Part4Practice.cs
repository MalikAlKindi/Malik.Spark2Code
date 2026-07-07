using System;

namespace Spark2CodePart4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C# Fundamentals - Part 4 Practice");
            Console.WriteLine("Choose a task from 1 to 12:");
            int taskNumber = Convert.ToInt32(Console.ReadLine());

            switch (taskNumber)
            {
                case 1:
                {
                    Console.Write("Enter your name: ");
                    string name = Console.ReadLine();
                    PrintWelcome(name);
                    break;
                }

                case 2:
                {
                    Console.Write("Enter a number: ");
                    int number = Convert.ToInt32(Console.ReadLine());
                    int result = Square(number);
                    Console.WriteLine("Square: " + result);
                    break;
                }

                case 3:
                {
                    Console.Write("Enter Celsius temperature: ");
                    double celsius = Convert.ToDouble(Console.ReadLine());
                    double fahrenheit = CelsiusToFahrenheit(celsius);
                    Console.WriteLine("Fahrenheit: " + fahrenheit);
                    break;
                }

                case 4:
                {
                    DisplayMenu();
                    break;
                }

                case 5:
                {
                    Console.Write("Enter a number: ");
                    int number = Convert.ToInt32(Console.ReadLine());

                    if (IsEven(number))
                    {
                        Console.WriteLine("Even");
                    }
                    else
                    {
                        Console.WriteLine("Odd");
                    }
                    break;
                }

                case 6:
                {
                    Console.Write("Enter rectangle length: ");
                    double length = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter rectangle width: ");
                    double width = Convert.ToDouble(Console.ReadLine());

                    double area = CalculateArea(length, width);
                    double perimeter = CalculatePerimeter(length, width);

                    Console.WriteLine("Area: " + area);
                    Console.WriteLine("Perimeter: " + perimeter);
                    break;
                }

                case 7:
                {
                    Console.Write("Enter score: ");
                    int score = Convert.ToInt32(Console.ReadLine());
                    string grade = GetGradeLetter(score);
                    Console.WriteLine("Grade: " + grade);
                    break;
                }

                case 8:
                {
                    Console.Write("Enter starting number: ");
                    int startNumber = Convert.ToInt32(Console.ReadLine());
                    Countdown(startNumber);
                    break;
                }

                case 9:
                {
                    Console.WriteLine("Multiply two int numbers: " + Multiply(3, 4));
                    Console.WriteLine("Multiply two double numbers: " + Multiply(2.5, 4.0));
                    Console.WriteLine("Multiply three int numbers: " + Multiply(2, 3, 4));
                    break;
                }

                case 10:
                {
                    Console.WriteLine("Choose a shape:");
                    Console.WriteLine("1 - Square");
                    Console.WriteLine("2 - Rectangle");
                    Console.Write("Enter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        Console.Write("Enter side length: ");
                        double side = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Area: " + CalculateArea(side));
                    }
                    else if (choice == 2)
                    {
                        Console.Write("Enter length: ");
                        double length = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter width: ");
                        double width = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Area: " + CalculateArea(length, width));
                    }
                    else
                    {
                        Console.WriteLine("Invalid shape choice");
                    }
                    break;
                }

                case 11:
                {
                    bool exitProgram = false;

                    while (exitProgram == false)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Calculator Menu");
                        Console.WriteLine("1 - Add");
                        Console.WriteLine("2 - Subtract");
                        Console.WriteLine("3 - Multiply");
                        Console.WriteLine("4 - Divide");
                        Console.WriteLine("5 - Exit");
                        Console.Write("Choose an operation: ");
                        int choice = Convert.ToInt32(Console.ReadLine());

                        if (choice == 5)
                        {
                            exitProgram = true;
                        }
                        else
                        {
                            Console.Write("Enter first number: ");
                            double firstNumber = Convert.ToDouble(Console.ReadLine());

                            Console.Write("Enter second number: ");
                            double secondNumber = Convert.ToDouble(Console.ReadLine());

                            double result = 0;
                            string operationName = "";

                            switch (choice)
                            {
                                case 1:
                                    result = Add(firstNumber, secondNumber);
                                    operationName = "Add";
                                    break;
                                case 2:
                                    result = Subtract(firstNumber, secondNumber);
                                    operationName = "Subtract";
                                    break;
                                case 3:
                                    result = MultiplyNumbers(firstNumber, secondNumber);
                                    operationName = "Multiply";
                                    break;
                                case 4:
                                    result = DivideNumbers(firstNumber, secondNumber);
                                    operationName = "Divide";
                                    break;
                                default:
                                    Console.WriteLine("Invalid operation");
                                    break;
                            }

                            if (choice >= 1 && choice <= 4)
                            {
                                DisplayResult(operationName, result);
                            }
                        }
                    }
                    break;
                }

                case 12:
                {
                    Console.Write("Enter student name: ");
                    string studentName = Console.ReadLine();

                    Console.Write("Enter first score: ");
                    double score1 = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter second score: ");
                    double score2 = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter third score: ");
                    double score3 = Convert.ToDouble(Console.ReadLine());

                    double average = CalculateAverage(score1, score2, score3);
                    string gradeLetter = GetGradeLetter(average);

                    PrintReportCard(studentName, average, gradeLetter);
                    break;
                }

                default:
                    Console.WriteLine("Invalid task number");
                    break;
            }
        }

        static void PrintWelcome(string name)
        {
            Console.WriteLine("Welcome, " + name + "!");
        }

        static int Square(int number)
        {
            return number * number;
        }

        static double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }

        static void DisplayMenu()
        {
            Console.WriteLine("1) Start");
            Console.WriteLine("2) Help");
            Console.WriteLine("3) Exit");
        }

        static bool IsEven(int number)
        {
            if (number % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static double CalculateArea(double length, double width)
        {
            return length * width;
        }

        static double CalculatePerimeter(double length, double width)
        {
            return 2 * (length + width);
        }

        static string GetGradeLetter(int score)
        {
            if (score >= 90)
            {
                return "A";
            }
            else if (score >= 80)
            {
                return "B";
            }
            else if (score >= 70)
            {
                return "C";
            }
            else if (score >= 60)
            {
                return "D";
            }
            else
            {
                return "F";
            }
        }

        static string GetGradeLetter(double average)
        {
            if (average >= 90)
            {
                return "A";
            }
            else if (average >= 80)
            {
                return "B";
            }
            else if (average >= 70)
            {
                return "C";
            }
            else if (average >= 60)
            {
                return "D";
            }
            else
            {
                return "F";
            }
        }

        static void Countdown(int startingNumber)
        {
            for (int i = startingNumber; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
        }

        static int Multiply(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }

        static double Multiply(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }

        static int Multiply(int firstNumber, int secondNumber, int thirdNumber)
        {
            return firstNumber * secondNumber * thirdNumber;
        }

        static double CalculateArea(double side)
        {
            return side * side;
        }

        static double Add(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }

        static double Subtract(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }

        static double MultiplyNumbers(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }

        static double DivideNumbers(double firstNumber, double secondNumber)
        {
            try
            {
                return firstNumber / secondNumber;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero");
                return 0;
            }
        }

        static void DisplayResult(string operationName, double result)
        {
            Console.WriteLine(operationName + " result: " + result);
        }

        static double CalculateAverage(double score1, double score2, double score3)
        {
            return (score1 + score2 + score3) / 3;
        }

        static void PrintReportCard(string studentName, double average, string gradeLetter)
        {
            Console.WriteLine("Student Report Card");
            Console.WriteLine("Name: " + studentName);
            Console.WriteLine("Average: " + average);
            Console.WriteLine("Grade: " + gradeLetter);
        }
    }
}
