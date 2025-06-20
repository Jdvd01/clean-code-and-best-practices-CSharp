﻿List<string> TodoList = new List<string>();
Menu[] validOptions = [Menu.Add, Menu.Remove, Menu.List, Menu.Exit];
Menu menuOption;

do
{
    menuOption = (Menu)ShowMainMenu();
    if (menuOption == Menu.Add) ShowMenuAdd();
    else if (menuOption == Menu.Remove) ShowMenuRemove();
    else if (menuOption == Menu.List) ShowMenuTodoList();
    else if (!validOptions.Contains(menuOption)) Console.WriteLine("Invalid option, try again");

} while (menuOption != Menu.Exit);

int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Enter the option to be made: ");
    Console.WriteLine("1. New task");
    Console.WriteLine("2. Remove task");
    Console.WriteLine("3. Show pending tasks");
    Console.WriteLine("4. Exit");
    Console.WriteLine("----------------------------------------");

    string option = Console.ReadLine();
    Console.WriteLine("----------------------------------------");
    int defaultOption = 0;
    if (int.TryParse(option, out defaultOption))
    {
        return Convert.ToInt32(option);
    }
    return defaultOption;
}

void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Enter the number of the task to be removed: ");

        bool isPending = ShowTodoList();
        if (!isPending) return;

        Console.WriteLine("----------------------------------------");
        string taskToBeRemoved = Console.ReadLine();

        int indexToRemove = Convert.ToInt32(taskToBeRemoved) - 1;

        if (indexToRemove <= (TodoList.Count - 1) && indexToRemove > -1 && TodoList.Count > 0)
        {
            string task = TodoList[indexToRemove];
            TodoList.RemoveAt(indexToRemove);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Task {task} removed");
        }
        else Console.WriteLine("Task not found");
    }
    catch (Exception)
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Something went wrong, try again");
    }
}

void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Enter a new task: ");
        string task = Console.ReadLine();

        if (!string.IsNullOrEmpty(task))
        {
            TodoList.Add(task);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Task registered");
        }
        else Console.WriteLine("Please enter a valid task");
    }
    catch (Exception)
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Something went wrong, try again");
    }

}

void ShowMenuTodoList()
{
    ShowTodoList();
}

bool ShowTodoList()
{
    if (TodoList?.Count > 0)
    {
        Console.WriteLine("Your pending tasks:");

        int taskIndex = 1;
        TodoList.ForEach(task => Console.WriteLine($"{taskIndex++}. {task}"));
        return true;
    }
    else
    {
        Console.WriteLine("No pending tasks");
        return false;
    }
}

enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}


