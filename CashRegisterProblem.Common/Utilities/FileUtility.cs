using CashRegisterProblem.Data.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterProblem.Common.Utilities
{
    /// <summary>
    /// FileUtility
    /// </summary>
    public static class FileUtility
    {
        /// <summary>
        /// Processes the input file.
        /// </summary>
        /// <param name="inputPath">The input path.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Could not process input file due to bad data.</exception>
        internal static IEnumerable<Purchase> ProcessInputFile(string inputPath)
        {
            var purchases = new List<Purchase>();
            using (var reader = new StreamReader(File.OpenRead(inputPath)))
            {
                while (!reader.EndOfStream)
                {
                    var readLine = reader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(readLine))
                    {
                        var splitValues = readLine.Split(',');
                        if (splitValues.Length == 2
                            &&
                            !string.IsNullOrWhiteSpace(splitValues[0])
                            &&
                            !string.IsNullOrWhiteSpace(splitValues[1])
                            &&
                            decimal.TryParse(
                            splitValues[0],
                            out decimal owed)
                            &&
                            owed >= 0m
                            &&
                            decimal.TryParse(
                            splitValues[1],
                            out decimal paid)
                            &&
                            paid >= 0m)
                        {
                            purchases.Add(new Purchase(owed, paid));
                        }
                        else
                        {
                            throw new Exception("Could not process input file due to bad data.");
                        }
                    }
                }
            }
            return purchases;
        }

        /// <summary>
        /// Writes the output.
        /// </summary>
        /// <param name="outputPath">The output path.</param>
        /// <param name="owedAmounts">The owed amounts.</param>
        internal static void WriteOutput(string outputPath, List<string> owedAmounts)
        {
            using (var writer = new StreamWriter(outputPath))
            {
                foreach (var owedAmount in owedAmounts)
                {
                    writer.WriteLine(owedAmount);
                }
            }
        }
    }
}
