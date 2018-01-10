using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Life
{
    class Program
    {
            static void Main(string[] args)
            {
                char[,] grid = new char[10, 10];
                for (int y = 0; y < grid.GetLength(0); y++)
                {
                    for (int x = 0; x < grid.GetLength(1); x++)
                    {
                        grid[x, y] = '0';
                    }
                }
                grid[4, 1] = '*';
                grid[4, 2] = '*';
                grid[4, 3] = '*';
                string KeepGoing = "y";
                while (KeepGoing == "y") 
                {
                    char[,] gridB = new char[10, 10];
                    for (int y = 0; y < grid.GetLength(0); y++)
                    {
                        for (int x = 0; x < grid.GetLength(1); x++)
                        {
                            Console.Write(grid[x, y]);
                            // check if not on edge
                            if ((grid[x, y] == '*') && x > 0 && x < 8 && y > 0 && y < 8)
                            {

                                if (grid[x, y] == '*' && (numberStarNeighbors(x, y, grid) == 2 || numberStarNeighbors(x, y, grid) == 3))
                                {
                                    gridB[x, y] = '*';
                                }
                                else if (grid[x, y] == '*' && (numberStarNeighbors(x, y, grid) == 0 || numberStarNeighbors(x, y, grid) == 1))
                                {
                                    gridB[x, y] = '0';
                                }
                                else if (grid[x, y] == '*' && numberStarNeighbors(x, y, grid) >= 4)
                                {
                                    gridB[x, y] = '0';
                                }

                            }
                            else if (grid[x, y] == '0' && x > 0 && x < 8 && y > 0 && y < 8)
                            {
                                if (grid[x, y] == '0' && numberStarNeighbors(x, y, grid) == 3)
                                {
                                    gridB[x, y] = '*';
                                }
                                else if (grid[x, y] == '0' && numberStarNeighbors(x, y, grid) != 3)
                                {
                                    gridB[x, y] = '0';
                                }
                            }
                            else
                            {
                                gridB[x, y] = '0';
                            }
                        }
                        Console.WriteLine();

                    }

                    Console.ReadLine();
                    grid = gridB;
                    Console.Clear();
                }


            }
            static int numberStarNeighbors(int x, int y, char[,] grid)
            {
                int starNeighbors = 0;
                if (grid[x, (y - 1)] == '*')
                {
                    starNeighbors = starNeighbors + 1;
                }
                if (grid[(x + 1), (y - 1)] == '*')
                {
                    starNeighbors = starNeighbors + 1;
                }
                if (grid[(x + 1), y] == '*')
                {
                    starNeighbors = starNeighbors + 1;
                }
                if (grid[(x + 1), (y + 1)] == '*')
                {
                    starNeighbors = starNeighbors + 1;
                }
                if (grid[x, (y + 1)] == '*')
                {
                    starNeighbors = starNeighbors + 1;
                }
                if (grid[(x - 1), (y + 1)] == '*')
                {
                    starNeighbors = starNeighbors + 1;
                }
                if (grid[(x - 1), y] == '*')
                {
                    starNeighbors = starNeighbors + 1;
                }
                if (grid[(x - 1), (y - 1)] == '*')
                {
                    starNeighbors = starNeighbors + 1;
                }
                return starNeighbors;
            }
        }
    }