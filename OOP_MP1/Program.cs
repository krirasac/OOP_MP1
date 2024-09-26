using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_MP1
{
    internal class Program
    {
        static Random rnd = new Random();
        static int selectedNum = 0;
        static List<int[]> bingo = new List<int[]>();
        static List<bool[]> taken = new List<bool[]>();
        static List<int> drawn = new List<int>();
        static string userInput = "";

        static void Main(string[] args)
        {
            run();
            Console.ReadKey();
        }

        static void run()
        {
            generateTable();

            while (userInput != "end")
            {
                choice();
                Console.ReadKey();
                Console.Clear();
            }
        
        }

        static void generateTable()
        {
            for (int i = 0; i < 5; i++)
            {
                bingo.Add(new int[15]);

                for (int j = 0; j < 15; j++)
                {
                    bingo[i][j] = (j + (i * 15)) + 1;
                    Console.Write($"{bingo[i][j]} \t");
                }
                Console.WriteLine();
            }
        }

        static void display()
        {
            foreach (int[] column in bingo)
            {
                for (int i = 0; i < 15; i++)
                { 

                
                }
            
            }
        }


        static void drawNum()
        {
            selectedNum = rnd.Next(1,76);

            if (selectedNum < 16)
            {
                Console.WriteLine($"You have drawn B{selectedNum}");
            }
            else if (selectedNum >= 16 && selectedNum < 31)
            {
                Console.WriteLine($"You have drawn I{selectedNum}");
            }
            else if (selectedNum >= 31 && selectedNum < 46)
            {
                Console.WriteLine($"You have drawn N{selectedNum}");
            }
            else if (selectedNum >= 46 && selectedNum < 61)
            {
                Console.WriteLine($"You have drawn G{selectedNum}");
            }
            else if (selectedNum >= 61 && selectedNum < 76)
            {
                Console.WriteLine($"You have drawn O{selectedNum}");
            }

            drawn.Add(selectedNum);
        }

        static void choice()
        {
            Console.WriteLine("\nWhat do you want to do?");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    
                    drawNum();
                    break;

                case "2":

                    break;
            }

        }


    }
}
