using System;

namespace CSharpPracticeTasks
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("C# Fundamentals - Part 1 Practice Tasks");
            Console.WriteLine("Choose a task number from 1 to 15:");
            int taskNumber = Convert.ToInt32(Console.ReadLine());

            switch (taskNumber)
            {
                case 1:
                {
                    // Task 1 - Personal Info Card
                    string name = "Sara";
                    int age = 21;
                    double height = 1.65;
                    bool isStudent = true;

                    Console.WriteLine("Name: " + name);
                    Console.WriteLine("Age: " + age);
                    Console.WriteLine("Height: " + height);
                    Console.WriteLine("Student: " + isStudent);
                    break;
                }

                case 2:
                {
                    // Task 2 - Rectangle Calculator
                    Console.Write("Enter rectangle length: ");
                    double length = double.Parse(Console.ReadLine());

                    Console.Write("Enter rectangle width: ");
                    double width = double.Parse(Console.ReadLine());

                    double area = length * width;
                    double perimeter = 2 * (length + width);

                    Console.WriteLine("Area: " + area);
                    Console.WriteLine("Perimeter: " + perimeter);
                    break;
                }

                case 3:
                {
                    // Task 3 - Even or Odd Checker
                    Console.Write("Enter a whole number: ");
                    int number = Convert.ToInt32(Console.ReadLine());

                    if (number % 2 == 0)
                    {
                        Console.WriteLine(number + " is even");
                    }
                    else
                    {
                        Console.WriteLine(number + " is odd");
                    }

                    break;
                }

                case 4:
                {
                    // Task 4 - Voting Eligibility
                    Console.Write("Enter your age: ");
                    int voterAge = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Do you have a valid national ID? (yes/no): ");
                    string idAnswer = Console.ReadLine();

                    bool hasValidId = idAnswer == "yes" || idAnswer == "Yes" || idAnswer == "YES";

                    if (voterAge >= 18 && hasValidId)
                    {
                        Console.WriteLine("Eligible to vote");
                    }
                    else
                    {
                        Console.WriteLine("Not eligible to vote");
                    }

                    break;
                }

                case 5:
                {
                    // Task 5 - Grade Letter Lookup
                    Console.Write("Enter grade letter: ");
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

                    break;
                }

                case 6:
                {
                    // Task 6 - Temperature Converter
                    Console.Write("Enter temperature in Celsius: ");
                    double celsius = double.Parse(Console.ReadLine());

                    double fahrenheit = (celsius * 9 / 5) + 32;
                    string weather;

                    if (celsius < 10)
                    {
                        weather = "Cold";
                    }
                    else if (celsius <= 30)
                    {
                        weather = "Mild";
                    }
                    else
                    {
                        weather = "Hot";
                    }

                    Console.WriteLine("Fahrenheit: " + fahrenheit);
                    Console.WriteLine("Weather: " + weather);
                    break;
                }

                case 7:
                {
                    // Task 7 - Movie Ticket Pricing
                    Console.Write("Enter your age: ");
                    int customerAge = Convert.ToInt32(Console.ReadLine());

                    string category;
                    double ticketPrice;

                    if (customerAge < 0)
                    {
                        Console.WriteLine("Invalid age");
                    }
                    else if (customerAge <= 12)
                    {
                        category = "Children";
                        ticketPrice = 2.000;
                        Console.WriteLine("Category: " + category);
                        Console.WriteLine("Price: " + ticketPrice.ToString("F3") + " OMR");
                    }
                    else if (customerAge <= 59)
                    {
                        category = "Adults";
                        ticketPrice = 5.000;
                        Console.WriteLine("Category: " + category);
                        Console.WriteLine("Price: " + ticketPrice.ToString("F3") + " OMR");
                    }
                    else
                    {
                        category = "Seniors";
                        ticketPrice = 3.000;
                        Console.WriteLine("Category: " + category);
                        Console.WriteLine("Price: " + ticketPrice.ToString("F3") + " OMR");
                    }

                    break;
                }

                case 8:
                {
                    // Task 8 - Restaurant Bill with Membership Discount
                    Console.Write("Enter total bill amount: ");
                    double originalBill = double.Parse(Console.ReadLine());

                    Console.Write("Are you a loyalty member? (yes/no): ");
                    string memberAnswer = Console.ReadLine();

                    bool isMember = memberAnswer == "yes" || memberAnswer == "Yes" || memberAnswer == "YES";
                    double discountAmount = 0;

                    if (originalBill > 20 && isMember)
                    {
                        discountAmount = originalBill * 0.15;
                    }

                    double finalBill = originalBill - discountAmount;

                    Console.WriteLine("Original bill: " + originalBill.ToString("F3") + " OMR");
                    Console.WriteLine("Discount amount: " + discountAmount.ToString("F3") + " OMR");
                    Console.WriteLine("Final amount: " + finalBill.ToString("F3") + " OMR");
                    break;
                }

                case 9:
                {
                    // Task 9 - Day Name Finder
                    Console.Write("Enter day number from 1 to 7: ");
                    int dayNumber = Convert.ToInt32(Console.ReadLine());

                    switch (dayNumber)
                    {
                        case 1:
                            Console.WriteLine("Sunday");
                            break;
                        case 2:
                            Console.WriteLine("Monday");
                            break;
                        case 3:
                            Console.WriteLine("Tuesday");
                            break;
                        case 4:
                            Console.WriteLine("Wednesday");
                            break;
                        case 5:
                            Console.WriteLine("Thursday");
                            break;
                        case 6:
                            Console.WriteLine("Friday");
                            break;
                        case 7:
                            Console.WriteLine("Saturday");
                            break;
                        default:
                            Console.WriteLine("Invalid day number");
                            break;
                    }

                    break;
                }

                case 10:
                {
                    // Task 10 - Mini Calculator
                    Console.Write("Enter first number: ");
                    double firstNumber = double.Parse(Console.ReadLine());

                    Console.Write("Enter second number: ");
                    double secondNumber = double.Parse(Console.ReadLine());

                    Console.Write("Enter operator (+, -, *, /, %): ");
                    char operatorSymbol = Convert.ToChar(Console.ReadLine());

                    double result;

                    switch (operatorSymbol)
                    {
                        case '+':
                            result = firstNumber + secondNumber;
                            Console.WriteLine("Result: " + result);
                            break;
                        case '-':
                            result = firstNumber - secondNumber;
                            Console.WriteLine("Result: " + result);
                            break;
                        case '*':
                            result = firstNumber * secondNumber;
                            Console.WriteLine("Result: " + result);
                            break;
                        case '/':
                            if (secondNumber != 0)
                            {
                                result = firstNumber / secondNumber;
                                Console.WriteLine("Result: " + result);
                            }
                            else
                            {
                                Console.WriteLine("Cannot divide by zero");
                            }
                            break;
                        case '%':
                            if (secondNumber != 0)
                            {
                                result = firstNumber % secondNumber;
                                Console.WriteLine("Result: " + result);
                            }
                            else
                            {
                                Console.WriteLine("Cannot divide by zero");
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid operator");
                            break;
                    }

                    break;
                }

                case 11:
                {
                    // Task 11 - Loan Eligibility System
                    Console.Write("Enter your age: ");
                    int loanAge = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter monthly income: ");
                    double monthlyIncome = double.Parse(Console.ReadLine());

                    Console.Write("Do you have an existing loan? (yes/no): ");
                    string loanAnswer = Console.ReadLine();

                    bool hasExistingLoan = loanAnswer == "yes" || loanAnswer == "Yes" || loanAnswer == "YES";

                    if (loanAge >= 21 && loanAge <= 60 && monthlyIncome >= 400 && !hasExistingLoan)
                    {
                        Console.WriteLine("Eligible for loan");
                    }
                    else
                    {
                        Console.WriteLine("Not eligible for loan");

                        if (loanAge < 21 || loanAge > 60)
                        {
                            Console.WriteLine("Reason: Age out of range");
                        }

                        if (monthlyIncome < 400)
                        {
                            Console.WriteLine("Reason: Income too low");
                        }

                        if (hasExistingLoan)
                        {
                            Console.WriteLine("Reason: Has an existing loan");
                        }
                    }

                    break;
                }

                case 12:
                {
                    // Task 12 - Shipping Cost Calculator
                    Console.Write("Enter region code (A, B, or C): ");
                    char regionCode = Convert.ToChar(Console.ReadLine());

                    Console.Write("Enter package weight in kg: ");
                    double weight = double.Parse(Console.ReadLine());

                    double baseCost = 0;
                    double extraCharge = 0;
                    bool validRegion = true;

                    switch (regionCode)
                    {
                        case 'A':
                            baseCost = 1.000;

                            if (weight > 10)
                            {
                                extraCharge = 5.000;
                            }
                            else if (weight > 5)
                            {
                                extraCharge = 2.000;
                            }
                            else
                            {
                                extraCharge = 0;
                            }
                            break;
                        case 'B':
                            baseCost = 3.000;

                            if (weight > 10)
                            {
                                extraCharge = 5.000;
                            }
                            else if (weight > 5)
                            {
                                extraCharge = 2.000;
                            }
                            else
                            {
                                extraCharge = 0;
                            }
                            break;
                        case 'C':
                            baseCost = 7.000;

                            if (weight > 10)
                            {
                                extraCharge = 5.000;
                            }
                            else if (weight > 5)
                            {
                                extraCharge = 2.000;
                            }
                            else
                            {
                                extraCharge = 0;
                            }
                            break;
                        default:
                            validRegion = false;
                            Console.WriteLine("Invalid region");
                            break;
                    }

                    if (validRegion)
                    {
                        double totalShipping = baseCost + extraCharge;

                        Console.WriteLine("Base cost: " + baseCost.ToString("F3") + " OMR");
                        Console.WriteLine("Extra charge: " + extraCharge.ToString("F3") + " OMR");
                        Console.WriteLine("Total shipping cost: " + totalShipping.ToString("F3") + " OMR");
                    }

                    break;
                }

                case 13:
                {
                    // Task 13 - Triangle Type Classifier
                    Console.Write("Enter first side: ");
                    double sideOne = double.Parse(Console.ReadLine());

                    Console.Write("Enter second side: ");
                    double sideTwo = double.Parse(Console.ReadLine());

                    Console.Write("Enter third side: ");
                    double sideThree = double.Parse(Console.ReadLine());

                    bool validTriangle = sideOne + sideTwo > sideThree &&
                                         sideOne + sideThree > sideTwo &&
                                         sideTwo + sideThree > sideOne;

                    if (validTriangle)
                    {
                        if (sideOne == sideTwo && sideTwo == sideThree)
                        {
                            Console.WriteLine("Triangle type: Equilateral");
                        }
                        else
                        {
                            if (sideOne == sideTwo || sideOne == sideThree || sideTwo == sideThree)
                            {
                                Console.WriteLine("Triangle type: Isosceles");
                            }
                            else
                            {
                                Console.WriteLine("Triangle type: Scalene");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("The sides do not form a valid triangle");
                    }

                    break;
                }

                case 14:
                {
                    // Task 14 - Online Store Checkout
                    Console.Write("Enter product code (1, 2, or 3): ");
                    int productCode = Convert.ToInt32(Console.ReadLine());

                    string productName = "";
                    double unitPrice = 0;
                    bool validProduct = true;

                    switch (productCode)
                    {
                        case 1:
                            productName = "Headphones";
                            unitPrice = 8.500;
                            break;
                        case 2:
                            productName = "Keyboard";
                            unitPrice = 12.000;
                            break;
                        case 3:
                            productName = "Mouse";
                            unitPrice = 5.000;
                            break;
                        default:
                            validProduct = false;
                            Console.WriteLine("Invalid product code");
                            break;
                    }

                    if (validProduct)
                    {
                        Console.Write("Enter quantity: ");
                        int quantity = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Do you have a discount coupon? (yes/no): ");
                        string couponAnswer = Console.ReadLine();

                        bool hasCoupon = couponAnswer == "yes" || couponAnswer == "Yes" || couponAnswer == "YES";
                        double subtotal = unitPrice * quantity;
                        double discount = 0;

                        if (hasCoupon && subtotal > 20)
                        {
                            discount = subtotal * 0.10;
                        }

                        double amountAfterDiscount = subtotal - discount;
                        double tax = amountAfterDiscount * 0.05;
                        double finalTotal = amountAfterDiscount + tax;

                        Console.WriteLine("Product: " + productName);
                        Console.WriteLine("Subtotal: " + subtotal.ToString("F3") + " OMR");
                        Console.WriteLine("Discount amount: " + discount.ToString("F3") + " OMR");
                        Console.WriteLine("Tax amount: " + tax.ToString("F3") + " OMR");
                        Console.WriteLine("Final total: " + finalTotal.ToString("F3") + " OMR");
                    }

                    break;
                }

                case 15:
                {
                    // Task 15 - University Admission Decision
                    Console.Write("Enter program type (S for Science, A for Arts): ");
                    char programType = Convert.ToChar(Console.ReadLine());

                    switch (programType)
                    {
                        case 'S':
                        {
                            Console.Write("Enter GPA out of 4.0: ");
                            double gpa = double.Parse(Console.ReadLine());

                            Console.Write("Enter entrance exam score out of 100: ");
                            double examScore = double.Parse(Console.ReadLine());

                            Console.Write("Do you have an extracurricular achievement? (yes/no): ");
                            string achievementAnswer = Console.ReadLine();

                            bool hasAchievement = achievementAnswer == "yes" || achievementAnswer == "Yes" || achievementAnswer == "YES";

                            Console.WriteLine("Program: Science");

                            if (gpa >= 3.0 && examScore >= 75)
                            {
                                Console.WriteLine("Result: Admitted");
                            }
                            else if (hasAchievement)
                            {
                                Console.WriteLine("Result: Conditionally Admitted");
                            }
                            else
                            {
                                Console.WriteLine("Result: Not Admitted");
                            }

                            break;
                        }

                        case 'A':
                        {
                            Console.Write("Enter GPA out of 4.0: ");
                            double gpa = double.Parse(Console.ReadLine());

                            Console.Write("Enter entrance exam score out of 100: ");
                            double examScore = double.Parse(Console.ReadLine());

                            Console.Write("Do you have an extracurricular achievement? (yes/no): ");
                            string achievementAnswer = Console.ReadLine();

                            bool hasAchievement = achievementAnswer == "yes" || achievementAnswer == "Yes" || achievementAnswer == "YES";

                            Console.WriteLine("Program: Arts");

                            if (gpa >= 2.5 && examScore >= 60)
                            {
                                Console.WriteLine("Result: Admitted");
                            }
                            else if (hasAchievement)
                            {
                                Console.WriteLine("Result: Conditionally Admitted");
                            }
                            else
                            {
                                Console.WriteLine("Result: Not Admitted");
                            }

                            break;
                        }

                        default:
                            Console.WriteLine("Invalid program type");
                            break;
                    }

                    break;
                }

                default:
                    Console.WriteLine("Invalid task number");
                    break;
            }
        }
    }
}