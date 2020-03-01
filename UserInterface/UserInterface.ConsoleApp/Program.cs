using System;
using UserInterface.ConsoleApp.Service;

namespace UserInterface.ConsoleApp
{
    public class Program
    {

        private static void Main(string[] args)
        {
            Console.WriteLine("----------------");
            short commandsCount = short.Parse(Console.ReadLine());
            string startingCoordinates = Console.ReadLine();
            string[] movementCommands = new string[commandsCount];
            for (int i = 0; i < commandsCount; i++)
            {
                movementCommands[i] = Console.ReadLine();
            }
            int cleanedPoints = new CleanerService().GetUniqueCleanedPoints(startingCoordinates, movementCommands);
            Console.WriteLine($"=> Cleaned: {cleanedPoints}");
            Console.ReadLine();
        }

    }
}
