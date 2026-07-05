using System;

namespace SparkToCodeSession3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TASK 1 - Absolute Difference");
            Console.Write("Enter first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            double diff = num1 - num2;
            double absDiff = Math.Abs(diff);
            Console.WriteLine("The absolute difference is: " + absDiff);
            Console.WriteLine();
            Console.WriteLine("TASK 2 - Power & Root Explorer");
            Console.Write("Enter a number: ");
            double n = Convert.ToDouble(Console.ReadLine());

            double square = Math.Pow(n, 2);
            double sqrt = Math.Sqrt(n);
            Console.WriteLine("Square of the number = " + square);
            Console.WriteLine("Square root of the number = " + sqrt);
            Console.WriteLine();

            Console.WriteLine("TASK 3 - Name Formatter");
            Console.Write("Enter your full name: ");
            string fullName = Console.ReadLine();

            string upper = fullName.ToUpper();
            string lower = fullName.ToLower();
            int nameLength = fullName.Length;

            Console.WriteLine("Uppercase: " + upper);
            Console.WriteLine("Lowercase: " + lower);
            Console.WriteLine("Number of characters: " + nameLength);
            Console.WriteLine();

            Console.WriteLine("TASK 4 - Subscription End Date");
            Console.Write("Enter number of trial days: ");
            int trialDays = Convert.ToInt32(Console.ReadLine());

            DateTime startDate = DateTime.Today;
            DateTime endDate = startDate.AddDays(trialDays);
            Console.WriteLine("Your trial ends on: " + endDate.ToString("yyyy-MM-dd"));
            Console.WriteLine();

            Console.WriteLine("TASK 5 - Grade Rounding System");
            Console.Write("Enter your raw exam score: ");
            double rawScore = Convert.ToDouble(Console.ReadLine());

            double roundedScore = Math.Round(rawScore, 0);
            Console.WriteLine("Rounded score: " + roundedScore);

            if (roundedScore >= 60)
            {
                Console.WriteLine("Result: Pass");
            }
            else
            {
                Console.WriteLine("Result: Fail");
            }
            Console.WriteLine();

            Console.WriteLine("TASK 6 - Password Strength Checker");
            Console.Write("Enter a password: ");
            string pass = Console.ReadLine();

            bool longEnough = pass.Length >= 8;
            bool hasForbiddenWord = pass.ToLower().Contains("password");

            if (longEnough && !hasForbiddenWord)
            {
                Console.WriteLine("Password Strength: Strong");
            }
            else
            {
                Console.Write("Password Strength: Weak - reason: ");
                if (!longEnough)
                {
                    Console.Write("too short ");
                }
                if (hasForbiddenWord)
                {
                    Console.Write("contains the word 'password'");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("TASK 7 - Clean Name Comparator");
            Console.Write("Enter the name (1st time): ");
            string name1 = Console.ReadLine();
            Console.Write("Enter the name (2nd time): ");
            string name2 = Console.ReadLine();

            string cleanName1 = name1.Trim().ToUpper();
            string cleanName2 = name2.Trim().ToUpper();

            if (cleanName1 == cleanName2)
            {
                Console.WriteLine("Match");
            }
            else
            {
                Console.WriteLine("No Match");
            }
            Console.WriteLine();

            Console.WriteLine("TASK 8 - Membership Expiry Checker");
            Console.Write("Enter membership start date (yyyy-MM-dd): ");
            string startText = Console.ReadLine();
            Console.Write("Enter number of valid membership days: ");
            int validDays = Convert.ToInt32(Console.ReadLine());

            try
            {
                DateTime memberStart = DateTime.Parse(startText);
                DateTime expiry = memberStart.AddDays(validDays);

                if (expiry >= DateTime.Today)
                {
                    Console.WriteLine("Membership status: Active (expires on " + expiry.ToString("yyyy-MM-dd") + ")");
                }
                else
                {
                    Console.WriteLine("Membership status: Expired (expired on " + expiry.ToString("yyyy-MM-dd") + ")");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("That date was not valid, could not check membership.");
            }
            Console.WriteLine();

            Console.WriteLine("TASK 9 - Round Up / Round Down Explorer");
            Console.Write("Enter a decimal number: ");
            double numToRound = Convert.ToDouble(Console.ReadLine());

 
            double nearest = Math.Round(numToRound);
            double roundUp = Math.Ceiling(numToRound);
            double roundDown = Math.Floor(numToRound);

            Console.WriteLine("Nearest whole number: " + nearest);
            Console.WriteLine("Always rounded up (Ceiling): " + roundUp);
            Console.WriteLine("Always rounded down (Floor): " + roundDown);
            Console.WriteLine();

            Console.WriteLine("TASK 10 - Word Position Finder");
            Console.Write("Enter a sentence: ");
            string sentence = Console.ReadLine();
            Console.Write("Enter the word to search for: ");
            string wordToFind = Console.ReadLine();

            int lastPos = sentence.LastIndexOf(wordToFind);

            if (firstPos == -1)
            {
                Console.WriteLine("The word was not found in the sentence.");
            }
            else
            {
                Console.WriteLine("First occurrence at index: " + firstPos);
                Console.WriteLine("Last occurrence at index: " + lastPos);
            }
            Console.WriteLine();

            Console.WriteLine("TASK 11 - One-Time Password (OTP) Generator");

            Random rnd = new Random();
            int otpCode = rnd.Next(1000, 10000);
            Console.WriteLine("(Simulated SMS) Your OTP code is: " + otpCode);

            int attempts = 0;
            bool verified = false;

            while (attempts < 3 && verified == false)
            {
                Console.Write("Enter the code you received: ");
                string userInput = Console.ReadLine();
                try
                {
                    int enteredCode = Convert.ToInt32(userInput);
                    if (enteredCode == otpCode)
                    {
                        verified = true;
                        Console.WriteLine("Verified");
                    }
                    else
                    {
                        Console.WriteLine("Wrong code, try again.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("That is not a number, try again.");
                }
                attempts = attempts + 1;
            }

            if (verified == false)
            {
                Console.WriteLine("Verification Failed");
            }
            Console.WriteLine();

            Console.WriteLine("TASK 12 - Birthday Insights");
            Console.Write("Enter your date of birth (yyyy-MM-dd): ");
            string dobText = Console.ReadLine();

            try
            {
                DateTime dob = DateTime.Parse(dobText);
                DateTime today = DateTime.Today;

                int age = today.Year - dob.Year;

                if (today.Month < dob.Month || (today.Month == dob.Month && today.Day < dob.Day))
                {
                    age = age - 1;
                }

                DayOfWeek birthDay = dob.DayOfWeek; 

                Console.WriteLine("Your age is: " + age);
                Console.WriteLine("You were born on a: " + birthDay);
            }
            catch (FormatException)
            {
                Console.WriteLine("That date was not valid.");
            }

            Console.WriteLine();
            Console.WriteLine("Done with all 12 tasks.");
            Console.ReadLine();
        }
    }
}
