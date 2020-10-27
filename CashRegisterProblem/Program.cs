using CashRegisterProblem.Common.Factories;
using CashRegisterProblem.Common.Interfaces;
using CashRegisterProblem.Data.Enums;
using System;
using System.IO;

namespace CashRegisterProblem
{
    /// <summary>
    /// Program Class
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <exception cref="Exception">Invalid input or output file path.</exception>
        private static void Main(string[] args)
        {
            // Welcome message with location options. We can add more locations for clients we sign
            Console.WriteLine("Hello and Welcome to the Cash Register App. Please type the location number:");
            Console.WriteLine("For example: Enter 1 for US and hit enter");
            Console.WriteLine("1. US");
            Console.WriteLine("2. France");

            if (Enum.TryParse(
                Console.ReadLine(),
                out Location location))
            {
                // Get the cashRegisterClient using the cashRegisterClientFactory
                ICashRegisterClientFactory cashRegisterClientFactory = new CashRegisterClientFactory();
                ICashRegisterClient cashRegisterClient = cashRegisterClientFactory.GetCashRegisterClientBasedOnLocation(location);
                // Get input and output paths
                string inputPath = GetInputFilePath();
                string outputPath = GetOutputFilePath();
                // check if the input file exists and if the directory for output file exists
                if (File.Exists(inputPath)
                    && 
                    Directory.Exists(Path.GetDirectoryName(outputPath)))
                {
                    cashRegisterClient.ProcessInputFileAndCalculateChange(
                        inputPath,
                        outputPath);
                    Console.WriteLine($"The output has been saved in {outputPath}. Press any key to exit.");
                    Console.ReadKey();
                }
                else
                {
                    throw new Exception("Invalid input or output file path.");
                }
            }
        }

        /// <summary>
        /// Gets the output file path.
        /// </summary>
        /// <returns></returns>
        private static string GetOutputFilePath()
        {
            string outputPath = string.Empty;
            while (string.IsNullOrWhiteSpace(outputPath))
            {
                Console.WriteLine("Please enter a path for the output file: ");
                Console.WriteLine("For example: 'C:\\Output\\output.csv'");
                outputPath = Console.ReadLine();
            }

            return outputPath;
        }

        /// <summary>
        /// Gets the input file path.
        /// </summary>
        /// <returns></returns>
        private static string GetInputFilePath()
        {
            string inputPath = string.Empty;
            while (string.IsNullOrWhiteSpace(inputPath))
            {
                Console.WriteLine("Please enter the path to input file:");
                Console.WriteLine("For example: 'C:\\Input\\input.csv'");
                inputPath = Console.ReadLine();
            }

            return inputPath;
        }
    }
}
