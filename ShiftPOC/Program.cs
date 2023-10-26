using System;

namespace ShiftPOC;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World 1234!");

        int[,] myArray = new int[8, 8];

        Random rand = new Random();

        for (int i = 0; i < myArray.GetLength(0); i++)
        {
            for (int j = 0; j < myArray.GetLength(1); j++)
            {
                if (i >= 2 && i <= 5 && j >= 2 && j <= 5)
                {
                    myArray[i, j] = 0;
                }
                else
                {
                    myArray[i, j] = rand.Next(1, 5);
                }
            }
        }
        PrintArray(myArray);

        while (true)
        {
            if (Console.ReadKey(true).Key == ConsoleKey.S)
            {
                MoveValuesOneRowDown(myArray);
                Console.Clear();
                CleanValues(myArray);
                FillBorders(myArray);
                PrintArray(myArray);
            }

            if (Console.ReadKey(true).Key == ConsoleKey.D)
            {
                MoveValuesOneColumnRight(myArray);
                Console.Clear();
                CleanValues(myArray);
                FillBorders(myArray);
                PrintArray(myArray);
            }

        }

    }

    public static void PrintArray(int[,] myArray)
    {
        for (int i = 0; i < myArray.GetLength(0); i++)
        {
            for (int j = 0; j < myArray.GetLength(1); j++)
            {
                if (myArray[i, j]==0)
                    Console.Write(" " + " ");
                else 
                    Console.Write(myArray[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public static void MoveValuesOneRowDown(int[,] myArray)
    {
        for (int i = myArray.GetLength(0) - 2; i >= 0; i--)
        {
            for (int j = 0; j < myArray.GetLength(1); j++)
            {
                if (myArray[i + 1, j] == 0 && myArray[i, j] != 0)
                {
                    myArray[i + 1, j] = myArray[i, j];
                    myArray[i, j] = 0;
                }
            }
        }
    }


    public static void MoveValuesOneColumnRight(int[,] myArray)
    {
        for (int i = 0; i < myArray.GetLength(0); i++)
        {
            for (int j = myArray.GetLength(1) - 2; j >= 0; j--)
            {
                if (myArray[i, j + 1] == 0 && myArray[i, j] != 0)
                {
                    myArray[i, j + 1] = myArray[i, j];
                    myArray[i, j] = 0;
                }
            }
        }
    }


    public static void CleanValues(int[,] myArray)
    {
        for (int i = 1; i < myArray.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < myArray.GetLength(1) - 1; j++)
            {
                if (myArray[i, j] != 0 &&
                    myArray[i, j] == myArray[i - 1, j] &&
                    myArray[i, j] == myArray[i + 1, j] &&
                    myArray[i, j] == myArray[i, j - 1] &&
                    myArray[i, j] == myArray[i, j + 1])
                {
                    myArray[i, j] = 0;
                }
            }
        }
    }

    public static void FillBorders(int[,] myArray)
    {
        // Fill top and bottom borders
        for (int i = 0; i < myArray.GetLength(1); i++)
        {
            if (myArray[0, i] == 0)
            {
                myArray[0, i] = new Random().Next(1, 5);
            }

            if (myArray[myArray.GetLength(0) - 1, i] == 0)
            {
                myArray[myArray.GetLength(0) - 1, i] = new Random().Next(1, 5);
            }
        }

        // Fill left and right borders
        for (int i = 0; i < myArray.GetLength(0); i++)
        {
            if (myArray[i, 0] == 0)
            {
                myArray[i, 0] = new Random().Next(1, 5);
            }

            if (myArray[i, myArray.GetLength(1) - 1] == 0)
            {
                myArray[i, myArray.GetLength(1) - 1] = new Random().Next(1, 5);
            }
        }
    }


}


