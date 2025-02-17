﻿using System;

class Program
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("============================");
        Console.WriteLine("  Secure Password Generator  ");
        Console.WriteLine("============================");
        Console.ResetColor();

        while (true) // Loop to allow multiple password generations.
        {
            // Get user inputs
            int Password_Length = Get_Password_Length(); // Ask user for password length.
            bool Include_Numbers = Get_Yes_No_Input("Include numbers? (yes/no): "); // Ask user if numbers should be included.
            bool Include_Uppercase = Get_Yes_No_Input("Include uppercase? (yes/no): "); // Ask user if uppercase should be included.
            bool Include_Special = Get_Yes_No_Input("Include special characters? (yes/no): "); // Ask user if special characters should be included.

            // Generate and display password
            string password = Generate_Password(Password_Length, Include_Numbers, Include_Uppercase, Include_Special);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nGenerated Password: {password}\n");
            Console.ResetColor();

            // Ask user if they want to generate another password
            if (!Get_Yes_No_Input("Would you like to generate a new password? (yes/no): "))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nThank you for using the Password Generator! Goodbye!\n");
                Console.ResetColor();
                break; // Exit loop if the user answers "no"
            }
        }
    }

    static int Get_Password_Length()
    {
        int length;
        while (true) // Keep asking until a valid number is entered.
        {
            Console.Write("Enter password length: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (int.TryParse(Console.ReadLine(), out length) && length > 0)
            {
                Console.ResetColor();
                return length; // Return valid password length.
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input. Please enter a positive number.");
            Console.ResetColor();
        }
    }

    static bool Get_Yes_No_Input(string prompt)
    {
        while (true) // Keep asking until a valid response is received.
        {
            Console.Write(prompt);
            Console.ForegroundColor = ConsoleColor.Magenta;
            string input = Console.ReadLine()?.Trim().ToLower(); // Read input, remove spaces, convert to lowercase.
            Console.ResetColor();

            if (input == "yes")
            {
                return true; // Return true if user enters "yes".
            }
            else if (input == "no")
            {
                return false; // Return false if user enters "no".
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
            Console.ResetColor();
        }
    }

    static string Generate_Password(int length, bool includeNumbers, bool includeUppercase, bool includeSpecial)
    {
        // Define character sets
        string lowercase = "abcdefghijklmnopqrstuvwxyz";
        string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string numbers = "0123456789";
        string special = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
        string allowedChars = lowercase;

        if (includeNumbers)
        {
            allowedChars += numbers; //add numbers
        }
        if (includeUppercase)
        {
            allowedChars += uppercase; //add uppercase
        }
        if (includeSpecial)
        {
            allowedChars += special; // add special characters
        }

        Random random = new Random();
        char[] password = new char[length];

        // Generate password by picking random characters from allowedChars.
        for (int i = 0; i < length; i++)
        {
            password[i] = allowedChars[random.Next(allowedChars.Length)];
        }

        return new string(password); // Convert character array to string and return.
    }
}
