﻿using GreetingApp;
using Dapper;
using Npgsql;

// Greeting App
Console.WriteLine("Welcome to Greeting App\nType 'help' for information on how to use the app.");

// Connection string
string cs = "";

// Instance of Greet
// IGreet greet = new Greet();
IGreet greet = new GreetWithDB(cs);

bool runApp = true;

while(runApp == true)
{

    Console.ResetColor();  
    // Prompt user to "Enter a command"
    Console.Write("Enter a command > ");

    // User input command
    string? enteredCommand = Console.ReadLine().ToLower();
    Console.ForegroundColor = ConsoleColor.Green;

    if(enteredCommand == "exit")
    {   
        Console.WriteLine("Thank you for using the greeting app developed by @anthony.");
        runApp = false;
    }
    else if(enteredCommand == "help")
    {
        Console.WriteLine("Greeting app commands:");
        foreach (var command in Commands.Help())
        {
            Console.WriteLine($"  {command}");
        }
    }
    else if(enteredCommand.Split(" ")[0] == "greet" && enteredCommand.Split(" ").Length >= 2)
    {
        Console.WriteLine("> " + greet.GreetUser(enteredCommand));
    }
    else if(enteredCommand == "greeted")
    {
        if(greet.Greeted().Count() != 0)
        {
            Console.WriteLine(">");
            foreach (var nameCount in greet.Greeted())
            {
                Console.WriteLine($"  {nameCount.Key}: {nameCount.Value}");  
            }
        }
        else
        {
            Console.WriteLine("No user has been greeted, list is empty.");
        }
    }
    else if(enteredCommand.Split(" ")[0] == "greeted" && enteredCommand.Split(" ").Length == 2)
    {
        Console.WriteLine("> " + greet.GreetedTimes(enteredCommand));
    }
    else if(enteredCommand == "counter")
    {
        Console.WriteLine($"> {greet.Counter()} user/s have been greeted.");
    }
    else if(enteredCommand == "clear")
    {
        greet.Clear();
        Console.WriteLine("> The names has been cleared from the list.");
    }
    else if(enteredCommand.Split(" ")[0] == "clear" && enteredCommand.Split(" ").Length == 2)
    {
        Console.WriteLine("> " + greet.ClearName(enteredCommand));
        
    }
    else
    {
        Console.WriteLine($"> Invalid command: '{enteredCommand}' is not defined.\n  Type 'help' for information on how to use the app.");
    }
}


