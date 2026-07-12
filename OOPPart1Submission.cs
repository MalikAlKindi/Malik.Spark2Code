using System;

namespace OOPPart1Submission
{
    internal class Program
    {
        static BankAccount account1 = new BankAccount(1163, "karim", 120);
        static BankAccount account2 = new BankAccount(15203, "Ali", 63);

        static Student student1 = new Student();
        static Student student2 = new Student();

        static Product product1 = new Product("Wireless Mouse", 5.500, 50);
        static Product product2 = new Product("Mechanical Keyboard", 15.750, 20);

        static void Main(string[] args)
        {
            student1.Name = "Ali";
            student1.Address = "Muscat";
            student1.Grade = 65;

            student2.Name = "Ahmed";
            student2.Address = "Muscat";
            student2.Grade = 70;

            bool exitProgram = false;

            while (exitProgram == false)
            {
                Console.WriteLine();
                Console.WriteLine("OOP Part 1 - Bank & Student Management");
                Console.WriteLine("1  - View Account Details");
                Console.WriteLine("2  - Update Student Address");
                Console.WriteLine("3  - Make a Deposit");
                Console.WriteLine("4  - Make a Withdrawal");
                Console.WriteLine("5  - View Product Details");
                Console.WriteLine("6  - Register a Student");
                Console.WriteLine("7  - Compare Two Account Balances");
                Console.WriteLine("8  - Restock Product & Stock Level Check");
                Console.WriteLine("9  - Transfer Between Accounts");
                Console.WriteLine("10 - Update Student Grade (Validated)");
                Console.WriteLine("11 - Student Report Card");
                Console.WriteLine("12 - Account Health Status");
                Console.WriteLine("13 - Bulk Sale With Revenue Calculation");
                Console.WriteLine("14 - Scholarship Eligibility Check");
                Console.WriteLine("15 - Full Balance Top-Up Flow");
                Console.WriteLine("16 - Quick Account Opening");
                Console.WriteLine("17 - Total Students Counter");
                Console.WriteLine("18 - Overdrawn Account Check");
                Console.WriteLine("19 - Set Student Security PIN");
                Console.WriteLine("20 - Exit");
                Console.Write("Choose a case: ");

                int choice = ReadInt();

                switch (choice)
                {
                    case 1:
                        ViewAccountDetails();
                        break;
                    case 2:
                        UpdateStudentAddress();
                        break;
                    case 3:
                        MakeDeposit();
                        break;
                    case 4:
                        MakeWithdrawal();
                        break;
                    case 5:
                        ViewProductDetails();
                        break;
                    case 6:
                        RegisterStudent();
                        break;
                    case 7:
                        CompareAccountBalances();
                        break;
                    case 8:
                        RestockProduct();
                        break;
                    case 9:
                        TransferBetweenAccounts();
                        break;
                    case 10:
                        UpdateStudentGradeValidated();
                        break;
                    case 11:
                        PrintStudentReportCard();
                        break;
                    case 12:
                        PrintAccountHealthStatus();
                        break;
                    case 13:
                        BulkSaleWithRevenue();
                        break;
                    case 14:
                        ScholarshipEligibilityCheck();
                        break;
                    case 15:
                        FullBalanceTopUpFlow();
                        break;
                    case 16:
                        QuickAccountOpening();
                        break;
                    case 17:
                        Console.WriteLine("Total students created: " + Student.GetTotalStudentsCreated());
                        break;
                    case 18:
                        OverdrawnAccountCheck();
                        break;
                    case 19:
                        SetStudentSecurityPin();
                        break;
                    case 20:
                        exitProgram = true;
                        break;
                    default:
                        Console.WriteLine("Invalid case number");
                        break;
                }
            }
        }

        static void ViewAccountDetails()
        {
            BankAccount account = ChooseAccount();
            if (account != null)
            {
                double balance = account.CheckBalance();
                Console.WriteLine("Current balance: " + balance);
            }
        }

        static void UpdateStudentAddress()
        {
            Student student = ChooseStudent();
            if (student != null)
            {
                Console.Write("Enter new address: ");
                student.Address = Console.ReadLine();
                Console.WriteLine("Address updated to: " + student.Address);
            }
        }

