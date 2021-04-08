using System;
using Maze.Models;

namespace Maze
{
    public static class Field
    {
        public static Point Current { get; set; }
        public static Point[,] Ground { get; set; }
        public static int Size { get; set; }
        
        public static Point Destination { get; set; }

        public static void Print()
        {
            for (int i = 0; i < Math.Sqrt(Ground.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(Ground.Length); j++)
                {
                    if (Ground[i, j].View == '+')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(Ground[i, j].View + " ");
                        Console.ResetColor();
                    }
                    else if(Ground[i, j].View == '0')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(Ground[i, j].View + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(Ground[i, j].View + " ");
                    }
                }

                Console.WriteLine();
            }
        }

        public static void Fill(int size)
        {
            Size = size;
            Ground = new Point[Size, Size];
            Random rnd = new Random();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Ground[i, j] = new Point {X = i, Y = j, View = rnd.Next(0, 3) == 0 ? '#' : '·'};
                }
            }

            Point start = new Point { X = rnd.Next(0,Size), Y = rnd.Next(0,Size), View = '+'};
            Ground[start.X, start.Y].View = start.View;
            Current = start;
            
            Point finish = new Point { X = rnd.Next(0,Size), Y = rnd.Next(0,Size), View = '0'};
            Ground[finish.X, finish.Y].View = finish.View;
            Destination = finish;
        }

        public static void Move(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (Ground[Current.X - 1, Current.Y].View != '#' || Current.X == 0)
                    {
                        Ground[Current.X, Current.Y].View = '·';
                        Ground[Current.X - 1, Current.Y].View = '+';
                        Current = Ground[Current.X - 1, Current.Y];
                    }
                    break;
                
                case ConsoleKey.DownArrow:
                    if (Ground[Current.X + 1, Current.Y].View != '#' || Current.X == Size - 1)
                    {
                        Ground[Current.X, Current.Y].View = '·';
                        Ground[Current.X + 1, Current.Y].View = '+';
                        Current = Ground[Current.X + 1, Current.Y];
                    }
                    break;
                
                case ConsoleKey.LeftArrow:
                    if (Ground[Current.X, Current.Y - 1].View != '#' || Current.Y == 0)
                    {
                        Ground[Current.X, Current.Y].View = '·';
                        Ground[Current.X, Current.Y - 1].View = '+';
                        Current = Ground[Current.X, Current.Y - 1];
                    }
                    break;
                
                case ConsoleKey.RightArrow:
                    if (Ground[Current.X, Current.Y + 1].View != '#' || Current.Y == Size - 1)
                    {
                        Ground[Current.X, Current.Y].View = '·';
                        Ground[Current.X, Current.Y + 1].View = '+';
                        Current = Ground[Current.X, Current.Y + 1];
                    }
                    break;
            }
        }
    }
}