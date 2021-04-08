using System;

namespace Maze
{
    static class Program
    {
        static void Main(string[] args)
        {
            Field.Fill(30);
            Field.Print();
            while (true)
            {
                Field.Move(Console.ReadKey().Key);
                if (Field.Current.X == Field.Destination.X && Field.Current.Y == Field.Destination.Y)
                {
                    Console.Clear();
                    break;
                }
                Console.Clear();
                Field.Print();
            }
            Console.WriteLine("No way.");
        }
    }
}