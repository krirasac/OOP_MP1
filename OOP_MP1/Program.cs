using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_MP1
{
    internal class Program
    { 
        static List<int> bingo = new List<int>();
        static List<string> drawn = new List<string>();
        static bool flag = true;

        static void Main(string[] args)
        {
            while (true)
            { 
                flag = true;
                bingo = generateTable();
                run();
            }
        }

        /// <summary>
        /// Keeps the program running until the player decides to reset the board
        /// </summary>
        static void run()
        {
            while (flag)
            {
                if (bingo.Count == 0)
                {
                    results();
                    reset();
                }
                else
                {
                    displayboard();
                    choice();
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        /// <summary>
        /// Generates a set of BINGO numbers
        /// </summary>
        static List<int> generateTable()
        {
            for (int i = 1; i < 76; i++)
            {
                bingo.Add(i);
            }
            
            return bingo;
        }

        /// <summary>
        /// Displays the BINGO numbers
        /// </summary>
        static void displayboard()
        {
            char[] letter = new char[5] { 'B', 'I', 'N', 'G', 'O' };

            Console.WriteLine("\n" + center("WELCOME TO BINGO!\n"));

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"  {letter[i]} ");

                for (int j = 0; j < 15; j++)
                {
                    int number = (j + (i * 15)) + 1;

                    if (!bingo.Contains(number))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write($"\t{number}");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"\t{number}");
                    }

                    Console.ResetColor();
                }

                Console.Write("\n");
            }

        }

        /// <summary>
        /// Randomly picks the BINGO numbers
        /// </summary>
        /// <returns></returns>
        static int drawNum()
        {
            Random rnd = new Random();
            int selectedNum = bingo[rnd.Next(bingo.Count - 1)];
            bingo.Remove(selectedNum);
            return selectedNum;
        }

        /// <summary>
        /// Give the user a choice and executes it
        /// </summary>
        static void choice()
        {
            Console.WriteLine("\n" + center("What do you want to do?"));
            Console.WriteLine("\n" + center("[1] DRAW  [2] END"));
            Console.Write("\n" + center("Response: "));
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.Write("\n" + center($"You have selected {bingoFormat(drawNum())}"));
                    break;

                case "2":

                    Console.Clear();

                    while (true)
                    {
                        results();;
                        Console.WriteLine("\n" + center("Reset the board?"));
                        Console.WriteLine("\n" + center("[1] YES  [2] NO"));
                        Console.Write("\n" + center("Response: "));
                        userInput = Console.ReadLine();

                        if (userInput == "1")
                        {
                            reset();
                            break;
                        }
                        else if (userInput == "2")
                        {
                            Console.Write("\n" + center("Resuming the draw."));
                            break;
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Formats the numbers to its corresponding BINGO placement
        /// </summary>
        /// <param name="number"></param>
        static string bingoFormat(int number)
        {
            string format = "";
            
            if (number < 16)
                format = "B" + number.ToString();

            else if (number >= 16 && number < 31)
                format =  "I" + number.ToString();

            else if (number >= 31 && number < 46)
                format = "N" + number.ToString();

            else if (number >= 46 && number < 61)
                format = "G" + number.ToString();

            else if (number >= 61 && number < 76)
                format = "O" + number.ToString();
           
            drawn.Add(format);
            return format;
        }

        /// <summary>
        /// Displays the drawn numbers in order
        /// </summary>
        static void results()
        {
            Console.WriteLine("\n" + center("List of drawn number:"));

            if (drawn.Count == 0)
                Console.WriteLine("\n" + center("You haven't drawn any numbers!"));
            else
                for (int i = 0; i < drawn.Count; i++)
                {
                    if (i % 13 == 12)
                        Console.WriteLine($"\t{drawn[i]} ");
                    else
                        Console.Write($"\t{drawn[i]} ");
                }
            Console.WriteLine();
        }

        /// <summary>
        /// Resets the whole program
        /// </summary>
        /// <returns></returns>
        static void reset()
        {
            Console.Write("\n" + center("Resetting the board...."));
            flag = false;
            drawn = new List<string>();
            bingo = new List<int>();
        }

        /// <summary>
        /// Method to center the text
        /// </summary>
        /// <param name="words"></param>
        /// <param name="charLength"></param>
        /// <returns></returns>
        static string center(string words, int charLength = 120)
        {
            string justify = "";
            int space = (charLength / 2) - (words.Length / 2);
            int count = 0;

            for (int i = 0; i < space; i++)
            {
                justify += ' ';
                count++;
            }

            for (int i = 0; i < words.Length; i++)
            {
                justify += words[i];
                count++;
            }

            return justify;
        }
    }
}
