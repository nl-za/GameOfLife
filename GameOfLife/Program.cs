using System;
using System.Threading;

/// <summary>
/// Conway's Game of Life (https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life)
/// Author: Niel Langenhoven
/// Date: 30 July 2020
/// </summary>
namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            // get valid board size
            int rows = GetIntInput("Enter number of rows greater than 0");
            int columns = GetIntInput("Enter number of columns greater than 0");

            // get valid number of generations
            int generations = GetIntInput("Enter number of generations greater than 0");

            Grid grid = new Grid(rows, columns);
            grid.PopulateGrid();

            for (int i = 0; i < generations; i++)
            {
                PrintCells(grid, i);

                grid = grid.NextGeneration();

                Thread.Sleep(200);
            }

            Console.ReadKey();
        }

        private static int GetIntInput(string prompt)
        {
            string input;
            int value;
            do
            {
                Console.Write($"{prompt}: ");
                input = Console.ReadLine();

            } while (!int.TryParse(input, out value) || value <= 0);

            return value;
        }

        /// <summary>
        /// Print the cells to the console
        /// * represents an alive cell
        /// Empty space represents a dead cell
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="generation"></param>
        private static void PrintCells(Grid grid, int generation)
        {
            Console.Clear();

            Console.WriteLine($"Generation {generation}");

            for (int i = 0; i < grid.Rows; i++)
            {
                for (int j = 0; j < grid.Columns; j++)
                {
                    if (grid.Cells[i, j].State == State.Alive)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
        }
    }
}
