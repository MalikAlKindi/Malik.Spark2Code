using System;
using System.Collections.Generic;

namespace Spark2CodePart5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C# Fundamentals - Part 5 Practice");
            Console.WriteLine("Choose a task from 1 to 10:");
            int taskNumber = Convert.ToInt32(Console.ReadLine());

            switch (taskNumber)
            {
                case 1:
                {
                    int[] grades = new int[5];

                    for (int i = 0; i < grades.Length; i++)
                    {
                        Console.Write("Enter grade " + (i + 1) + ": ");
                        grades[i] = Convert.ToInt32(Console.ReadLine());
                    }

                    Console.WriteLine("Grades entered:");

                    foreach (int grade in grades)
                    {
                        Console.WriteLine(grade);
                    }
                    break;
                }

                case 2:
                {
                    List<string> tasks = new List<string>();

                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write("Enter task " + (i + 1) + ": ");
                        tasks.Add(Console.ReadLine());
                    }

                    Console.WriteLine("Your to-do list:");

                    foreach (string task in tasks)
                    {
                        Console.WriteLine("- " + task);
                    }
                    break;
                }

                case 3:
                {
                    Stack<string> history = new Stack<string>();

                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write("Enter website URL " + (i + 1) + ": ");
                        history.Push(Console.ReadLine());
                    }

                    string pageYouLandOn = history.Pop();
                    Console.WriteLine("You pressed back and landed on: " + pageYouLandOn);
                    break;
                }

                case 4:
                {
                    Queue<string> customers = new Queue<string>();

                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write("Enter customer name " + (i + 1) + ": ");
                        customers.Enqueue(Console.ReadLine());
                    }

                    string servedCustomer = customers.Dequeue();
                    Console.WriteLine("Served customer: " + servedCustomer);
                    break;
                }

                case 5:
                {
                    int[] grades = new int[5];
                    int total = 0;

                    for (int i = 0; i < grades.Length; i++)
                    {
                        Console.Write("Enter grade " + (i + 1) + ": ");
                        grades[i] = Convert.ToInt32(Console.ReadLine());
                    }

                    Array.Sort(grades);

                    for (int i = 0; i < grades.Length; i++)
                    {
                        total = total + grades[i];
                    }

                    double average = (double)total / grades.Length;

                    Console.WriteLine("Lowest grade: " + grades[0]);
                    Console.WriteLine("Highest grade: " + grades[grades.Length - 1]);
                    Console.WriteLine("Average grade: " + average);
                    break;
                }

                case 6:
                {
                    List<string> shoppingList = new List<string>();
                    bool keepAdding = true;

                    while (keepAdding)
                    {
                        Console.Write("Enter an item or type done: ");
                        string item = Console.ReadLine();

                        if (item.ToLower() == "done")
                        {
                            keepAdding = false;
                        }
                        else
                        {
                            shoppingList.Add(item);
                        }
                    }

                    Console.WriteLine("Shopping list before removal:");
                    foreach (string item in shoppingList)
                    {
                        Console.WriteLine(item);
                    }

                    Console.Write("Enter one item to remove: ");
                    string itemToRemove = Console.ReadLine();
                    shoppingList.Remove(itemToRemove);

                    Console.WriteLine("Shopping list after removal:");
                    foreach (string item in shoppingList)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                }

                case 7:
                {
                    List<int> scores = new List<int>();

                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write("Enter score " + (i + 1) + ": ");
                        scores.Add(Convert.ToInt32(Console.ReadLine()));
                    }

                    scores.Sort();
                    scores.Reverse();

                    Console.WriteLine("1st place: " + scores[0]);
                    Console.WriteLine("2nd place: " + scores[1]);
                    Console.WriteLine("3rd place: " + scores[2]);
                    break;
                }

                case 8:
                {
                    Stack<string> actions = new Stack<string>();
                    bool keepTyping = true;

                    while (keepTyping)
                    {
                        Console.Write("Enter an action or type stop: ");
                        string action = Console.ReadLine();

                        if (action.ToLower() == "stop")
                        {
                            keepTyping = false;
                        }
                        else
                        {
                            actions.Push(action);
                        }
                    }

                    if (actions.Count > 0)
                    {
                        Console.WriteLine("Undo: " + actions.Pop());
                    }

                    if (actions.Count > 0)
                    {
                        Console.WriteLine("Undo: " + actions.Pop());
                    }

                    Console.WriteLine("Remaining actions:");
                    foreach (string action in actions)
                    {
                        Console.WriteLine(action);
                    }
                    break;
                }

                case 9:
                {
                    Console.Write("How many grades do you want to enter? ");
                    int count = Convert.ToInt32(Console.ReadLine());

                    List<int> grades = new List<int>();

                    for (int i = 0; i < count; i++)
                    {
                        Console.Write("Enter grade " + (i + 1) + ": ");
                        grades.Add(Convert.ToInt32(Console.ReadLine()));
                    }

                    double average = CalculateAverage(grades);
                    int firstFailing = FindFirstFailing(grades);

                    Console.WriteLine("Average grade: " + average);

                    if (firstFailing == 0)
                    {
                        Console.WriteLine("First failing grade: No grade below 60");
                    }
                    else
                    {
                        Console.WriteLine("First failing grade: " + firstFailing);
                    }
                    break;
                }

                case 10:
                {
                    Queue<string> printJobs = new Queue<string>();
                    bool keepAdding = true;

                    while (keepAdding)
                    {
                        Console.Write("Enter print job name or type done: ");
                        string jobName = Console.ReadLine();

                        if (jobName.ToLower() == "done")
                        {
                            keepAdding = false;
                        }
                        else
                        {
                            printJobs.Enqueue(jobName);
                        }
                    }

                    Console.WriteLine("Queue before canceling:");
                    foreach (string job in printJobs)
                    {
                        Console.WriteLine(job);
                    }

                    Console.Write("Enter the job name to cancel: ");
                    string jobToCancel = Console.ReadLine();
                    printJobs = RemoveJob(printJobs, jobToCancel);

                    Console.WriteLine("Queue after canceling:");
                    foreach (string job in printJobs)
                    {
                        Console.WriteLine(job);
                    }
                    break;
                }

                default:
                    Console.WriteLine("Invalid task number");
                    break;
            }
        }

        static double CalculateAverage(List<int> grades)
        {
            int total = 0;

            for (int i = 0; i < grades.Count; i++)
            {
                total = total + grades[i];
            }

            return (double)total / grades.Count;
        }

        static int FindFirstFailing(List<int> grades)
        {
            int failingGrade = grades.Find(x => x < 60);
            return failingGrade;
        }

        static Queue<string> RemoveJob(Queue<string> jobs, string jobToCancel)
        {
            Queue<string> updatedJobs = new Queue<string>();

            while (jobs.Count > 0)
            {
                string job = jobs.Dequeue();

                if (job != jobToCancel)
                {
                    updatedJobs.Enqueue(job);
                }
            }

            return updatedJobs;
        }
    }
}
