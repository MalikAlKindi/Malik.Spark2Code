namespace CsharpFunctionsPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // C# Functions Practice
            // I practiced built-in functions and user-defined functions from class.

            PrintTitle("C# Functions Practice");

            Console.WriteLine("Part 1: Built-in functions");
            PracticeMathFunctions();
            PracticeStringFunctions();
            PracticeDateFunctions();
            PracticeArrayFunctions();
            PracticeRandomAndConversion();

            Console.WriteLine();
            Console.WriteLine("Part 2: User-defined functions");

            PrintGreeting("Malik");

            int sum = AddNumbers(7, 5);
            Console.WriteLine("Sum: " + sum);

            double circleArea = CalculateCircleArea(4);
            Console.WriteLine("Circle area: " + Math.Round(circleArea, 2));

            Console.WriteLine("Multiply two int numbers: " + Multiply(3, 4));
            Console.WriteLine("Multiply two double numbers: " + Multiply(2.5, 4.2));
            Console.WriteLine("Multiply three int numbers: " + Multiply(2, 3, 4));

            PrintMessage();
            PrintMessage("This message was sent to an optional parameter.");

            PrintStudentDetails(age: 20, city: "Muscat", name: "Malik");

            int firstNumber = 10;
            ChangeByValue(firstNumber);
            Console.WriteLine("After by value function: " + firstNumber);

            ChangeByReference(ref firstNumber);
            Console.WriteLine("After by reference function: " + firstNumber);

            int createdNumber;
            CreateNumber(out createdNumber);
            Console.WriteLine("Number from out parameter: " + createdNumber);

            var result = CalculateSumAndProduct(6, 3);
            Console.WriteLine("Tuple sum: " + result.sum);
            Console.WriteLine("Tuple product: " + result.product);

            int factorialAnswer = Factorial(5);
            Console.WriteLine("Factorial of 5: " + factorialAnswer);

            Console.WriteLine();
            Console.WriteLine("Practice finished.");
        }

        static void PrintTitle(string title)
        {
            Console.WriteLine(title);
            Console.WriteLine("---------------------");
        }

        static void PracticeMathFunctions()
        {
            int negativeNumber = -15;
            double powerResult = Math.Pow(2, 3);
            double squareRoot = Math.Sqrt(25);
            double roundedNumber = Math.Round(7.856, 2);

            Console.WriteLine();
            Console.WriteLine("Math examples:");
            Console.WriteLine("Absolute value: " + Math.Abs(negativeNumber));
            Console.WriteLine("Power: " + powerResult);
            Console.WriteLine("Square root: " + squareRoot);
            Console.WriteLine("Max number: " + Math.Max(12, 20));
            Console.WriteLine("Min number: " + Math.Min(12, 20));
            Console.WriteLine("Rounded number: " + roundedNumber);
        }

        static void PracticeStringFunctions()
        {
            string sentence = "  I am learning C# functions today  ";
            string cleanSentence = sentence.Trim();

            Console.WriteLine();
            Console.WriteLine("String examples:");
            Console.WriteLine("Original length: " + sentence.Length);
            Console.WriteLine("After Trim: " + cleanSentence);
            Console.WriteLine("Uppercase: " + cleanSentence.ToUpper());
            Console.WriteLine("Lowercase: " + cleanSentence.ToLower());
            Console.WriteLine("Contains C#: " + cleanSentence.Contains("C#"));
            Console.WriteLine("Replace: " + cleanSentence.Replace("today", "this week"));
            Console.WriteLine("Substring: " + cleanSentence.Substring(0, 5));
        }

        static void PracticeDateFunctions()
        {
            DateTime today = DateTime.Today;
            DateTime nextWeek = today.AddDays(7);

            Console.WriteLine();
            Console.WriteLine("Date examples:");
            Console.WriteLine("Today: " + today.ToString("yyyy-MM-dd"));
            Console.WriteLine("Next week: " + nextWeek.ToString("yyyy-MM-dd"));
            Console.WriteLine("Current time: " + DateTime.Now.ToString("HH:mm:ss"));
        }

        static void PracticeArrayFunctions()
        {
            int[] marks = { 75, 90, 62, 88, 70 };

            Console.WriteLine();
            Console.WriteLine("Array examples:");

            Array.Sort(marks);
            Console.WriteLine("Sorted marks:");

            for (int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine(marks[i]);
            }

            Array.Reverse(marks);
            Console.WriteLine("Highest mark after reverse: " + marks[0]);
            Console.WriteLine("Index of 75: " + Array.IndexOf(marks, 75));
        }

        static void PracticeRandomAndConversion()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 11);

            string ageText = "21";
            int age = Convert.ToInt32(ageText);

            string priceText = "4.500";
            double price = Convert.ToDouble(priceText);

            Console.WriteLine();
            Console.WriteLine("Random and conversion examples:");
            Console.WriteLine("Random number from 1 to 10: " + randomNumber);
            Console.WriteLine("Converted age: " + age);
            Console.WriteLine("Converted price: " + price.ToString("F3"));
        }

        static void PrintGreeting(string name)
        {
            Console.WriteLine("Hello " + name + ", welcome to functions practice.");
        }

        static int AddNumbers(int numberOne, int numberTwo)
        {
            return numberOne + numberTwo;
        }

        static double CalculateCircleArea(double radius)
        {
            double area = Math.PI * radius * radius;
            return area;
        }

        static int Multiply(int numberOne, int numberTwo)
        {
            return numberOne * numberTwo;
        }

        static double Multiply(double numberOne, double numberTwo)
        {
            return numberOne * numberTwo;
        }

        static int Multiply(int numberOne, int numberTwo, int numberThree)
        {
            return numberOne * numberTwo * numberThree;
        }

        static void PrintMessage(string message = "Default practice message")
        {
            Console.WriteLine(message);
        }

        static void PrintStudentDetails(string name, int age, string city)
        {
            Console.WriteLine("Student name: " + name);
            Console.WriteLine("Student age: " + age);
            Console.WriteLine("Student city: " + city);
        }

        static void ChangeByValue(int number)
        {
            number = number + 5;
            Console.WriteLine("Inside by value function: " + number);
        }

        static void ChangeByReference(ref int number)
        {
            number = number + 5;
            Console.WriteLine("Inside by reference function: " + number);
        }

        static void CreateNumber(out int number)
        {
            number = 100;
        }

        static (int sum, int product) CalculateSumAndProduct(int numberOne, int numberTwo)
        {
            int sum = numberOne + numberTwo;
            int product = numberOne * numberTwo;

            return (sum, product);
        }

        static int Factorial(int number)
        {
            if (number == 1)
            {
                return 1;
            }
            else
            {
                return number * Factorial(number - 1);
            }
        }
    }
}
