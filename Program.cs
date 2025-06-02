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
            Menu[] validOptions = [Menu.Add, Menu.Remove, Menu.List, Menu.Exit];
            Menu menuOption;
            do
            {
                menuOption = (Menu)ShowMainMenu();
                if (menuOption == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if (menuOption == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if (menuOption == Menu.List)
                {
                    ShowMenuTodoList();
                }
                else if (!validOptions.Contains(menuOption))
                {
                    Console.WriteLine("Invalid option, try again");
                }
            } while (menuOption != Menu.Exit);
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
                bool isPending = ShowTodoList();
                if (!isPending) return;
                Console.WriteLine("----------------------------------------");

                string taskToBeRemoved = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(taskToBeRemoved) - 1;

                if (indexToRemove > -1 && TodoList.Count > 0)
                {
                    string task = TodoList[indexToRemove];
                    TodoList.RemoveAt(indexToRemove);
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine($"Task {task} removed");
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
            ShowTodoList();
        }

        public static bool ShowTodoList()
        {
            if (TodoList == null || TodoList.Count == 0)
            {
                Console.WriteLine("No pending tasks");
                return false;
            }
            else
            {
                Console.WriteLine("Your pending tasks:");

                int taskIndex = 1;
                TodoList.ForEach(task =>
                {
                    Console.WriteLine($"{taskIndex++}. {task}");
                });
                return true;
            }
        }

        public enum Menu
        {
            Add = 1,
            Remove = 2,
            List = 3,
            Exit = 4
        }
    }
}
