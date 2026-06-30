#nullable disable

using System;

namespace CSharpFundamentalsPart1
{
    class Program
    {
        static readonly int Year = 2026;

        static void Main()
        {
            Console.WriteLine("C# Fundamentals Part 1 - Practice Evidence");
            Console.WriteLine("------------------------------------------");

            BasicProgramOutput();
            VariablesAndDataTypes();
            ConstantsAndReadonly();
            Operators();
            ConditionalStatement();
            SwitchStatement();
            Loops();
            NestedLoopMultiplicationTable();
            RightAngledTriangle();
            PyramidPattern();
            RuntimeErrorHandling();
            NullValidation();
            CaseInsensitiveStringComparison();
        }

        static void BasicProgramOutput()
        {
            Console.WriteLine("\n1. Basic Program Output");
            Console.WriteLine("Hello, World!");
        }

        static void CommentsExample()
        {
            // This is a single-line comment.

            /*
             This is a multi-line comment.
             It can span multiple lines.
            */

            Console.WriteLine("Comments make code easier to understand.");
        }

        /// <summary>
        /// This method prints a greeting message.
        /// </summary>
        static void XmlDocumentationCommentExample()
        {
            Console.WriteLine("Hello!");
        }

        static void VariablesAndDataTypes()
        {
            Console.WriteLine("\n2. Variables and Data Types");

            int age = 25;
            double pi = 3.14159;
            float price = 99.99f;
            char letter = 'A';
            bool isPassed = true;
            string name = "John";
            object obj = 42;

            Console.WriteLine("Age: " + age);
            Console.WriteLine("Pi: " + pi);
            Console.WriteLine("Price: " + price);
            Console.WriteLine("Letter: " + letter);
            Console.WriteLine("Passed: " + isPassed);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Object value: " + obj);
        }

        static void ConstantsAndReadonly()
        {
            Console.WriteLine("\n3. Constants and Readonly Fields");

            const double Pi = 3.14159;

            Console.WriteLine("Value of Pi: " + Pi);
            Console.WriteLine("Readonly year: " + Year);
        }

        static void InputOutputExample()
        {
            Console.WriteLine("\n4. Input and Output");

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Hello, " + name);
            Console.WriteLine("You are " + age + " years old.");
        }

        static void Operators()
        {
            Console.WriteLine("\n5. Operators");

            int a = 10;
            int b = 5;

            Console.WriteLine("Addition: " + (a + b));
            Console.WriteLine("Subtraction: " + (a - b));
            Console.WriteLine("Multiplication: " + (a * b));
            Console.WriteLine("Division: " + (a / b));
            Console.WriteLine("Modulus: " + (a % b));

            bool result = (10 > 5) && (5 < 3);
            Console.WriteLine("Logical AND result: " + result);
            Console.WriteLine("Logical NOT result: " + !(a > b));
        }

        static void ConditionalStatement()
        {
            Console.WriteLine("\n6. Conditional Statement");

            int num = 10;

            if (num > 0)
            {
                Console.WriteLine("Positive Number");
            }
            else if (num == 0)
            {
                Console.WriteLine("Zero");
            }
            else
            {
                Console.WriteLine("Negative Number");
            }
        }

        static void SwitchStatement()
        {
            Console.WriteLine("\n7. Switch Statement");

            char grade = 'B';

            switch (grade)
            {
                case 'A':
                    Console.WriteLine("Excellent");
                    break;
                case 'B':
                    Console.WriteLine("Good");
                    break;
                default:
                    Console.WriteLine("Invalid Grade");
                    break;
            }
        }

        static void Loops()
        {
            Console.WriteLine("\n8. Loops");

            Console.WriteLine("For loop:");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("While loop:");
            int whileCounter = 1;
            while (whileCounter <= 5)
            {
                Console.WriteLine(whileCounter);
                whileCounter++;
            }

            Console.WriteLine("Do-while loop:");
            int doWhileCounter = 1;
            do
            {
                Console.WriteLine(doWhileCounter);
                doWhileCounter++;
            } while (doWhileCounter <= 5);

            Console.WriteLine("Foreach loop:");
            string[] fruits = { "Apple", "Banana", "Cherry" };

            foreach (string fruit in fruits)
            {
                Console.WriteLine(fruit);
            }
        }

        static void NestedLoopMultiplicationTable()
        {
            Console.WriteLine("\n9. Nested Loop - Multiplication Table");

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    Console.Write((i * j) + "\t");
                }

                Console.WriteLine();
            }
        }

        static void RightAngledTriangle()
        {
            Console.WriteLine("\n10. Right-Angled Triangle Pattern");

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("* ");
                }

                Console.WriteLine();
            }
        }

        static void PyramidPattern()
        {
            Console.WriteLine("\n11. Pyramid Pattern");

            int n = 5;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write(" ");
                }

                for (int k = 1; k <= 2 * i - 1; k++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }

        static void RuntimeErrorHandling()
        {
            Console.WriteLine("\n12. Runtime Error Handling");

            try
            {
                int divisor = 0;
                int result = 10 / divisor;
                Console.WriteLine(result);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            int safeDivisor = 0;

            if (safeDivisor != 0)
            {
                int result = 10 / safeDivisor;
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Cannot divide by zero.");
            }
        }

        static void NullValidation()
        {
            Console.WriteLine("\n13. Null Validation");

            string message = null;

            if (message != null)
            {
                Console.WriteLine(message.Length);
            }
            else
            {
                Console.WriteLine("Message is null.");
            }
        }

        static void CaseInsensitiveStringComparison()
        {
            Console.WriteLine("\n14. Case-Insensitive String Comparison");

            string input = "yes";

            if (input.Equals("Yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Input is yes");
            }
            else
            {
                Console.WriteLine("Input is not yes");
            }
        }
    }
}
