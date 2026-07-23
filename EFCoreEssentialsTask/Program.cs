using EFCoreEssentialsTask;
using Microsoft.EntityFrameworkCore;

try
{
    using AppDbContext setupContext = new AppDbContext();
    setupContext.Database.EnsureCreated();
}
catch (Exception ex)
{
    Console.WriteLine("Could not connect to SQL Server.");
    Console.WriteLine(ex.Message);
    return;
}

bool running = true;

while (running)
{
    Console.WriteLine("\nBANK ACCOUNT SYSTEM");
    Console.WriteLine("1. Add account");
    Console.WriteLine("2. View all accounts");
    Console.WriteLine("3. Deposit money");
    Console.WriteLine("4. Delete account");
    Console.WriteLine("5. Search by holder name");
    Console.WriteLine("6. Accounts above a balance");
    Console.WriteLine("7. Account statistics");
    Console.WriteLine("0. Exit");
    Console.Write("Choose: ");

    switch (Console.ReadLine())
    {
        case "1":
            AddAccount();
            break;
        case "2":
            ViewAccounts();
            break;
        case "3":
            DepositMoney();
            break;
        case "4":
            DeleteAccount();
            break;
        case "5":
            SearchByName();
            break;
        case "6":
            FilterByBalance();
            break;
        case "7":
            ShowStatistics();
            break;
        case "0":
            running = false;
            break;
        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}

static void AddAccount()
{
    Console.Write("Holder name: ");
    string name = Console.ReadLine()?.Trim() ?? string.Empty;
    decimal balance = ReadDecimal("Starting balance: ");

    if (name.Length == 0 || balance < 0)
    {
        Console.WriteLine("Name is required and balance cannot be negative.");
        return;
    }

    using AppDbContext context = new AppDbContext();
    BankAccount account = new BankAccount
    {
        HolderName = name,
        Balance = balance
    };

    context.BankAccounts.Add(account);
    context.SaveChanges();
    Console.WriteLine($"Account {account.AccountId} was added.");
}

static void ViewAccounts()
{
    using AppDbContext context = new AppDbContext();
    List<BankAccount> accounts = context.BankAccounts
        .AsNoTracking()
        .OrderBy(a => a.AccountId)
        .ToList();

    if (accounts.Count == 0)
    {
        Console.WriteLine("No accounts found.");
        return;
    }

    foreach (BankAccount account in accounts)
    {
        Console.WriteLine($"{account.AccountId}: {account.HolderName} - OMR {account.Balance:F2}");
    }
}

static void DepositMoney()
{
    int id = ReadInt("Account ID: ");
    decimal amount = ReadDecimal("Deposit amount: ");

    if (amount <= 0)
    {
        Console.WriteLine("Deposit must be greater than zero.");
        return;
    }

    using AppDbContext context = new AppDbContext();
    BankAccount? account = context.BankAccounts.FirstOrDefault(a => a.AccountId == id);

    if (account == null)
    {
        Console.WriteLine("Account not found.");
        return;
    }

    account.Balance += amount;
    context.SaveChanges();
    Console.WriteLine($"New balance: OMR {account.Balance:F2}");
}

static void DeleteAccount()
{
    int id = ReadInt("Account ID: ");

    using AppDbContext context = new AppDbContext();
    BankAccount? account = context.BankAccounts.FirstOrDefault(a => a.AccountId == id);

    if (account == null)
    {
        Console.WriteLine("Account not found.");
        return;
    }

    context.BankAccounts.Remove(account);
    context.SaveChanges();
    Console.WriteLine("Account deleted.");
}

static void SearchByName()
{
    Console.Write("Enter a name: ");
    string search = Console.ReadLine()?.Trim() ?? string.Empty;

    using AppDbContext context = new AppDbContext();
    List<BankAccount> accounts = context.BankAccounts
        .AsNoTracking()
        .Where(a => a.HolderName.Contains(search))
        .OrderBy(a => a.HolderName)
        .ToList();

    if (accounts.Count == 0)
    {
        Console.WriteLine("No matching accounts.");
        return;
    }

    foreach (BankAccount account in accounts)
    {
        Console.WriteLine($"{account.AccountId}: {account.HolderName} - OMR {account.Balance:F2}");
    }
}

static void FilterByBalance()
{
    decimal minimum = ReadDecimal("Minimum balance: ");

    using AppDbContext context = new AppDbContext();
    List<BankAccount> accounts = context.BankAccounts
        .AsNoTracking()
        .Where(a => a.Balance >= minimum)
        .OrderByDescending(a => a.Balance)
        .ToList();

    Console.WriteLine($"Found {accounts.Count} account(s).");
    foreach (BankAccount account in accounts)
    {
        Console.WriteLine($"{account.HolderName} - OMR {account.Balance:F2}");
    }
}

static void ShowStatistics()
{
    using AppDbContext context = new AppDbContext();
    int totalAccounts = context.BankAccounts.Count();

    if (totalAccounts == 0)
    {
        Console.WriteLine("No accounts found.");
        return;
    }

    decimal totalBalance = context.BankAccounts.Sum(a => a.Balance);
    decimal averageBalance = context.BankAccounts.Average(a => a.Balance);
    BankAccount richestAccount = context.BankAccounts
        .AsNoTracking()
        .OrderByDescending(a => a.Balance)
        .First();

    Console.WriteLine($"Accounts: {totalAccounts}");
    Console.WriteLine($"Total balance: OMR {totalBalance:F2}");
    Console.WriteLine($"Average balance: OMR {averageBalance:F2}");
    Console.WriteLine($"Highest balance: {richestAccount.HolderName} - OMR {richestAccount.Balance:F2}");
}

static int ReadInt(string message)
{
    Console.Write(message);
    return int.TryParse(Console.ReadLine(), out int value) ? value : 0;
}

static decimal ReadDecimal(string message)
{
    Console.Write(message);
    return decimal.TryParse(Console.ReadLine(), out decimal value) ? value : -1;
}