        static void MakeDeposit()
        {
            BankAccount account = ChooseAccount();
            if (account != null)
            {
                Console.Write("Enter deposit amount: ");
                double amount = ReadDouble();
                account.Deposit(amount);
                Console.WriteLine("Account holder: " + account.HolderName);
                Console.WriteLine("Updated balance: " + account.Balance);
            }
        }

        static void MakeWithdrawal()
        {
            BankAccount account = ChooseAccount();
            if (account != null)
            {
                Console.Write("Enter withdrawal amount: ");
                double amount = ReadDouble();
                account.Withdraw(amount);
                Console.WriteLine("Updated balance: " + account.Balance);
            }
        }

        static void ViewProductDetails()
        {
            Product product = ChooseProduct();
            if (product != null)
            {
                double inventoryValue = product.GetInventoryValue();
                Console.WriteLine("Inventory value: " + inventoryValue);
            }
        }

        static void RegisterStudent()
        {
            Student student = ChooseStudent();
            if (student != null)
            {
                Console.Write("Enter email: ");
                string email = Console.ReadLine();
                student.Register(email);
                Console.WriteLine("Student registered successfully.");
            }
        }

        static void CompareAccountBalances()
        {
            if (account1.Balance > account2.Balance)
            {
                Console.WriteLine(account1.HolderName + " currently holds more money.");
            }
            else if (account2.Balance > account1.Balance)
            {
                Console.WriteLine(account2.HolderName + " currently holds more money.");
            }
            else
            {
                Console.WriteLine("Both accounts have equal balances.");
            }
        }

        static void RestockProduct()
        {
            Product product = ChooseProduct();
            if (product != null)
            {
                Console.Write("Enter quantity to add: ");
                int quantity = ReadInt();
                product.Restock(quantity);

                if (product.StockQuantity < 10)
                {
                    Console.WriteLine("Stock level: Low");
                }
                else if (product.StockQuantity < 50)
                {
                    Console.WriteLine("Stock level: Moderate");
                }
                else
                {
                    Console.WriteLine("Stock level: Well Stocked");
                }
            }
        }

        static void TransferBetweenAccounts()
        {
            Console.WriteLine("Choose source account:");
            BankAccount sourceAccount = ChooseAccount();

            Console.WriteLine("Choose destination account:");
            BankAccount destinationAccount = ChooseAccount();

            if (sourceAccount == null || destinationAccount == null)
            {
                return;
            }

            Console.Write("Enter transfer amount: ");
            double amount = ReadDouble();

            if (sourceAccount.Balance >= amount)
            {
                sourceAccount.Withdraw(amount);
                destinationAccount.Deposit(amount);
                Console.WriteLine("Transfer completed.");
            }
            else
            {
                Console.WriteLine("Transfer failed: source account does not have enough balance.");
            }
        }

        static void UpdateStudentGradeValidated()
        {
            Student student = ChooseStudent();
            if (student != null)
            {
                Console.Write("Enter new grade: ");
                string gradeText = Console.ReadLine();
                int newGrade;

                if (int.TryParse(gradeText, out newGrade) == false)
                {
                    Console.WriteLine("Invalid grade: please enter a number.");
                    return;
                }

                if (newGrade < 0 || newGrade > 100)
                {
                    Console.WriteLine("Invalid grade: must be between 0 and 100.");
                    return;
                }

                student.Grade = newGrade;
                Console.WriteLine("Grade updated to: " + student.Grade);
            }
        }

        static void PrintStudentReportCard()
        {
            Student student = ChooseStudent();
            if (student != null)
            {
                string status = student.Grade >= 60 ? "Pass" : "Fail";
                Console.WriteLine("Report Card");
                Console.WriteLine("Name: " + student.Name);
                Console.WriteLine("Address: " + student.Address);
                Console.WriteLine("Grade: " + student.Grade);
                Console.WriteLine("Status: " + status);
            }
        }

