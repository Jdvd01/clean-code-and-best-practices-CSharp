using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TodoList { get; set; }

        static void Main(string[] args)
        {
            TodoList = new List<string>();
            int[] validOptions = [1, 2, 3, 4];
            int menuOption;
            do
            {
                menuOption = ShowMainMenu();
                if (menuOption == 1)
                {
                    ShowMenuAdd();
                }
                else if (menuOption == 2)
                {
                    ShowMenuRemove();
                }
                else if (menuOption == 3)
                {
                    ShowMenuTodoList();
                }
                else if (!validOptions.Contains(menuOption))
                {
                    Console.WriteLine("Invalid option, try again");
                }
            } while (menuOption != 4);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Enter the option to be made: ");
            Console.WriteLine("1. New task");
            Console.WriteLine("2. Remove task");
            Console.WriteLine("3. Show pending tasks");
            Console.WriteLine("4. Exit");
            Console.WriteLine("----------------------------------------");

            // Read line
            string option = Console.ReadLine();
            Console.WriteLine("----------------------------------------");
            return Convert.ToInt32(option);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Enter the number of the task to be removed: ");
                // Show current taks
                for (int index = 0; index < TodoList.Count; index++)
                {
                    Console.WriteLine((index + 1) + ". " + TodoList[index]);
                }
                Console.WriteLine("----------------------------------------");

                string taskToBeRemoved = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(taskToBeRemoved) - 1;
                if (indexToRemove > -1)
                {
                    if (TodoList.Count > 0)
                    {
                        string task = TodoList[indexToRemove];
                        TodoList.RemoveAt(indexToRemove);
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine("Task " + task + " removed");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Enter a new task: ");
                string task = Console.ReadLine();
                TodoList.Add(task);
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Task registered");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuTodoList()
        {
            if (TodoList == null || TodoList.Count == 0)
            {
                Console.WriteLine("No pending tasks");
            }
            else
            {
                Console.WriteLine("Your pending tasks:");
                for (int index = 0; index < TodoList.Count; index++)
                {
                    Console.WriteLine((index + 1) + ". " + TodoList[index]);
                }
                // Console.WriteLine("----------------------------------------");
            }
        }
    }
}