        static void PrintAccountHealthStatus()
        {
            BankAccount account = ChooseAccount();
            if (account != null)
            {
                if (account.Balance < 50)
                {
                    Console.WriteLine("Low Balance");
                }
                else if (account.Balance <= 1000)
                {
                    Console.WriteLine("Healthy");
                }
                else
                {
                    Console.WriteLine("Premium");
                }
            }
        }

        static void BulkSaleWithRevenue()
        {
            Product product = ChooseProduct();
            if (product != null)
            {
                Console.Write("Enter quantity to sell: ");
                int quantity = ReadInt();

                if (product.StockQuantity < quantity)
                {
                    int additionalUnitsNeeded = quantity - product.StockQuantity;
                    Console.WriteLine("Not enough stock.");
                    Console.WriteLine("Additional units needed: " + additionalUnitsNeeded);
                    return;
                }

                product.Sell(quantity);
                double revenue = quantity * product.Price;
                Console.WriteLine("Revenue from sale: " + revenue);
            }
        }

        static void ScholarshipEligibilityCheck()
        {
            Console.WriteLine("Choose student:");
            Student student = ChooseStudent();

            Console.WriteLine("Choose account:");
            BankAccount account = ChooseAccount();

            if (student == null || account == null)
            {
                return;
            }

            bool gradeOk = student.Grade >= 80;
            bool balanceOk = account.Balance >= 100;

            if (gradeOk && balanceOk)
            {
                Console.WriteLine("Eligible");
            }
            else
            {
                if (gradeOk == false)
                {
                    Console.WriteLine("Student grade does not meet the requirement.");
                }

                if (balanceOk == false)
                {
                    Console.WriteLine("Account balance does not meet the requirement.");
                }
            }
        }

        static void FullBalanceTopUpFlow()
        {
            BankAccount account = ChooseAccount();
            if (account != null)
            {
                double before = account.Balance;
                Console.WriteLine("Balance before top-up: " + before);

                if (before < 50)
                {
                    double topUpAmount = 100 - before;
                    account.Deposit(topUpAmount);
                    Console.WriteLine("Top-up amount: " + topUpAmount);
                    Console.WriteLine("Balance after top-up: " + account.Balance);
                }
                else
                {
                    Console.WriteLine("No top-up is needed.");
                }
            }
        }

        static void QuickAccountOpening()
        {
            Console.Write("Enter account number: ");
            int accountNumber = ReadInt();

            Console.Write("Enter holder name: ");
            string holderName = Console.ReadLine();

            Console.Write("Enter starting balance: ");
            double startingBalance = ReadDouble();

            BankAccount newAccount = new BankAccount(accountNumber, holderName, startingBalance);
            newAccount.CheckBalance();
        }

        static void OverdrawnAccountCheck()
        {
            BankAccount account = ChooseAccount();
            if (account != null)
            {
                if (account.IsOverdrawn)
                {
                    Console.WriteLine("This account is currently overdrawn.");
                }
                else
                {
                    Console.WriteLine("This account is not overdrawn.");
                }
            }
        }

        static void SetStudentSecurityPin()
        {
            Student student = ChooseStudent();
            if (student != null)
            {
                Console.Write("Enter a 4-digit PIN: ");
                int pin = ReadInt();

                if (pin < 1000 || pin > 9999)
                {
                    Console.WriteLine("Invalid PIN. Please enter a 4-digit number.");
                    return;
                }

                student.SecurityPin = pin;
                Console.WriteLine("PIN has been set.");
            }
        }

        static BankAccount ChooseAccount()
        {
            Console.WriteLine("1 - Account 1 (" + account1.HolderName + ")");
            Console.WriteLine("2 - Account 2 (" + account2.HolderName + ")");
            Console.Write("Choose an account: ");
            int choice = ReadInt();

            if (choice == 1)
            {
                return account1;
            }
            else if (choice == 2)
            {
                return account2;
            }
            else
            {
                Console.WriteLine("Invalid account choice");
                return null;
            }
        }

        static Student ChooseStudent()
        {
            Console.WriteLine("1 - Student 1 (" + student1.Name + ")");
            Console.WriteLine("2 - Student 2 (" + student2.Name + ")");
            Console.Write("Choose a student: ");
            int choice = ReadInt();

            if (choice == 1)
            {
                return student1;
            }
            else if (choice == 2)
            {
                return student2;
            }
            else
            {
                Console.WriteLine("Invalid student choice");
                return null;
            }
        }

        static Product ChooseProduct()
        {
            Console.WriteLine("1 - Product 1 (" + product1.ProductName + ")");
            Console.WriteLine("2 - Product 2 (" + product2.ProductName + ")");
            Console.Write("Choose a product: ");
            int choice = ReadInt();

            if (choice == 1)
            {
                return product1;
            }
            else if (choice == 2)
            {
                return product2;
            }
            else
            {
                Console.WriteLine("Invalid product choice");
                return null;
            }
        }

        static int ReadInt()
        {
            while (true)
            {
                string text = Console.ReadLine();
                int value;

                if (int.TryParse(text, out value))
                {
                    return value;
                }

                Console.Write("Please enter a valid whole number: ");
            }
        }

        static double ReadDouble()
        {
            while (true)
            {
                string text = Console.ReadLine();
                double value;

                if (double.TryParse(text, out value))
                {
                    return value;
                }

                Console.Write("Please enter a valid number: ");
            }
        }
    }

    class BankAccount
    {
        public int AccountNumber { get; set; }
        public string HolderName { get; set; }
        public double Balance { get; set; }
        public bool IsOverdrawn
        {
            get { return Balance < 0; }
        }

        public BankAccount()
        {
        }

        public BankAccount(int accountNumber, string holderName, double startingBalance)
        {
            AccountNumber = accountNumber;
            HolderName = holderName;
            Balance = startingBalance;
        }

        public void Deposit(double amount)
        {
            Balance = Balance + amount;
            Console.WriteLine("Deposit completed.");
            SendEmail();
        }

        public void Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                Balance = Balance - amount;
                Console.WriteLine("Withdrawal completed.");
            }
            else
            {
                Console.WriteLine("Insufficient balance for withdrawal.");
            }

            SendEmail();
        }

        public double CheckBalance()
        {
            PrintInformation();
            return Balance;
        }

        private void PrintInformation()
        {
            Console.WriteLine("Holder Name: " + HolderName);
            Console.WriteLine("Balance: " + Balance);
        }

        private void SendEmail()
        {
            Console.WriteLine("Email notification sent.");
        }
    }

    class Student
    {
        public int Grade { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        private string email;
        int age;
        private int securityPin;
        private static int studentCount;

        public int SecurityPin
        {
            set
            {
                securityPin = value;
            }
        }

        public Student()
        {
            age = 0;
            studentCount++;
        }

        public void Register(string Email)
        {
            email = Email;
            if (age >= 0)
            {
            }
            Console.WriteLine("Student registration completed.");
            SendEmail();
        }

        public static int GetTotalStudentsCreated()
        {
            return studentCount;
        }

        private void SendEmail()
        {
            Console.WriteLine("Registration email sent.");
        }
    }

    class Product
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }

        public Product()
        {
        }

        public Product(string productName, double price, int stockQuantity)
        {
            ProductName = productName;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public void Sell(int quantity)
        {
            if (StockQuantity >= quantity)
            {
                StockQuantity = StockQuantity - quantity;
                Console.WriteLine("Sale completed.");
            }
            else
            {
                Console.WriteLine("not enough stock");
            }

            LogTransaction();
        }

        public void Restock(int quantity)
        {
            StockQuantity = StockQuantity + quantity;
            Console.WriteLine("Restock completed.");
            LogTransaction();
        }

        public double GetInventoryValue()
        {
            PrintDetails();
            return Price * StockQuantity;
        }

        private void PrintDetails()
        {
            Console.WriteLine("Product Name: " + ProductName);
            Console.WriteLine("Price: " + Price);
            Console.WriteLine("Stock Quantity: " + StockQuantity);
        }

        private void LogTransaction()
        {
            Console.WriteLine("Transaction logged.");
        }
    }
}
